using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Misc.AppyTwoAppointment.Infrastructure.Data;
using Nop.Plugin.Misc.AppyTwoAppointment.Models.AppyAppointmentModel;
using System.Collections.Generic;

namespace Nop.Plugin.Misc.AppyTwoAppointment.Controllers
{
    public class VendorsStaffsController : Controller
    {
        private readonly Appointment2Appy_db_Context _db;
      
        public VendorsStaffsController(Appointment2Appy_db_Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
      
            return
              View("~/Plugins/Misc.AppyTwoAppointment/Views/VendorsStaffs/Index.cshtml");

        }
    
        [HttpGet]

        public object GetVendorStaffs(DataSourceLoadOptions loadOptions)

        {

            List<Models.AppyAppointmentModel.VendorStaff> vm = new List<Models.AppyAppointmentModel.VendorStaff>();

            vm = _db.VendorStaffs.ToList();


            return DataSourceLoader.Load(vm, loadOptions);

        }
       [HttpPost]
        public object selectBoxVendor(int id)
        {
            SessionHelper.Config.Application["VID"] = id.ToString();

            return SessionHelper.Config.Application["VID"];
            //return Json(SessionHelper.Config.Application["VID"]);
        }
        [HttpGet]
        public List<Vendor> GetVendors()
         {

            List<Vendor> vendor = new List<Vendor>();

            vendor = _db.Vendor.ToList();


            return vendor;
        }
        [HttpGet]
        public List<Product> GetProducts()
        {

            List<Product> product = new List<Product>();

            product = _db.Product.ToList();


            return product;
        }
        [HttpGet]
        public async Task<IActionResult> VendorStaffList()
        {
            return
             View("~/Plugins/Misc.AppyTwoAppointment/Views/VendorsStaffs/VendorStaffList.cshtml");

        }

     
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newVendorStaff  = new Models.AppyAppointmentModel.VendorStaff();
            newVendorStaff.VendorId = Convert.ToInt32(SessionHelper.Config.Application["VID"]);
            JsonConvert.PopulateObject(values, newVendorStaff );
           
            //if (!TryValidateModel(newVendorStaff ))
            //    return BadRequest(ModelState.GetValueOrDefault());

            _db.VendorStaffs.Add(newVendorStaff );
            _db.SaveChanges();

            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Guid key, string values)
        {
            var vendorStaff  = _db.VendorStaffs.First(a => a.Id == key);
            vendorStaff.VendorId = Convert.ToInt32(SessionHelper.Config.Application["VID"]);
            JsonConvert.PopulateObject(values, vendorStaff );

            //if (!TryValidateModel(VendorStaff ))
            //    return BadRequest(ModelState.GetFullErrorMessage());

            _db.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public void Delete(Guid key)
        {
            var vendorStaff  = _db.VendorStaffs.First(a => a.Id == key);
            _db.VendorStaffs.Remove(vendorStaff );
            _db.SaveChanges();
        }
    }
}
