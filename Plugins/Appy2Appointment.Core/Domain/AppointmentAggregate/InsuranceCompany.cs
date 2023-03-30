using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy2Appointment.Core.Domain.AppointmentAggregate
{
    public  class InsuranceCompany
    {
        public InsuranceCompany(string aName,
       string eName
       )
        {
            AName = aName;
            EName = eName;

        }
        [Key]
        public int Id { get; set; }
        public string AName { get; set; }
        public string EName { get; set; }
    }
}

