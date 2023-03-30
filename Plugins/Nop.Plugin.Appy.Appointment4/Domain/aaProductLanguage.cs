using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaProductLanguage : BaseEntity
    {
        public new int Id { get; set; }
        public string Language { get; set; }
        public int ProductId { get; set; }
    }
}
