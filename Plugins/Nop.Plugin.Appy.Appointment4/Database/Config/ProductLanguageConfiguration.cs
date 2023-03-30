using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nop_Plugin_Appy_Appointment4.Models;

namespace Nop.Plugin.Appy.Appointment4.Database.Config
{
    public class ProductLanguageConfiguration : IEntityTypeConfiguration<AppointmentLanguage>
    {
        public void Configure(EntityTypeBuilder<AppointmentLanguage> insuranceConfiguration)
        {
            insuranceConfiguration.ToTable("aaProductLanguage");
            insuranceConfiguration.HasKey(ct => ct.AppointmentLanguageId);
            insuranceConfiguration.Property(ct => ct.AppointmentLanguageName);
        }
    }
}


