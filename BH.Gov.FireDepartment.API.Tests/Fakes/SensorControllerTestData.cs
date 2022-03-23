using BH.Gov.FireDepartment.API.Model;
using System.Collections.Generic;

namespace BH.Gov.FireDepartment.API.Tests.Fakes
{
    public class SensorControllerTestData
    {
        public List<Sensor> GetAllSensorsPopulated()
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

        public List<Sensor> GetAllSensorsEmpty()
        {
            return new List<Sensor>();
        }

        public List<Sensor> GetActiveSensorsPopulated()
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
        public Sensor GetInvalidSensorRequest()
        {
            return new Sensor()
            {
                SensorId = "",
                SensorFriendlyName = "",
                SensorLocation = "",
            };
        }
        public Sensor GetValidSensorRequest()
        {
            return new Sensor()
            {
                SensorId = "KO_12134HHGS",
                SensorFriendlyName = "KO",
                SensorLocation = "Konjic",
            };
        }
    }
}
