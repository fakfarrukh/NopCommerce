using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaStateProvince : BaseEntity
    {
        public new int Id { get; set; }
        public string ArabicName { get; set; }
        public int StateProvinceID { get; set; }
    }
}
