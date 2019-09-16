using Hyland.Unity.WorkView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HylandAddons
{
    public static class AttributeValueHelper
    {
        /// <summary>
        /// Find an attribute value by a full path. Will return null if the attribute could not be found or the address is an invalid format
        /// </summary>
        /// <param name="wvObject">Starting object that is used to trace the string address to the final attribute value</param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static AttributeValue AttributeValueByAddress(this Hyland.Unity.WorkView.Object wvObject, AttributeAddress address)
        {
            try
            {
                if (address.Depth == -1)
                {
                    throw new InvalidOperationException($"String Address: { address.ToString() } is in an invalid format.");
                }

                if (address.Depth == 0)
                {
                    return wvObject.AttributeValues.Find(address.FinalAttribute);
                }

                var relatedObject = wvObject.GetRelatedObject(address.AttributePath);

                if (relatedObject == null)
                {
                    throw new InvalidOperationException($"Could not find a related object by string { address.AttributePath } on object { wvObject.Name }");
                }

                return relatedObject.AttributeValues.Find(address.FinalAttribute);
            }
            catch (Exception ex)
            {
                if (address.IgnoreErrors)
                {
                    return null;
                }

                throw ex;
            }
        }

        /// <summary>
        /// Find an attribute value by a full path. Will return null if the attribute could not be found or the address is an invalid format
        /// </summary>
        /// <param name="wvObject">Starting object that is used to trace the string address to the final attribute value</param>
        /// <param name="address">String address that contains a character (.) between each progressing attribute name</param>
        /// <returns></returns>
        public static AttributeValue AttributeValueByAddress(this Hyland.Unity.WorkView.Object wvObject, string address)
        {
            return AttributeValueByAddress(wvObject, new AttributeAddress(address));
        }

        /// <summary>
        /// Find an attribute value by a full path. Will return null if the attribute could not be found or the address is an invalid format
        /// </summary>
        /// <param name="wvObject">Starting object that is used to trace the string address to the final attribute value</param>
        /// <param name="addresses">Address array that contains the attribute names of each progressing class</param>
        /// <returns></returns>
        public static AttributeValue AttributeValueByAddress(this Hyland.Unity.WorkView.Object wvObject, params string[] addresses)
        {
            return AttributeValueByAddress(wvObject, new AttributeAddress(addresses));
        }
    }
}
