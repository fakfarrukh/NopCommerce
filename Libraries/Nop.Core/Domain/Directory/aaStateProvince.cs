using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// Represents a state/province
    /// </summary>
    public class aaStateProvince : BaseEntity
    {
        public new int Id { get; set; }
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
        public string ArabicName { get; set; }
        public int StateProvinceID { get; set; }
    }
}
