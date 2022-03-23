using BH.Gov.FireDepartment.API.Contracts;
using BH.Gov.FireDepartment.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BH.Gov.FireDepartment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private ISensorService _sensorService;

        public SensorsController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSensors()
        {
            var sensors = await _sensorService.GetSensors();

            if (sensors.Any())
            {
                return Ok(sensors);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("activeSensors")]
        public async Task<IActionResult> GetActiveSensors()
        {
            var sensors = await _sensorService.GetSensors();

            if (sensors.Any())
            {
                var activeSensors = sensors.Where(x => x.Active).ToList();
                if (activeSensors.Any())
                {
                    return Ok(activeSensors);
                }
            }
            return NoContent();
        }

        [HttpGet]
        [Route("SensorById")]
        public async Task<IActionResult> GetSensorById(string sensorId)
        {
            var sensors = await _sensorService.GetSensors();

            if (sensors.Any())
            {
                var sensor = sensors.FirstOrDefault(x => x.SensorId.Equals(sensorId));
                if (sensor != null)
                {
                    return Ok(sensor);
                }
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> AddSensor(Sensor sensorRequest)
        {
            if (!ValidateRequest(sensorRequest))
            {
                return BadRequest("Invalid request");
            }
            return Ok("Ok");
        }

        private static bool ValidateRequest(Sensor sensorRequest)
        {
            if (string.IsNullOrEmpty(sensorRequest.SensorId) || string.IsNullOrEmpty(sensorRequest.SensorFriendlyName) || string.IsNullOrEmpty(sensorRequest.SensorLocation))
            {
                return false;
            }
            return true;
        }
    }
}
