namespace Nop.Plugin.Appy.Appointment4.Models
{
    public class StateProvince
    {
        public new int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsPublished { get; set; }
        public int DisplayOrder { get; set; }
        public string ArabicName { get; set; }
        public int StateProvinceID { get; set; }
        public int CountryId { get; set; }
    }
}
