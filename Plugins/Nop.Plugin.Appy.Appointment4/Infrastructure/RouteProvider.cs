using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis;
using Nop.Plugin.Appy.Appointment4.Domain;
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
            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4",
               pattern: "Appointment/Index",
               defaults: new { controller = "Appointment", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.Booking",
              pattern: "Admin/Appointment",
              defaults: new { controller = "Appointment", action = "LoadAppointmentRanges" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.InsertBooking",
              pattern: "Admin/Appointment",
              defaults: new { controller = "Appointment", action = "InsertAppointmentRanges" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.UpdateBooking",
  pattern: "Admin/Appointment",
  defaults: new { controller = "Appointment", action = "UpdateAppointmentRanges" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.DeleteBooking",
  pattern: "Admin/Appointment",
  defaults: new { controller = "Appointment", action = "DeleteAppointmentRanges" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.BookingRange",
  pattern: "Admin/Appointment/LoadBookingDropdown",
  defaults: new { controller = "Appointment", action = "LoadBookingDropdown" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.Gender",
  pattern: "Admin/Appointment/LoadGenderDropdown",
  defaults: new { controller = "Appointment", action = "LoadGenderDropdown" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.Nationality",
  pattern: "Admin/Appointment/LoadNationlityDropdown",
  defaults: new { controller = "Appointment", action = "LoadNationlityDropdown" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.GetStatesByCountryId",
                pattern: $"country/getstatesbycountryid/",
                defaults: new { controller = "Country", action = "GetStatesByCountryId" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.VendorSetting",
              pattern: $"Admin/VendorStaff/LoadaaVendorSetting",
              defaults: new { controller = "VendorStaff", action = "LoadaaVendorSetting" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.aaVendor",
  pattern: $"Admin/aaVendor/LoadVendors",
  defaults: new { controller = "aaVendor", action = "LoadVendors" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.VendorSettingLoadVendorSetting",
pattern: $"Admin/VendorStaff/LoadVendorSetting",
defaults: new { controller = "VendorStaff", action = "LoadVendorSetting" });


            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.GetOrderDetails",
    pattern: $"Admin/OrderAppointment/aaOrderDetails",
    defaults: new { controller = "OrderAppointment", action = "aaOrderDetails" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.VendorSetting",
 pattern: $"Admin/Setting/Vendor",
 defaults: new { controller = "Setting", action = "Vendor" });

            #region Appointment Languages
            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.LanguageBooking",
              pattern: "Admin/Appointment/LoadLanguages",
              defaults: new { controller = "Appointment", action = "LoadLanguages" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.InsertLanguagesBooking",
              pattern: "Admin/Appointment/InsertLanguages",
              defaults: new { controller = "Appointment", action = "InsertLanguages" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.UpdateLanguageBooking",
  pattern: "Admin/Appointment/UpdateLanguages",
  defaults: new { controller = "Appointment", action = "UpdateLanguages" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.DeleteLanguageBooking",
  pattern: "Admin/Appointment/DeleteLanguages",
  defaults: new { controller = "Appointment", action = "DeleteLanguages" });
            #endregion

            #region Appointment Service Category
            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.ServiceCategoryDropdown",
            pattern: "Admin/Appointment/GetServiceCategory",
            defaults: new { controller = "Appointment", action = "GetServiceCategory" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.ServiceCategoryBooking",
              pattern: "Admin/Appointment/LoadServiceCategory",
              defaults: new { controller = "Appointment", action = "LoadServiceCategory" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.InsertServiceCategoryBooking",
              pattern: "Admin/Appointment/InsertServiceCategory",
              defaults: new { controller = "Appointment", action = "InsertServiceCategory" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.UpdateServiceCategoryBooking",
  pattern: "Admin/Appointment/UpdateServiceCategory",
  defaults: new { controller = "Appointment", action = "UpdateServiceCategory" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.DeleteServiceCategoryBooking",
  pattern: "Admin/Appointment/DeleteServiceCategory",
  defaults: new { controller = "Appointment", action = "DeleteServiceCategory" });
            #endregion

            #region Vendor Insurance

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.VendorInsuranceDropdown",
            pattern: "Admin/aaVendor/LoadInsuranceCompanies",
            defaults: new { controller = "aaVendor", action = "LoadInsuranceCompanies" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.LoadVendorInsruance",
              pattern: "Admin/aaVendor/LoadVendorInsruance",
              defaults: new { controller = "aaVendor", action = "LoadVendorInsruance" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.InsertVendorInsruance",
              pattern: "Admin/aaVendor/InsertVendorInsruance",
              defaults: new { controller = "aaVendor", action = "InsertVendorInsruance" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.UpdateVendorInsruance",
  pattern: "Admin/aaVendor/UpdateVendorInsruance",
  defaults: new { controller = "aaVendor", action = "UpdateVendorInsruance" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.DeleteVendorInsruance",
  pattern: "Admin/aaVendor/DeleteVendorInsruance",
  defaults: new { controller = "aaVendor", action = "DeleteVendorInsruance" });

            #endregion

            #region Vendor Staff

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.InsertVendorStaff",
              pattern: "VendorStaff/aaInsertVendorClinic",
              defaults: new { controller = "VendorStaff", action = "aaInsertVendorClinic" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.UpdateVendorStaff",
  pattern: "VendorStaff/aaUpdateVendorClinic",
  defaults: new { controller = "VendorStaff", action = "aaUpdateVendorClinic" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.DeleteVendorStaff",
  pattern: "VendorStaff/aaDeleteVendorClinic",
  defaults: new { controller = "VendorStaff", action = "aaDeleteVendorClinic" });

            #endregion


            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.State",
              pattern: "StateProvince/Index",
              defaults: new { controller = "StateProvince", action = "Index" });
            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.Vendor",
              pattern: "VendorStaff/Index",
              defaults: new { controller = "VendorStaff", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.CustomerRelative",
              pattern: "CustomerRelative/Index",
              defaults: new { controller = "CustomerRelative", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.aaServiceCategory",
             pattern: "ServiceCategory/Index",
             defaults: new { controller = "ServiceCategory", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.aaInsuranceCompany",
             pattern: "InsuranceCompanies/Index",
             defaults: new { controller = "InsuranceCompanies", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "Plugin.Appointment4.VendorStaff",
             pattern: "VendorStaff/VendorClinic",
             defaults: new { controller = "VendorStaff", action = "VendorClinic" });
        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 1; //set a value that is greater than the default one in Nop.Web to override routes
    }
}
