
using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.Appointment.Domain;

namespace Nop.Plugin.Misc.Appointment.Migrations;

[NopMigration("2022/12/19 22:38:55:1687541", "Misk.Appointment base schema", MigrationProcessType.Installation)]
public class SchemaMigration : AutoReversingMigration
{
    public override void Up()
    {
        Create.TableFor<aaVendor>();
        Create.TableFor<aaInsurance>();
  }
}
