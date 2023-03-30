

namespace Nop.Plugin.Misc.AppyTwoAppointment.Models.AppyAppointmentModel
{
    public class VendorStaff 
    {
        public Guid Id { get; set; }
        public int VendorId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public bool Manage { get; set; }

        public Vendor? Vendor { get; set; }
        public Product? Product { get; set; }

    }
}
