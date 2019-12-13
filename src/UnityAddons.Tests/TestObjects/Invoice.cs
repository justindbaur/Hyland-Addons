using UnityAddons.WorkView;

namespace UnityAddons.Tests.TestObjects
{
    public class Invoice
    {
        [WorkViewAttribute(Modifiers = WorkViewAttributeModifiers.Key)]
        public string InvoiceNum { get; set; }

        public decimal InvoiceAmount { get; set; }

        [WorkViewAttribute("LinkToVendor.VendorID", WorkViewAttributeModifiers.Optional)]
        public string VendorId { get; set; }

        [WorkViewAttribute("LinkToCompany.Company")]
        public string Company { get; set; }
    }
}
