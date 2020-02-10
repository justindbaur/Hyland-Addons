using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityAddons.WorkView;

namespace UnityAddons.WorkView
{
    public class ObjectDictionary<T>
    {
        private Dictionary<string, CustomObject<T>> _items;
        private PropertyInfo[] _cachedKeyLocations;

        public InsertionMode Mode { get; set; }

        public ObjectDictionary()
        {
            _items = new Dictionary<string, CustomObject<T>>();
            _cachedKeyLocations = WorkViewAttributeAttribute.GetKeys<T>().ToArray();
        }

        public List<CustomObject<T>> UpdateItemList => _items.Values.Where(co => co.Status == InfoStatus.Update).ToList();
        public List<CustomObject<T>> NewItemList => _items.Values.Where(co => co.Status == InfoStatus.New).ToList();


        public int Count => _items.Count;
        public bool IsReadOnly => false;

        public bool Add(T item, long? objectId = null, DateTime? revisionDate = null)
        {
            string key = GetKey(item);

            //bool exists = _items.TryGetValue(key, out CustomObject<T> existing);

            switch (Mode)
            {
                case InsertionMode.Add:
                    if (_items.ContainsKey(key))
                    {
                        // TODO: Possible don't return false and return the object of the older item
                        return false;
                    }
                    else
                    {
                        _items.Add(key, new CustomObject<T>(item, InfoStatus.Ignore, objectId, revisionDate));
                    }
                    break;
                case InsertionMode.Merge:
                    if (_items.TryGetValue(key, out CustomObject<T> value))
                    {
                        value.UpdateWith(item);
                    }
                    else
                    {
                        _items.Add(key, new CustomObject<T>(item, InfoStatus.New, objectId, revisionDate));
                    }
                    break;
                default:
                    throw new Exception($"Unknown Insertion Mode '{Mode}'");
            }

            return true;
        }

        public bool Add(Hyland.Unity.WorkView.Object wvObject)
        {
            if (wvObject == null)
            {
                throw new ArgumentNullException(nameof(wvObject));
            }

            var item = WorkViewObjectConvert.DeserializeWorkViewObject<T>(wvObject);

            return Add(item, wvObject.ID, wvObject.RevisionDate);
        }

        //private bool InternalAdd(T item, string key, DateTime? revisionDate = null, long? objectid = null)
        //{
            
        //}

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            string key = GetKey(item);

            return _items.ContainsKey(key);
        }

        private string GetKey(T item)
        {
            string key = string.Empty;

            foreach (var prop in _cachedKeyLocations)
            {
                key += prop.GetValue(item, null);
            }

            return key;
        }

        //public void CopyTo(CustomObject<T>[] array, int arrayIndex)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerator<CustomObject<T>> GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }

        //public int IndexOf(CustomObject<T> item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(int index, CustomObject<T> item)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Remove(T item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
