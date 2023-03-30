using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaProductServiceCategory : BaseEntity
    {
        public new int Id { get; set; }
        public int ServiceCategoryId { get; set; }
        public int ProductId { get; set; }
    }
}
