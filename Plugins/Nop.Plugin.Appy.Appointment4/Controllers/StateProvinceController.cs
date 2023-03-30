using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.Wordprocessing;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Plugin.Appy.Appointment4.Models;
using Nop.Services.Directory;
using Nop.Web.Areas.Admin.Models.Directory;
using Nop_Plugin_Appy_Appointment4.Models;
using System.Dynamic;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    public class StateProvinceController : Controller
    {
        private readonly DbContextAppointment _dbContextAppointment;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ICountryService _countryService;
        public StateProvinceController(DbContextAppointment dbContextAppointment, IStateProvinceService stateProvinceService, ICountryService countryService)
        {
            _dbContextAppointment = dbContextAppointment;
            _stateProvinceService = stateProvinceService;
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            Nop.Plugin.Appy.Appointment4.Models.StateProvince aaStateProvince = new Nop.Plugin.Appy.Appointment4.Models.StateProvince();
            //var data = _dbContextAppointment.aaAppointment.ToList();
            return View("~/Plugins/Appy.Appointment4/Views/StateProvince/Index.cshtml", aaStateProvince);
        }

        [HttpPost]
        public async Task<IActionResult> SaveStateProvince(string stateProvinceValues)
        {
            var stateProvince = new StateProvince();
            JsonConvert.PopulateObject(stateProvinceValues, stateProvince);
            Nop.Core.Domain.Directory.StateProvince stateProvinceModel = new Nop.Core.Domain.Directory.StateProvince();
            stateProvinceModel.Name = stateProvince.Name;
            stateProvinceModel.DisplayOrder = stateProvince.DisplayOrder;
            stateProvinceModel.Abbreviation = stateProvince.Abbreviation;
            stateProvinceModel.Published = stateProvince.IsPublished;
            stateProvinceModel.CountryId = stateProvince.CountryId;
            stateProvinceModel.Id = stateProvince.Id;
            if (stateProvince.Id > 0)
            {
                var id = _stateProvinceService.UpdateStateProvinceAsync(stateProvinceModel);
                var aastate = _dbContextAppointment.aaStateProvince.Where(x => x.StateProvinceID == stateProvince.Id).FirstOrDefault();
                if (aastate != null)
                {
                    aastate.ArabicName = stateProvince.ArabicName;
                    _dbContextAppointment.aaStateProvince.Update(aastate);
                }
                else
                {
                    aaStateProvince aaStateProvince = new aaStateProvince();
                    aaStateProvince.ArabicName = stateProvince.ArabicName;
                    aaStateProvince.StateProvinceID = stateProvinceModel.Id;
                    _dbContextAppointment.aaStateProvince.Add(aaStateProvince);
                    _dbContextAppointment.SaveChanges();
                }

            }
            else
            {
                var id = _stateProvinceService.InsertStateProvinceAsync(stateProvinceModel);
                aaStateProvince aaStateProvince = new aaStateProvince();
                aaStateProvince.ArabicName = stateProvince.ArabicName;
                aaStateProvince.StateProvinceID = stateProvinceModel.Id;
                _dbContextAppointment.aaStateProvince.Add(aaStateProvince);
                _dbContextAppointment.SaveChanges();

            }
            return Json("Success");
        }

        public IActionResult LoadStateProvincebyId(int Id)
        {
            if (Id > 0)
            {
                var stateProvienceResult = _stateProvinceService.GetStateProvinceByIdAsync(Id).Result;
                if (stateProvienceResult != null)
                {
                    dynamic dynmaicState = new ExpandoObject();
                    dynmaicState.stateProvience = stateProvienceResult;
                    var aaState = _dbContextAppointment.aaStateProvince.Where(x => x.StateProvinceID == stateProvienceResult.Id).FirstOrDefault();
                    dynmaicState.Arabic = aaState != null ? aaState.ArabicName : "";
                    return Json(dynmaicState);
                }
            }
            return Json("error");
        }

        [HttpGet]
        public async Task<object> GetCountries(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(await _countryService.GetAllCountriesAsync(), loadOptions);
        }
        [HttpPost]
        public IActionResult GetStateProvience(int CountryId)
        {
            var stateProvienceList = _stateProvinceService.GetStateProvincesByCountryIdAsync(CountryId).Result;
            return Json(stateProvienceList);

        }
    }
}
