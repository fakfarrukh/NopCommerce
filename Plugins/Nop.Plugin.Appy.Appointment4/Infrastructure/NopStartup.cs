using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Services;
using Nop.Plugin.Appy.Appointment4.Services.Interface;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Vendors;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Framework;
using System.Runtime.Intrinsics.X86;
using Nop.Web.Areas.Admin.Factories;

namespace Nop.Plugin.Appy.Appointment4.Infrastructure
{
    public class NopStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = DataSettingsManager.LoadSettings().ConnectionString;

            services.AddDbContext<DbContextAppointment>(options =>
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IStateProvinceService, StateProvinceService>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IGenericAttributeService, GenericAttributeService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IStoreContext , WebStoreContext>();
            services.AddScoped<IStoreService ,StoreService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ICustomerActivityService,CustomerActivityService>();
            services.AddScoped<ILocalizationService ,LocalizationService>();
            services.AddScoped<INotificationService ,NotificationService>();
            services.AddScoped<ISettingModelFactory ,SettingModelFactory>();
            services.AddScoped<IaaVendorSettingService, aaVendorSettingService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IaaOrderList, aaOrderListService>();
            services.AddScoped<IOrderModelFactory, OrderModelFactory>();


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
