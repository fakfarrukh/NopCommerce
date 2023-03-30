using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Appy2Appointment.Core.Domain.AppointmentAggregate;

namespace Nop.Plugin.Misc.Appointment2Appy.Infrastructure.Data.Config
{
    public class  ProductServiceCategoryConfiguration : IEntityTypeConfiguration<ProductServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ProductServiceCategory> insuranceConfiguration)
        {
            insuranceConfiguration.ToTable("aaProductServiceCategory");

            insuranceConfiguration.HasKey(ct => ct.Id);



            insuranceConfiguration.Property(ct => ct.AName);



            insuranceConfiguration.Property(ct => ct.EName);
          

        }
    }
}

