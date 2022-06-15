using CarPool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.EF.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public ColorsEnums Color { get; set; }
        public Manufacturer Manufacturer { get; set; } 
        public int ManufacturerId { get; set; }

        public CarLease Lease { get; set; }
        public int? LeaseId { get; set; }
    }
}