using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaVendor : BaseEntity
    {
        public int VendoreId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int? ParrentVendor { get; set; }
    }
}
