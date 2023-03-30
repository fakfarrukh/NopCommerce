using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Services.Vendors;
using Nop_Plugin_Appy_Appointment4.Models;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    public class aaVendorController : Controller
    {
        private readonly DbContextAppointment _dbContextAppointment;
        private readonly IVendorService _vendorService;
        public aaVendorController(DbContextAppointment dbContextAppointment, IVendorService vendorService)
        {
            _dbContextAppointment = dbContextAppointment;
            _vendorService = vendorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Vendor Details
        public object LoadVendors(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_vendorService.GetAllVendorsAsync().Result.ToList(),
               loadOptions
           );
        }

        public virtual async Task<IActionResult> LoadaaVendor(int VendorId)
        {
            try
            {
                var result = _dbContextAppointment.aaVendor.Where(x => x.VendoreId == VendorId).FirstOrDefault();
                return Json(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpPost]
        public virtual async Task<IActionResult> AddUpdate(string model)
        {
            try
            {
                var aaVendorModel = new aaVendor();
                JsonConvert.PopulateObject(model, aaVendorModel);
                var data = _dbContextAppointment.aaVendor.Where(x => x.VendoreId == aaVendorModel.VendoreId).FirstOrDefault();
                if (data != null)
                {
                    data.Longitude = aaVendorModel.Longitude;
                    data.Latitude = aaVendorModel.Latitude;
                    data.ParrentVendor = aaVendorModel.ParrentVendor;
                    _dbContextAppointment.aaVendor.Update(data);
                }
                else
                {
                    aaVendor aaVendor = new aaVendor();
                    aaVendor.Latitude = aaVendorModel.Longitude;
                    aaVendor.Longitude = aaVendorModel.Longitude;
                    aaVendor.ParrentVendor = aaVendorModel.ParrentVendor;
                    aaVendor.VendoreId= aaVendorModel.VendoreId;

                    _dbContextAppointment.aaVendor.Add(aaVendor);
                }

                var result = _dbContextAppointment.SaveChanges();
                //await _vendorSettingService.InsertVendorSettingAsync(aaVendor);

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion

        #region Service Category

        [HttpGet]
        public object LoadInsuranceCompanies(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContextAppointment.aaInsuranceCompany.ToList(),
                loadOptions
            );
        }

        [HttpGet]
        public object LoadVendorInsruance(int Id, DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContextAppointment.aaVendorInsurances.Where(x => x.VendorId == Id).ToList(),
                loadOptions
            );
        }
        [HttpPost]
        public IActionResult InsertVendorInsruance(string values)
        {
            var newOrder = new aaVendorInsurance();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _dbContextAppointment.aaVendorInsurances.Add(newOrder);
            _dbContextAppointment.SaveChanges();

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult UpdateVendorInsruance(int key, string values)
        {
            var order = _dbContextAppointment.aaVendorInsurances.First(o => o.Id == key);
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();

            _dbContextAppointment.SaveChanges();

            return Ok(order);
        }

        [HttpDelete]
        public void DeleteVendorInsruance(int key)
        {
            var order = _dbContextAppointment.aaVendorInsurances.First(o => o.Id == key);
            _dbContextAppointment.aaVendorInsurances.Remove(order);
            _dbContextAppointment.SaveChanges();
        }

        #endregion
    }
}
