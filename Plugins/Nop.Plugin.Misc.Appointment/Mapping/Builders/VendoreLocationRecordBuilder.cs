using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Customers;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.Appointment.Domain;
using Nop.Data.Extensions;
using System.Data;
namespace Nop.Plugin.Misc.Appointment.Mapping.Builders;

public class VendoreLocationRecordBuilder : NopEntityBuilder<aaVendor>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(aaVendor.Id)).AsInt32().PrimaryKey()
        .WithColumn(nameof(aaVendor.VendoreId)).AsInt32().ForeignKey<Vendor>(onDelete: Rule.Cascade)
        .WithColumn(nameof(aaVendor.ParrentVendor)).AsInt32().ForeignKey<Vendor>(onDelete: Rule.Cascade)
        .WithColumn(nameof(aaVendor.Latitude)).AsString(400)
        .WithColumn(nameof(aaVendor.Longitude)).AsString(400);
 
    }
}
public class VendoreInsuranceBuilder : NopEntityBuilder<aaInsurance>
{
  public override void MapEntity(CreateTableExpressionBuilder table)
  {
    table.WithColumn(nameof(aaInsurance.Id)).AsInt32().PrimaryKey()
    .WithColumn(nameof(aaInsurance.VendoreId)).AsInt32().ForeignKey<Vendor>(onDelete: Rule.Cascade)
    .WithColumn(nameof(aaInsurance.Title)).AsString(400);


  }
}
