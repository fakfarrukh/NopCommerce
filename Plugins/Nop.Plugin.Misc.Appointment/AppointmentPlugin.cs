using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Misc.Appointment
{
    public class AppointmentPlugin : BasePlugin,  IWidgetPlugin
    {
        public bool HideInWidgetList => false;

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "MiscAppointment";
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { AdminWidgetZones.VendorDetailsBlock });
        }

        public override Task InstallAsync()
        {
            return base.InstallAsync();
        }


        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override Task UninstallAsync()
        {
            return base.UninstallAsync();
        }
    }
}