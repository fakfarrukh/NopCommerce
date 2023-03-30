using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// Represents a state/province
    /// </summary>
    public class aaProduct : BaseEntity
    {
        public new int Id { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public bool HomeVisit { get; set; }
        public bool PhoneCall { get; set; }
        public bool VirtualConf { get; set; }
        public int ProductId { get; set; }
    }
}
