using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using Nop.Web.Infrastructure;
namespace Nop.Plugin.Misc.Appointment2Appy.Infrastructure
{
    public class RouteProvider : BaseRouteProvider, IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            var lang = GetLanguageRoutePattern();



            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Misc.AppyTwoAppointment",
               "",
                 new { controller = "VendorsStaffs", action = "Index" });
            //endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment2Appy",
            //   pattern: $"{lang}/Secretary/Index",
            //   defaults: new { controller = "Secretary", action = "Index" });
        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 1; //set a value that is greater than the default one in Nop.Web to override routes
    }
}
