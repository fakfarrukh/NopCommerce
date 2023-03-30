using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Misc.AppyTwoAppointment.Infrastructure.Data;

namespace Nop.Plugin.Misc.AppyTwoAppointment.Controllers
{
    public class ProductServiceCategoryController : Controller
    {
        private readonly Appointment2Appy_db_Context _db;

        public ProductServiceCategoryController(Appointment2Appy_db_Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return
              View("~/Plugins/Misc.AppyTwoAppointment/Views/ProductServiceCategory/Index.cshtml");

        }
    
        [HttpGet]

        public object GetProductServiceCategory(DataSourceLoadOptions loadOptions)

        {

            List<Models.AppyAppointmentModel.ProductServiceCategory> vm = new List<Models.AppyAppointmentModel.ProductServiceCategory>();

            vm = _db.ProductServiceCategory.ToList();


            return DataSourceLoader.Load(vm, loadOptions);

        }
       


        [HttpPost]
        public IActionResult Post(string values)
        {
            var newProductServiceCategory = new Models.AppyAppointmentModel.ProductServiceCategory();
            JsonConvert.PopulateObject(values, newProductServiceCategory);

            //if (!TryValidateModel(newVendorStaff ))
            //    return BadRequest(ModelState.GetValueOrDefault());

            _db.ProductServiceCategory.Add(newProductServiceCategory);
            _db.SaveChanges();

            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var productServiceCategory = _db.ProductServiceCategory.First(a => a.Id == key);
            JsonConvert.PopulateObject(values, productServiceCategory);

            //if (!TryValidateModel(VendorStaff ))
            //    return BadRequest(ModelState.GetFullErrorMessage());

            _db.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var productServiceCategory = _db.ProductServiceCategory.First(a => a.Id == key);
            _db.ProductServiceCategory.Remove(productServiceCategory);
            _db.SaveChanges();
        }
    }
}

