using Nop.Core;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaProduct : BaseEntity
    {
        public new int Id { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public bool HomeVisit { get; set;}
        public bool PhoneCall { get; set;}
        public bool VirtualConf { get; set;}
        public int ProductId { get; set;}
    }
}
