using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy2Appointment.Core.Domain.AppointmentAggregate
{
    public class VendorStaff
    {
        private VendorStaff()
        {
            
        }
        public VendorStaff(int vendorID,
          int customerId, int productID, bool manage
          )
        {
            VendorId = vendorID;
            CustomerId = customerId;
            ProductId = productID;
            Manage = manage;
        }
        [Key]
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public bool Manage { get; set; }

    


    }
}

