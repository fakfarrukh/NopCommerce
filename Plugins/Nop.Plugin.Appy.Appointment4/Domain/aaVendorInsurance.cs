using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaVendorInsurance : BaseEntity
    {
        public new int Id { get; set; }
        public int VendorInsuranceId { get; set; }
        public int VendorId { get; set; }
    }
}
