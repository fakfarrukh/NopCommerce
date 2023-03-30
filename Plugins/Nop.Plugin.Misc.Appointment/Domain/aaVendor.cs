using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Misc.Appointment.Domain
{
    public class aaVendor : BaseEntity
    {
        public int VendoreId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int ParrentVendor  { get; set; }
    }
}
