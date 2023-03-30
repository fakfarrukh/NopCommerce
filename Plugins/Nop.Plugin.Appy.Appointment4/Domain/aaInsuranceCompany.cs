using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaInsuranceCompany : BaseEntity
    {
        public new int Id { get; set; }
        public string? InsuranceEnglishName { get; set; }
        public string? InsuranceArabicName { get; set; }
    }
}
