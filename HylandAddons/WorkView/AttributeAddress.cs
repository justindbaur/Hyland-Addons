using Hyland.Unity.WorkView;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;

namespace HylandAddons
{
    public class AttributeAddress
    {
        #region Fields
        private List<string> addressPath;

        private const char onbaseSplitChar = '.';
        #endregion

        #region Constructors
        public AttributeAddress(string address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            addressPath = address.Split(onbaseSplitChar).ToList();
        }

        public AttributeAddress(params string[] addresses)
        {
            if (addresses == null)
            {
                throw new ArgumentNullException(nameof(addresses));
            }

            addressPath = addresses.ToList();
        }
        #endregion

        #region Properties
        /// <summary>
        /// By default true, if set to false, any attribute attempted to be found using this object will throw it's given exception
        /// </summary>
        [DefaultValue(true)]
        public bool IgnoreErrors { get; set; } = true;

        public int Depth => (addressPath?.Count ?? 0) - 1;

        public string FinalAttribute => addressPath[addressPath.Count - 1];

        public string NavigationPath => Depth > 0 ? string.Join(onbaseSplitChar.ToString(), addressPath.GetRange(0, addressPath.Count - 1)) : null;

        public string FullPath => string.Join(onbaseSplitChar.ToString(), addressPath);

        public override string ToString()
        {
            return string.Join(onbaseSplitChar.ToString(), addressPath);
        }

        public AttributeValue GetAttributeValue(Hyland.Unity.WorkView.Object wvObject)
        {
            return wvObject.AttributeValueByAddress(this);
        }
        #endregion
    }
}
