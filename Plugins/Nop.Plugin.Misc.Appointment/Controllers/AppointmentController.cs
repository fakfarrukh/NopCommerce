using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.Appointment.Domain;
using Nop.Plugin.Misc.Appointment.Services;
using Nop.Services.Vendors;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.Appointment.Controllers
{
    public partial class AppointmentController:BaseController
    {

    private readonly IVendorService _vendoreService;
    private readonly IVendoreInsuranceService _venoreInsuranceService;

private readonly IVendoreLocationService _vendoreLocationService;

    public AppointmentController(IVendoreLocationService vendoreLocationService, IVendorService vendoreService, IVendoreInsuranceService venoreInsuranceService)
    {
      _vendoreLocationService = vendoreLocationService;
      _vendoreService = vendoreService;
      _venoreInsuranceService = venoreInsuranceService;
    }

    [HttpPost]
        public async Task<IActionResult> SaveLocation(aaVendor record)
        {

             _vendoreLocationService.Save(record);


            return Ok("Saved");
             

        }

        [HttpGet]
        public async Task<IActionResult> Location(int Id)
        {

           var model=await _vendoreLocationService.GetByVendor(Id);

      if(model!=null)
            return Ok(model);
      else { return NotFound(); }


        }
    [HttpGet]
    public async Task<IActionResult> Vendors(int Id)
    {
      var model = await _vendoreService.GetAllVendorsAsync();
      return Ok(model);
    }
    [HttpGet]
    public async Task<IActionResult> InsuranceList(int vendorId)
    {
      var model = await _venoreInsuranceService.GetAllByVendorId(vendorId);
      return Ok(model);
    }
    [HttpPost]
    public async Task<IActionResult> AddInsurance(aaInsurance insurance)
    {
      await _venoreInsuranceService.Save(insurance);
      return Ok("Saved");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveInsurance(int id)
    {
      await _venoreInsuranceService.RemoveAsync(id);
      return Ok("Deleted");
    }

  }
}
