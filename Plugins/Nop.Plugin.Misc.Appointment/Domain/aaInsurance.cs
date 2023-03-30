using Nop.Core;
using System;
using System.Linq;

namespace Nop.Plugin.Misc.Appointment.Domain
{
    public class aaInsurance : BaseEntity
    {
        public int VendoreId { get; set; }
        public string Title { get; set; }

    }
}
