using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Appy.Appointment4.Domain;

namespace Nop.Plugin.Appy.Appointment4.Migrations
{    
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<aaAppointment>();
            Create.TableFor<aaStateProvince>();
        }
    }
}
