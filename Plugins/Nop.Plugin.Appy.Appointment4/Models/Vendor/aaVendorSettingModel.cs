using Nop.Web.Areas.Admin.Models.Settings;
using Nop.Web.Areas.Admin.Models.Vendors;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Appy.Appointment4.Models.Vendor
{
    public partial record aaVendorSettingsModel : VendorSettingsModel
    {
        public double VendorLongitude { get; set; }
        public double VendorLatitude { get; set; }
        public int VendorParentId { get; set; }
    }
}
