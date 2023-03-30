using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaServiceCatagory : BaseEntity
    {
        public new int Id { get; set; }
        public string? ServiceCategory { get; set; }
        public string? ArabicName { get; set; }
    }
}
