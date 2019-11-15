using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyland.Unity;

namespace HylandAddons
{
    public static class CommonHelpers
    {
        public static Keyword FindByKeywordType(this Hyland.Unity.Document document, KeywordType keywordType)
        {
            return document?.KeywordRecords.Find(keywordType)?.Keywords.Find(keywordType);
        }
    }
}
