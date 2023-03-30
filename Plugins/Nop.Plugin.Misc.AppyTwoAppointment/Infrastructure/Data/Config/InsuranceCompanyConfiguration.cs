using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Appy2Appointment.Core.Domain.AppointmentAggregate;

namespace Nop.Plugin.Misc.Appointment2Appy.Infrastructure.Data.Config
{
    public class InsuranceCompanyConfiguration : IEntityTypeConfiguration<InsuranceCompany>
    {
        public void Configure(EntityTypeBuilder<InsuranceCompany> insuranceConfiguration)
        {
            insuranceConfiguration.ToTable("aaInsuranceCompany");

            insuranceConfiguration.HasKey(ct => ct.Id);



            insuranceConfiguration.Property(ct => ct.AName);



            insuranceConfiguration.Property(ct => ct.EName);


        }
    }
}


