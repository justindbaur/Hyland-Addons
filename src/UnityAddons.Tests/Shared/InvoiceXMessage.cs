using UnityAddons.WorkView;

namespace UnityAddons.Tests.Shared
{
    public class InvoiceXMessage
    {
        [WorkViewAttribute("LinkToMessage.Message")]
        public string Message { get; set; }

        [WorkViewAttribute]
        public bool IsHandled { get; set; }

        [WorkViewAttribute("LinkToInvoice.InvoiceNum")]
        public string InvoiceNum { get; set; }
    }
}
