using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarPool.Models.Authentication
{
    public class LoginRequest
    {
        [Required]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
