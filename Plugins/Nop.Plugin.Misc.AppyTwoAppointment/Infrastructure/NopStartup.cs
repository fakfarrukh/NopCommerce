using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Plugin.Misc.AppyTwoAppointment.Infrastructure.Data;

namespace Nop.Plugin.Misc.AppyTwoAppointment.Infrastructure
{
    public class NopStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = DataSettingsManager.LoadSettings().ConnectionString;

            services.AddDbContext<Appointment2Appy_db_Context>(options =>
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
         

        }
        public void Configure(IApplicationBuilder application)
        {


            using (var scope = application.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;


            }
        }
        public int Order => 3000;
    }



}
