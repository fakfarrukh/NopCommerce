using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.Wordprocessing;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Plugin.Appy.Appointment4.Models;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Vendors;
using Nop.Web.Areas.Admin.Models.Directory;
using Nop_Plugin_Appy_Appointment4.Models;
using System.Dynamic;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    public class VendorStaffController : Controller
    {
        private readonly DbContextAppointment _dbContextAppointment;
        private readonly IVendorService _vendorService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IGenericAttributeService _genericAttributeService;
        public VendorStaffController(DbContextAppointment dbContextAppointment, IVendorService vendorService, ICustomerService customerService
            , IProductService productService, IGenericAttributeService genericAttributeService)
        {
            _dbContextAppointment = dbContextAppointment;
            _vendorService = vendorService;
            _customerService = customerService;
            _productService = productService;
            _genericAttributeService = genericAttributeService;
        }
        public IActionResult Index()
        {
            Nop.Plugin.Appy.Appointment4.Models.VendorStaff vendorStaff = new Nop.Plugin.Appy.Appointment4.Models.VendorStaff();
            vendorStaff.vendors = _vendorService.GetAllVendorsAsync().Result.ToList();
            //var data = _dbContextAppointment.aaAppointment.ToList();
            return View("~/Plugins/Appy.Appointment4/Views/VendorStaff/Index.cshtml", vendorStaff);
        }
        public IActionResult VendorClinic()
        {
            
            return View("~/Plugins/Appy.Appointment4/Views/VendorStaff/ManageVendorClinic.cshtml");
        }

        [HttpGet]
        public IActionResult LoadClinics(int Id)
        {
            if(Id > 0)
            {
                var lstStaff = _productService.SearchProductsAsync(vendorId: Id).Result.ToList();
                return Json(lstStaff);
            }
            return Json(new List<Core.Domain.Catalog.Product>());            
        }

        [HttpGet]
        public IActionResult LoadCustomer(int Id,DataSourceLoadOptions loadOptions)
        {
            var lstStaff = _customerService.GetAllCustomersAsync().Result.ToList();
            lstStaff = lstStaff.Where(x => x.VendorId == Id).ToList();
            foreach (var item in lstStaff)
            {
                var data = _genericAttributeService.GetAttributesForEntityAsync(item.Id, nameof(Customer)).Result;
                if(data != null)
                {
                    var FirstName = data.Where(z => z.Key == NopCustomerDefaults.FirstNameAttribute).FirstOrDefault();

                    var LastName = data.Where(z => z.Key == NopCustomerDefaults.LastNameAttribute).FirstOrDefault();
                    item.SystemName = FirstName != null ? FirstName.Value : "" + " " + (LastName != null ? LastName.Value : "");
                }
            }
            return Json(lstStaff);
        }

        [HttpPost]
        public IActionResult SaveCustomer(string values)
        {
            var newOrder = new Customer();
            dynamic customerDynamic = new ExpandoObject();
            JsonConvert.PopulateObject(values, customerDynamic);
            newOrder.Id = int.Parse(customerDynamic.Id);
            newOrder.VendorId= int.Parse(customerDynamic.VendorId.ToString());
            newOrder.Email= customerDynamic.Email;
            newOrder.Active = customerDynamic.Active != null ? bool.Parse(customerDynamic.Active) : true;
            if(newOrder.Id > 0)
            {
                var exisitingCustomer = _customerService.GetCustomerByIdAsync(newOrder.Id).Result;
                if(exisitingCustomer != null)
                {
                    exisitingCustomer.VendorId = int.Parse(customerDynamic.VendorId.ToString());
                    exisitingCustomer.Email = customerDynamic.Email;
                    exisitingCustomer.Active = newOrder.Active;
                    _customerService.UpdateCustomerAsync(exisitingCustomer);

                    var data = _genericAttributeService.GetAttributesForEntityAsync(exisitingCustomer.Id, nameof(Customer)).Result;
                    if (data != null)
                    {
                        var FirstName = data.Where(z => z.Key == NopCustomerDefaults.FirstNameAttribute).FirstOrDefault();
                        if(FirstName != null)
                        {
                            FirstName.Value = customerDynamic.CustomerFirstName;
                            _genericAttributeService.UpdateAttributeAsync(FirstName);
                        }
                        else
                        {
                            GenericAttribute genericAttribute = new GenericAttribute();
                            genericAttribute.KeyGroup = nameof(Customer);
                            genericAttribute.Key = NopCustomerDefaults.FirstNameAttribute;
                            genericAttribute.Value= customerDynamic.CustomerFirstName;
                            genericAttribute.EntityId = exisitingCustomer.Id;

                            _genericAttributeService.InsertAttributeAsync(genericAttribute);
                        }
                        

                        var LastName = data.Where(z => z.Key == NopCustomerDefaults.LastNameAttribute).FirstOrDefault();

                        if (LastName != null)
                        {
                            LastName.Value = customerDynamic.CustomerLastName;
                            _genericAttributeService.UpdateAttributeAsync(LastName);
                        }
                        else
                        {
                            GenericAttribute genericAttribute = new GenericAttribute();
                            genericAttribute.KeyGroup = nameof(Customer);
                            genericAttribute.Key = NopCustomerDefaults.LastNameAttribute;
                            genericAttribute.Value = customerDynamic.CustomerLastName;
                            genericAttribute.EntityId = exisitingCustomer.Id;

                            _genericAttributeService.InsertAttributeAsync(genericAttribute);
                        }

                    }
                }
            }
            else
            {
                _customerService.InsertCustomerAsync(newOrder);
                GenericAttribute genericAttribute = new GenericAttribute();
                genericAttribute.KeyGroup = nameof(Customer);
                genericAttribute.Key = NopCustomerDefaults.FirstNameAttribute;
                genericAttribute.Value = customerDynamic.CustomerFirstName;
                genericAttribute.EntityId = newOrder.Id;

                _genericAttributeService.InsertAttributeAsync(genericAttribute);

                GenericAttribute genericLastNameAttribute = new GenericAttribute();
                genericLastNameAttribute.KeyGroup = nameof(Customer);
                genericLastNameAttribute.Key = NopCustomerDefaults.LastNameAttribute;
                genericLastNameAttribute.Value = customerDynamic.CustomerLastName;
                genericLastNameAttribute.EntityId = newOrder.Id;

                _genericAttributeService.InsertAttributeAsync(genericLastNameAttribute);
            }
            return Json("Success");
        }



            #region Language

            [HttpGet]
        public object LoadStaff(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(new List<Customer>(),
                loadOptions
            );
        }
        [HttpPost]
        public IActionResult InsertStaff(string values)
        {
            var newOrder = new Customer();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _customerService.InsertCustomerAsync(newOrder);

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult UpdateStaff(int key, string values)
        {
            var order = _customerService.GetCustomerByIdAsync(key).Result;
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();

            _customerService.UpdateCustomerAsync(order);

            return Ok(order);
        }

        [HttpDelete]
        public void DeleteStaff(int Id)
        {
            var order = _customerService.GetCustomerByIdAsync(Id).Result;
            _customerService.DeleteCustomerAsync(order);
        }

        #endregion


        #region Vendor Clinic

        public IActionResult aaLoadClinics()
        {
            var lstStaff = _productService.SearchProductsAsync().Result.ToList();
            return Json(lstStaff);
        }

        [HttpGet]
        public object aaLoadVendorClinic(int Id , DataSourceLoadOptions loadOptions)
        {
            var lstVendorClinic = _dbContextAppointment.aaVendorStaff.Where(x => x.VendorId == Id).ToList();
            return Json(lstVendorClinic);
            
        }
        [HttpPost]
        public IActionResult aaInsertVendorClinic(string values)
        {
            var newOrder = new aaVendorStaff();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _dbContextAppointment.aaVendorStaff.Add(newOrder);
            _dbContextAppointment.SaveChanges();

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult aaUpdateVendorClinic(int key, string values)
        {
            var order = _dbContextAppointment.aaVendorStaff.First(o => o.Id == key);
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();
            _dbContextAppointment.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        public void aaDeleteVendorClinic(int key)
        {
            var order = _dbContextAppointment.aaVendorStaff.First(o => o.Id == key);
            _dbContextAppointment.aaVendorStaff.Remove(order);
            _dbContextAppointment.SaveChanges();
        }

        #endregion
    }
}
