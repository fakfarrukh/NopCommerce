using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Web.Areas.Admin.Models.Directory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop_Plugin_Appy_Appointment4.Models {
    public class AppointmentModel
    {
        public IEnumerable<string> BookingPeriods { get; set; }
        public IEnumerable<string> Gender { get; set; }
        public IEnumerable<BookingRange> bookingRanges { get; set; }
        public IEnumerable<string> Countries { get; set; }
        public IEnumerable<aaProductLanguage> appointmentLanguages { get; set; }
        public IEnumerable<aaProductServiceCategory> appointmentServiceCategories { get; set; }
        public aaAppointment aaAppointments { get; set; }

        public aaProduct aaProduct { get; set; }
    }   
   
}
