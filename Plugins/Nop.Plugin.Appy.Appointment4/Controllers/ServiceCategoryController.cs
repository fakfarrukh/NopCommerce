using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Services.Directory;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    public class ServiceCategoryController : Controller
    {
        private readonly DbContextAppointment _dbContextAppointment;
        public ServiceCategoryController(DbContextAppointment dbContextAppointment)
        {
            _dbContextAppointment = dbContextAppointment;
        }
            public IActionResult Index()
        {
            return View("~/Plugins/Appy.Appointment4/Views/Service Category/Index.cshtml");
        }
        #region Service Category


        [HttpGet]
        public object aaLoadServiceCategory(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContextAppointment.aaServiceCatagory.ToList(),
                loadOptions
            );
        }
        [HttpPost]
        public IActionResult aaInsertServiceCategory(string values)
        {
            var newOrder = new aaServiceCatagory();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _dbContextAppointment.aaServiceCatagory.Add(newOrder);
            _dbContextAppointment.SaveChanges();

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult aaUpdateServiceCategory(int key, string values)
        {
            var order = _dbContextAppointment.aaServiceCatagory.First(o => o.Id == key);
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();
            _dbContextAppointment.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        public void aaDeleteServiceCategory(int key)
        {
            var order = _dbContextAppointment.aaServiceCatagory.First(o => o.Id == key);
            _dbContextAppointment.aaServiceCatagory.Remove(order);
            _dbContextAppointment.SaveChanges();
        }

        #endregion
    }
}
