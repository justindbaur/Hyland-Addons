using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HylandAddons
{
    public class AttributeAddress
    {
        #region Fields
        private string[] addressArray;

        private const char onbaseSplitChar = '.';
        #endregion

        #region Constructors
        public AttributeAddress(string address)
        {
            addressArray = address.Split(SplitChar);
        }

        public AttributeAddress(params string[] addresses)
        {
            addressArray = addresses;
        }
        #endregion

        #region Properties
        public static char SplitChar { get; set; } = '.';

        /// <summary>
        /// By default true, if set to false, any attribute attempted to be found using this object will throw it's given exception
        /// </summary>
        public bool IgnoreErrors { get; set; } = true;

        public int Depth => (addressArray?.Length ?? 0) - 1;

        public string FinalAttribute => addressArray[addressArray.Length - 1];

        public string AttributePath => string.Join(onbaseSplitChar.ToString(), addressArray.Take(addressArray.Length - 1).ToArray());

        public override string ToString()
        {
            return string.Join(onbaseSplitChar.ToString(), addressArray);
        }
        #endregion
    }
}
