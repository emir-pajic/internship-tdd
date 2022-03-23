using Newtonsoft.Json;

namespace BH.Gov.FireDepartment.API.Model
{
    public class Sensor
    {
        public Sensor()
        {

        }

        [JsonProperty("SensorId")]
        public string SensorId { get; set; }

        [JsonProperty("SensorFriendlyName")]
        public string SensorFriendlyName { get; set; }

        [JsonProperty("SensorLocation")]
        public string SensorLocation { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }
    }
}
