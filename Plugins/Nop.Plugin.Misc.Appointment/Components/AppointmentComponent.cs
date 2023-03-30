using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.Appointment.Domain;
using Nop.Plugin.Misc.Appointment.Services;
using Nop.Services.Vendors;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;
using System;

namespace Nop.Plugin.Misc.Appointment.Components;

/// <summary>
/// Represents view component to embed tracking script on pages
/// </summary>
[ViewComponent(Name = "MiscAppointment")]
public class AppointmentComponent : NopViewComponent
{
    #region Fields

    private readonly IVendorService _vendorService;
    private readonly IVendoreLocationService _vendorLocationService;

    private readonly IWorkContext _workContext;

    public AppointmentComponent(IVendorService vendorService, IVendoreLocationService vendorLocationService, IWorkContext workContext)
    {
        _vendorService = vendorService;
        _vendorLocationService = vendorLocationService;
        _workContext = workContext;
    }


    #endregion

    #region Methods




    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {

        if ((additionalData is Nop.Web.Areas.Admin.Models.Vendors.VendorModel model))
        {


            return View("~/Plugins/Misc.Appointment/Views/VendorLocation/Location.cshtml", model);

        }
        else
        { return Content(""); }
    }

    #endregion
}