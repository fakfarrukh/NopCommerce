using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Domain;

namespace Nop_Plugin_Appy_Appointment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextAppointment _dbContextAppointment;
        public HomeController(DbContextAppointment dbContextAppointment)
        {
            _dbContextAppointment = dbContextAppointment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View("~/Plugins/Appy.Appointment4/Views/Home/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View();
        }

        
    }
}
