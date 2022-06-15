using CarPool.EF.Models;
using CarPool.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Models
{
    public class NewCarRequest
    {
        [JsonProperty("liscenseNumber")]
        public string LiscenseNumber { get; set; }

        [JsonProperty("color")]
        public ColorsEnums Color { get; set; }

        [JsonProperty("manufacturerId")]
        public int ManufacturerId { get; set; }
    }
}
