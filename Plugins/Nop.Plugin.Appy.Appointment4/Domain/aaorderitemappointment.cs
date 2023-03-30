using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaorderitemappointment : BaseEntity
    {
        public new int orderItemID { get; set; }
        public int OrderId { get; set; }
        public string cardID { get; set; }
        public DateTime? appointmentDate { get; set; }
        public DateTime? timeFrom { get; set; }
        public DateTime? timeTo { get; set; }
    }
}
