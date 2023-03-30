using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Misc.AppyTwoAppointment.Infrastructure.Data;

namespace Nop.Plugin.Misc.AppyTwoAppointment.Controllers
{
    public class InsuranceCompanyController : Controller
    {
        private readonly Appointment2Appy_db_Context _db;

        public InsuranceCompanyController(Appointment2Appy_db_Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return
              View("~/Plugins/Misc.AppyTwoAppointment/Views/InsuranceCompany/Index.cshtml");

        }

        [HttpGet]

        public object GetInsuranceCompany(DataSourceLoadOptions loadOptions)

        {

            List<Models.AppyAppointmentModel.InsuranceCompany> vm = new List<Models.AppyAppointmentModel.InsuranceCompany>();

            vm = _db.InsuranceCompany.ToList();


            return DataSourceLoader.Load(vm, loadOptions);

        }



        [HttpPost]
        public IActionResult Post(string values)
        {
            var newInsuranceCompany = new Models.AppyAppointmentModel.InsuranceCompany();
            JsonConvert.PopulateObject(values, newInsuranceCompany);

       

            _db.InsuranceCompany.Add(newInsuranceCompany);
            _db.SaveChanges();

            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var InsuranceCompany = _db.InsuranceCompany.First(a => a.Id == key);
            JsonConvert.PopulateObject(values, InsuranceCompany);

       

            _db.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var InsuranceCompany = _db.InsuranceCompany.First(a => a.Id == key);
            _db.InsuranceCompany.Remove(InsuranceCompany);
            _db.SaveChanges();
        }
    }
}


