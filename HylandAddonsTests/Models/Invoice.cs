using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HylandAddons.WorkView;

namespace HylandAddonsTests.Models
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
