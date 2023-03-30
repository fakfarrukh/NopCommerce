using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Core.Domain.Customers;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Plugin.Appy.Appointment4.Models;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Vendors;
using Nop.Web.Areas.Admin.Models.Directory;
using Nop_Plugin_Appy_Appointment4.Models;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    public class CustomerRelativeController : Controller
    {
        private readonly DbContextAppointment _dbContextAppointment;
        private readonly ICustomerService _customerService;
        private readonly IGenericAttributeService _genericAttributeService;
        public CustomerRelativeController(DbContextAppointment dbContextAppointment, ICustomerService customerService, IGenericAttributeService genericAttributeService)
        {
            _dbContextAppointment = dbContextAppointment;
            _customerService = customerService;
            _genericAttributeService = genericAttributeService;
        }
        
        public IActionResult Index()
        {            
            return View("~/Plugins/Appy.Appointment4/Views/CustomerRelatives/Index.cshtml");
        }
        [HttpGet]
        public object GetCustomers(DataSourceLoadOptions loadOptions)
        {
            var lstStaff = _customerService.GetAllCustomersAsync().Result.ToList();
            foreach (var item in lstStaff)
            {
                var data = _genericAttributeService.GetAttributesForEntityAsync(item.Id, nameof(Customer)).Result;
                if (data != null)
                {
                    var FirstName = data.Where(z => z.Key == NopCustomerDefaults.FirstNameAttribute).FirstOrDefault();

                    var LastName = data.Where(z => z.Key == NopCustomerDefaults.LastNameAttribute).FirstOrDefault();
                    item.SystemName = FirstName != null ? FirstName.Value : "" + " " + (LastName != null ? LastName.Value : "");
                }
            }
            return DataSourceLoader.Load(lstStaff,
                loadOptions
            );
        }

        [HttpGet]
        public object GetCardType(DataSourceLoadOptions loadOptions)
        {            
            return DataSourceLoader.Load(SampleData.cardType.ToList(),
                loadOptions
            );
        }
        #region Customer Relative CRUD

        [HttpGet]
        public IActionResult Load(int Id)
        {
            var lstStaff = _dbContextAppointment.aacustomerrelative.Where(x=>x.CustomerId == Id).ToList();
            
            return Json(lstStaff);
        }
        [HttpPost]
        public IActionResult Insert(string values)
        {
            var newOrder = new aaCustomerRelative();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _dbContextAppointment.aacustomerrelative.Add(newOrder);
            _dbContextAppointment.SaveChanges();
            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult UpdateStaff(int Id, string values)
        {
            var order = _dbContextAppointment.aacustomerrelative.Where(x=>x.Id == Id).FirstOrDefault();
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();

            _dbContextAppointment.aacustomerrelative.Update(order);
            _dbContextAppointment.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        public void DeleteStaff(int Id)
        {
            var order = _dbContextAppointment.aacustomerrelative.Where(x => x.Id == Id).FirstOrDefault();
            _dbContextAppointment.aacustomerrelative.Remove(order);
            _dbContextAppointment.SaveChanges();
        }

        #endregion
    }
}
