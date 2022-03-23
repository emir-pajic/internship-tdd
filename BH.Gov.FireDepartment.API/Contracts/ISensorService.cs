using BH.Gov.FireDepartment.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BH.Gov.FireDepartment.API.Contracts
{
    public interface ISensorService
    {
        Task<List<Sensor>> GetSensors();
    }
}
