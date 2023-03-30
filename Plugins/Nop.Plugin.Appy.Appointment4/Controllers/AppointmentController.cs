using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Services.Directory;
using Nop_Plugin_Appy_Appointment4.Models;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly DbContextAppointment _dbContextAppointment;
        private readonly ICountryService _countryService;
        public AppointmentController(DbContextAppointment dbContextAppointment, ICountryService countryService)
        {
            _dbContextAppointment = dbContextAppointment;
            _countryService = countryService;
        }

        public aaAppointment? GetAaAppointment(int? Id)
        {
            return _dbContextAppointment.aaAppointment.Where(x => x.ProductId == Id).FirstOrDefault();
        }

        public aaProduct? GetAaProduct(int? Id)
        {
            return _dbContextAppointment.aaproduct.Where(x => x.ProductId == Id).FirstOrDefault();
        }

        public IActionResult Index(int? Id)
        {
            AppointmentModel appointmentModel = new AppointmentModel();
            appointmentModel.BookingPeriods = SampleData.bookingPeriods.ToList();
            appointmentModel.Countries = SampleData.countries.ToList();
            appointmentModel.Gender = SampleData.gender.ToList();
            var aaAppoint = GetAaAppointment(Id);
            var aaProduct = GetAaProduct(Id);
            appointmentModel.aaAppointments = aaAppoint != null ? aaAppoint : new aaAppointment();
            appointmentModel.aaProduct = aaProduct != null ? aaProduct : new aaProduct();
            //var data = _dbContextAppointment.aaAppointment.ToList();
            return View("~/Plugins/Appy.Appointment4/Views/Appointment/Appointment.cshtml", appointmentModel);
        }

        [HttpPost]
        public IActionResult SaveAppointment(string appointmentvalues)
        {
            if (appointmentvalues == null)
            {
                return Json("Error");
            }

            var aaAppointment = new aaAppointment();
            JsonConvert.PopulateObject(appointmentvalues, aaAppointment);
            _dbContextAppointment.aaAppointment.Add(aaAppointment);
            var aaProduct = new aaProduct();
            JsonConvert.PopulateObject(appointmentvalues, aaProduct);
            _dbContextAppointment.aaproduct.Add(aaProduct);
            _dbContextAppointment.SaveChanges();
            return Json("Success");
        }

        #region Language

        [HttpGet]
        public object LoadLanguages(int Id , DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContextAppointment.aaProductLanguage.Where(x => x.ProductId == Id).ToList(),
                loadOptions
            );
        }
        [HttpPost]
        public IActionResult InsertLanguages(string values)
        {
            var newOrder = new aaProductLanguage();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _dbContextAppointment.aaProductLanguage.Add(newOrder);
            _dbContextAppointment.SaveChanges();

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult UpdateLanguages(int key, string values)
        {
            var order = _dbContextAppointment.aaProductLanguage.First(o => o.Id == key);
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();

            _dbContextAppointment.SaveChanges();

            return Ok(order);
        }

        [HttpDelete]
        public void DeleteLanguages(int key)
        {
            var order = _dbContextAppointment.aaProductLanguage.First(o => o.Id == key);
            _dbContextAppointment.aaProductLanguage.Remove(order);
            _dbContextAppointment.SaveChanges();
        }

        #endregion

        #region Service Category

        [HttpGet]
        public object GetServiceCategory(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContextAppointment.aaServiceCatagory.ToList(),
                loadOptions
            );
        }

        [HttpGet]
        public object LoadServiceCategory(int Id, DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContextAppointment.aaProductServiceCategory.Where(x => x.ProductId == Id).ToList(),
                loadOptions
            );
        }
        [HttpPost]
        public IActionResult InsertServiceCategory(string values)
        {
            var newOrder = new aaProductServiceCategory();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _dbContextAppointment.aaProductServiceCategory.Add(newOrder);
            _dbContextAppointment.SaveChanges();

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult UpdateServiceCategory(int key, string values)
        {
            var order = _dbContextAppointment.aaProductServiceCategory.First(o => o.Id == key);
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();

            _dbContextAppointment.SaveChanges();

            return Ok(order);
        }

        [HttpDelete]
        public void DeleteServiceCategory(int key)
        {
            var order = _dbContextAppointment.aaProductServiceCategory.First(o => o.Id == key);
            _dbContextAppointment.aaProductServiceCategory.Remove(order);
            _dbContextAppointment.SaveChanges();
        }

        #endregion

        #region Appointment Ranges

        [HttpGet]
        public object LoadAppointmentRanges(int Id, DataSourceLoadOptions loadOptions)
        {
            var lstBookingRange = _dbContextAppointment.aaProductRange.Where(x => x.ProductId == Id).ToList();
            for (int i = 0; i < lstBookingRange.Count; i++)
            {
                lstBookingRange[i].RowNumber = i + 1;
            }
            return DataSourceLoader.Load(lstBookingRange,
                loadOptions
            );
        }
        [HttpPost]
        public IActionResult InsertAppointmentRanges(string values)
        {
            var newOrder = new aaProductRange();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();
            _dbContextAppointment.aaProductRange.Add(newOrder);
            _dbContextAppointment.SaveChanges();

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult UpdateAppointmentRanges(int key, string values)
        {
            var order = _dbContextAppointment.aaProductRange.First(o => o.Id == key);
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest();

            _dbContextAppointment.SaveChanges();

            return Ok(order);
        }

        [HttpDelete]
        public void DeleteAppointmentRanges(int key)
        {
            var order = _dbContextAppointment.aaProductRange.First(o => o.Id == key);
            _dbContextAppointment.aaProductRange.Remove(order);
            _dbContextAppointment.SaveChanges();
        }

        #endregion

        [HttpGet]
        public object LoadBookingDropdown(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(SampleData.bookingPeriods.ToList(),
                loadOptions
            );
        }

        [HttpGet]
        public object LoadGenderDropdown(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(SampleData.gender.ToList(),
                loadOptions
            );
        }

        [HttpGet]
        public object LoadNationlityDropdown(DataSourceLoadOptions loadOptions)
        {
            var lstCountry = _countryService.GetAllCountriesAsync().Result;
            return DataSourceLoader.Load(lstCountry,
                loadOptions
            );
        }
    }
}
