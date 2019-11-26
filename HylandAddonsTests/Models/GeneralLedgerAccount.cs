using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HylandAddons.WorkView;

namespace HylandAddonsTests.Models
{
    public class GeneralLedgerAccount
    {
        [WorkViewAttribute(Modifiers = WorkViewAttributeModifiers.Key)]
        public string Company { get; set; }

        [WorkViewAttribute(Modifiers = WorkViewAttributeModifiers.Key)]
        public string COACode { get; set; }

        [WorkViewAttribute("GLName", Modifiers = WorkViewAttributeModifiers.Key)]
        public string GLAccount1 { get; set; }

        [WorkViewAttribute("Description")]
        public string AccountDesc { get; set; }

        [WorkViewAttribute]
        public string SegValue1 { get; set; }

        [WorkViewAttribute]
        public string SegValue2 { get; set; }

        [WorkViewAttribute]
        public string SegValue3 { get; set; }

        [WorkViewAttribute]
        public string SegValue4 { get; set; }

        [WorkViewAttribute]
        public string SegValue5 { get; set; }

        [WorkViewAttribute]
        public bool Active { get; set; }

        [WorkViewAttribute("FullName")]
        public string GLAcctDispGLAcctDisp { get; set; }
    }
}
