using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.EF.Models
{
    public class Driver: Employee
    {
        public string LicenseNumber { get; set; }

        public CarLease Lease { get; set; }
        public int? LeaseId { get; set; }
    }
}
