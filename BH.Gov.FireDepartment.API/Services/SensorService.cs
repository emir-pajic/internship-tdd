using BH.Gov.FireDepartment.API.Contracts;
using BH.Gov.FireDepartment.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BH.Gov.FireDepartment.API.Services
{
    public class SensorService : ISensorService
    {
        public async Task<List<Sensor>> GetSensors()
        {
            return new List<Sensor>()
            {
                new Sensor()
                {
                    SensorId = "MOFBIH_1234ST01",
                    SensorFriendlyName = "MOFBIH",
                    SensorLocation = "Mostar",
                    Active = true
                },
                new Sensor()
                {
                    SensorId = "SAFBIH_1234ST01",
                    SensorFriendlyName = "MOFBIH",
                    SensorLocation = "Sarajevo",
                    Active = false
                },
            };
        }
    }
}
