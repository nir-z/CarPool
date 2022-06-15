using CarPool.EF.Models;
using CarPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.BL.Cars
{
    public interface ICarsManager
    {
        Task<Car> AddNewCarAsync(NewCarRequest newCarRequest);

        Task<IList<Car>> GetAllCarsAsync();
    }
}
