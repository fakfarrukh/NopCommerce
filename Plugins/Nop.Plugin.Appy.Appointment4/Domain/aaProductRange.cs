using AutoMapper.Configuration.Annotations;
using Nop.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaProductRange : BaseEntity
    {
        public new int Id { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thurday { get; set; }
        public bool Friday { get; set; }
        public bool Bookable { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public int Priority { get; set; }
        public int ProductId { get; set;}
        [NotMapped]
        public int? RowNumber { get; set; }
    }
}
