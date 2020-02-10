using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.WorkView
{
    public static class ObjectMergeHelper
    {
        public static ObjectDictionary<T> Merge<T>(this Hyland.Unity.WorkView.ExecutableFilterQuery query, IEnumerable<T> externalList)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (externalList == null)
            {
                throw new ArgumentNullException(nameof(externalList));
            }

            var totalList = new ObjectDictionary<T>();

            var itemResults = query.Execute(long.MaxValue);

            totalList.Mode = InsertionMode.Add;

            foreach (var item in itemResults)
            {
                // Get WorkView Object of each item in the query
                var @object = query.Class.GetObjectByID(item.ObjectID);
                // Try to add it to the running list, if it already has an item by it's key, delete other appearances of it.
                if (!totalList.Add(@object))
                {
                    @object.Delete();
                }
            }

            // Switch mode to overwrite existing item and mark them for update if needed
            totalList.Mode = InsertionMode.Merge;

            // Add external items for overwriting
            foreach (var item in externalList)
            {
                totalList.Add(item);
            }

            return totalList;
        }

        public static void RunMerge<T>(this Hyland.Unity.WorkView.ExecutableFilterQuery query, IEnumerable<T> externalList, Action<Hyland.Unity.WorkView.Object, T> mapper = null)
        {
            // If a mapper wasn't given, create one
            if (mapper == null)
            {
                mapper = (obj, item) =>
                {
                    var avm = obj.CreateAttributeValueModifier();

                    foreach (var prop in item.GetType().GetProperties().Where(prop => WorkViewAttributeAttribute.IsDefined(prop)))
                    {
                        var address = WorkViewAttributeAttribute.GetAttributeAddress(prop);
                        if (address.Depth != 1)
                        {
                            continue;
                        }

                        var attribute = query.Class.Attributes.Find(address.FullPath);

                        avm.SetAttributeValue(attribute, prop.GetValue(item));
                    }

                    avm.ApplyChanges();
                };
            }

            var dictionary = Merge<T>(query, externalList);

            foreach (var item in dictionary.UpdateItemList)
            {
                if (item.ObjectId is long id)
                {
                    mapper(query.Class.GetObjectByID(id), item.Item);
                }
            }

            foreach (var item in dictionary.NewItemList)
            {
                mapper(query.Class.CreateObject(), item.Item);
            }
        }
    }
}
