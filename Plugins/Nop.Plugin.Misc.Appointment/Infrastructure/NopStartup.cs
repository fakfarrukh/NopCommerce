using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Plugin.Misc.Appointment.Services;

namespace Nop.Plugin.Misc.Appointment.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring services on application startup
    /// </summary>
    public class NopStartup : INopStartup
    {

        public void ConfigureServices(IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IVendoreLocationService,
                VendoreLocationService>();
      services.AddScoped<IVendoreInsuranceService,
               VendoreInsuranceService>();
    }

        public void Configure(IApplicationBuilder application)
        {
            
        }


        public int Order => 3000;
    }
}
