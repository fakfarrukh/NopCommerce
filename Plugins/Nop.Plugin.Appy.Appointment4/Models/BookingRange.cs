using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop_Plugin_Appy_Appointment4.Models {
    public class BookingRange
    {
        public int BookingRangeId { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thurday { get; set; }
        public bool Friday { get; set; }
        public bool Bookable { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public int Priority { get; set; }
    }
}
