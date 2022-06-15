using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Models
{
    public class NewDriverRequest
    {
        [JsonProperty("liscenseNumber")]
        public string LiscenseNumber{ get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }


    }
}
