using CarPool.EF.Models;
using CarPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.BL.Drivers
{
    public interface IDriversManager
    {

        Task<IList<Driver>> GetAllDriversAsync();

        Task<Driver> AddNewDriverAsync(NewDriverRequest newDriverRequest);
    }
}
