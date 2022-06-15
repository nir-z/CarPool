using CarPool.EF.DB;
using CarPool.EF.Models;
using CarPool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.BL.Cars
{
    public class CarsManager: ICarsManager
    {
        private readonly CarPoolDbContext _db;

        public CarsManager(CarPoolDbContext db)
        {
            _db = db;
        }

        public async Task<Car> AddNewCarAsync(NewCarRequest newCarRequest)
        {

            var newCar =
                new Car
                {
                    ManufacturerId = newCarRequest.ManufacturerId,
                    LicenseNumber = newCarRequest.LiscenseNumber
                };

            await _db.Cars.AddAsync(newCar);
            await _db.SaveChangesAsync();

            return newCar;
        }


        public async Task<IList<Car>> GetAllCarsAsync()
        {
            return await _db.Cars
                .Include(x => x.Manufacturer)
                .Include(x => x.Lease)
                .ToListAsync();
        }
    }
}
