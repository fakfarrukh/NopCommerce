using Nop.Plugin.Appy.Appointment4.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop_Plugin_Appy_Appointment4.Models {
    static class SampleData {
        public static List<string> bookingPeriods = new List<string>() { "Minutes", "Hours" };


        public static List<BookingRange> bookingRanges = new List<BookingRange>();

        public static List<string> gender = new List<string>() { "Male", "Female" };

        public static List<string> countries = new List<string>() { "USA", "Canda" };
        public static List<string> clinics = new List<string>() { "Clinic 1" , "Clinic 2"};
        public static List<string> cardType = new List<string>() { "National ID", "Passport" , "Resident"};
    }
}
