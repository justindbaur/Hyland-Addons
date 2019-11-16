using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HylandAddons.WorkView;

namespace HylandAddonsTests
{
    public class InvoiceXMessage
    {
        [WorkViewAttribute("LinkToMessage.Message")]
        public string Message { get; set;  }

        [WorkViewAttribute]
        public bool IsHandled { get; set; }

        [WorkViewAttribute("LinkToInvoice.InvoiceNum")]
        public string InvoiceNum { get; set; }
    }
}
