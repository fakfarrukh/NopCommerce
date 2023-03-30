using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaAppointment : BaseEntity
    {
        public new int Id { get; set; }
        public string BookingPeriod { get; set; }
        public double BookingTimeBlock { get; set; }
        public bool Cancelable { get; set;}
        public bool ConfirmationNeeded { get; set;}
        public double BookingOpenSooner { get; set;}
        public double BookingOpenLater { get;}
        public int ProductId { get; set;}
    }
}
