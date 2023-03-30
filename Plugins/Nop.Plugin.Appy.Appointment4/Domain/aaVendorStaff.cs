using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaVendorStaff : BaseEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int ClinicId { get; set; }
        public bool Manage { get; set; }
    }
}
