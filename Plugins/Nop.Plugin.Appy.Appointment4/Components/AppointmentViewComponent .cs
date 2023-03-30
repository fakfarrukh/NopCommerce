using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Appy.Appointment4.Services.Interface;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Appy.Appointment4.Components
{
    public class AppointmentViewComponent : NopViewComponent
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IAppointmentService _appointmentService;
        private readonly IWorkContext _workContext;

        public AppointmentViewComponent(ICustomerService customerService,
            IProductService productService,
            IAppointmentService appointmentService,
            IWorkContext workContext)
        {
            _customerService = customerService;
            _productService = productService;
            _appointmentService = appointmentService;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {

            if ((additionalData is Nop.Web.Areas.Admin.Models.Vendors.VendorModel model))
            {


                return View("~/Plugins/Misc.Appointment/Views/VendorLocation/Location.cshtml", model);

            }
            else
            { return Content(""); }
        }
    }
}
