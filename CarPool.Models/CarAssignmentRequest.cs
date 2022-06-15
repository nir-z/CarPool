using Newtonsoft.Json;

namespace CarPool.API.Models
{
    public class CarAssignmentRequest
    {
        [JsonProperty("assignmentId")]
        public int AssignmentId { get; set; }

        [JsonProperty("driverId")]
        public int DriverId{ get; set; }

        [JsonProperty("carId")]
        public int CarId { get; set; }

        [JsonProperty("periodOfLease")]
        public byte PeriodOfLease { get; set; }

    }
}
