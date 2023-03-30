using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    public class InsuranceCompaniesController : Controller
    {
        private readonly DbContextAppointment _dbContextAppointment;
        public InsuranceCompaniesController(DbContextAppointment dbContextAppointment)
        {
            _dbContextAppointment = dbContextAppointment;
        }
            public IActionResult Index()
        {
            return View("~/Plugins/Appy.Appointment4/Views/Insurance Companies/Index.cshtml");
        }
        #region Insurance Company
        [HttpGet]
        public object aaLoadInsuranceCompany(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContextAppointment.aaInsuranceCompany.ToList(),
                loadOptions
            );
        }
        [HttpPost]
        public IActionResult aaInsertInsuranceCompany(string values)
        {
            var newOrder = new aaInsuranceCompany();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _dbContextAppointment.aaInsuranceCompany.Add(newOrder);
            _dbContextAppointment.SaveChanges();

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult aaUpdateInsuranceCompany(int key, string values)
        {
            var order = _dbContextAppointment.aaInsuranceCompany.First(o => o.Id == key);
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();
            _dbContextAppointment.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        public void aaDeleteInsuranceCompany(int key)
        {
            var order = _dbContextAppointment.aaInsuranceCompany.First(o => o.Id == key);
            _dbContextAppointment.aaInsuranceCompany.Remove(order);
            _dbContextAppointment.SaveChanges();
        }

#endregion
    
    }
}
