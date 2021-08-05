using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAddons.Serialization.Converters;

namespace UnityAddons.Serialization.Metadata
{
    public static class WorkViewMetadataServices
    {
        public static WorkViewConverter<bool> BooleanConverter
        {
            get
            {
                if (_booleanConverter == null)
                {
                    _booleanConverter = new BooleanConverter();
                }

                return _booleanConverter;
            }
        }

        private static WorkViewConverter<bool> _booleanConverter;

        public static WorkViewConverter<long> LongConverter
        {
            get
            {
                if (_longConverter == null)
                {
                    _longConverter = new LongConverter();
                }

                return _longConverter;
            }
        }

        private static WorkViewConverter<long> _longConverter;

        public static WorkViewConverter<string> StringConverter
        {
            get
            {
                if (_stringConverter == null)
                {
                    _stringConverter = new StringConverter();
                }

                return _stringConverter;
            }
        }

        private static WorkViewConverter<string> _stringConverter;

        public static WorkViewConverter<DateTime> DateTimeConverter
        {
            get
            {
                if (_dateTimeConverter == null)
                {
                    _dateTimeConverter = new DateTimeConverter();
                }

                return _dateTimeConverter;
            }
        }

        private static WorkViewConverter<DateTime> _dateTimeConverter;

        public static WorkViewConverter<decimal> DecimalConverter
        {
            get
            {
                if (_decimalConverter == null)
                {
                    _decimalConverter = new DecimalConverter();
                }

                return _decimalConverter;
            }
        }

        private static WorkViewConverter<decimal> _decimalConverter;

        public static WorkViewConverter<double> DoubleConverter
        {
            get
            {
                if (_doubleConverter == null)
                {
                    _doubleConverter = new DoubleConverter();
                }

                return _doubleConverter;
            }
        }

        private static WorkViewConverter<double> _doubleConverter;
    }
}
