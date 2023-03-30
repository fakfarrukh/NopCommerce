using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop_Plugin_Appy_Appointment4.Models;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataGridApiController : ControllerBase
    {
        private readonly DbContextAppointment _dbContextAppointment;
        public DataGridApiController(DbContextAppointment dbContextAppointment)
        {
            _dbContextAppointment = dbContextAppointment;
        }
        [HttpPost]
        public IActionResult InsertOrder(string values)
        {
            var newOrder = new aaProductLanguage();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();

            _dbContextAppointment.aaProductLanguage.Add(newOrder);
            _dbContextAppointment.SaveChanges();

            return Ok(newOrder);
        }

        //[HttpPut]
        //public IActionResult UpdateOrder(int key, string values)
        //{
        //    var order = _nwind.Orders.First(o => o.OrderID == key);
        //    JsonConvert.PopulateObject(values, order);

        //    if (!TryValidateModel(order))
        //        return BadRequest(ModelState.GetFullErrorMessage());

        //    _nwind.SaveChanges();

        //    return Ok(order);
        //}

        //[HttpDelete]
        //public void DeleteOrder(int key)
        //{
        //    var order = _nwind.Orders.First(o => o.OrderID == key);
        //    _nwind.Orders.Remove(order);
        //    _nwind.SaveChanges();
        //}
    }
}
