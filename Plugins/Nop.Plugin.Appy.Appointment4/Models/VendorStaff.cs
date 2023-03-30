using Nop.Core.Domain.Vendors;

namespace Nop.Plugin.Appy.Appointment4.Models
{
    public class VendorStaff
    {
        public List<Nop.Core.Domain.Vendors.Vendor> vendors { get; set; }
        public IEnumerable<string> clinic { get; set; }
    }
}
