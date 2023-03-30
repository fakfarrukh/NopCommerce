using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// Represents a state/province
    /// </summary>
    public class aaAppointment : BaseEntity
    {
        public new int Id { get; set; }
        public string BookingPeriod { get; set; }
        public string BookingTimeBlock { get; set; }
        public bool Cancelable { get; set; }
        public bool ConfirmationNeeded { get; set; }
        public string BookingOpenSooner { get; set; }
        public string BookingOpenLater { get; set; }
        public int ProductId { get; set; }
    }
}
