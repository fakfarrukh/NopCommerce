using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;
using Nop.Core;
using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Appy.Appointment4.Domain
{
    public class aaCustomerRelative : BaseEntity
    {
        public new int Id { get; set; }
        public string CardId { get; set; }
        public string CardType { get; set; }
        public string ArabicName { get; set;}
        public string EnglishName { get; set;}
        public DateTime BirthDate { get; set;}
        
        public int CustomerId { get; set; }
    }
}
