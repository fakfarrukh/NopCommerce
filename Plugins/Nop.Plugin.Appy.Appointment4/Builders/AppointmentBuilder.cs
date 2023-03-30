using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Appy.Appointment4.Domain;
using System.Data;

namespace Nop.Plugin.Appy.Appointment4.Builders
{
    public class AppointmentBuilder : NopEntityBuilder<aaAppointment>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //map the primary key (not necessary if it is Id field)
            table.WithColumn(nameof(aaAppointment.Id)).AsInt32().PrimaryKey()
            //map the additional properties as foreign keys
            .WithColumn(nameof(aaAppointment.ProductId)).AsInt32().ForeignKey<Product>(onDelete: Rule.Cascade)
            .WithColumn(nameof(aaAppointment.BookingPeriod)).AsString(500)
            //avoiding truncation/failure
            //so we set the same max length used in the product name
            .WithColumn(nameof(aaAppointment.BookingTimeBlock)).AsString(400)
            //not necessary if we don't specify any rules
            .WithColumn(nameof(aaAppointment.Cancelable)).AsBoolean()
            .WithColumn(nameof(aaAppointment.ConfirmationNeeded)).AsBoolean()
            .WithColumn(nameof(aaAppointment.BookingOpenSooner)).AsDouble()
            .WithColumn(nameof(aaAppointment.BookingOpenLater)).AsDouble();
        }
    }
}
