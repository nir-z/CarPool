using CarPool.BL.Drivers;
using CarPool.EF.DB;
using CarPool.EF.Models;
using CarPool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPool.BL.Drivers
{
    public class DriversManager: IDriversManager
    {
        private readonly CarPoolDbContext _db;

        public DriversManager(CarPoolDbContext db)
        {
            _db = db;
        }


        public async Task<IList<Driver>> GetAllDriversAsync()
        {
            return await _db.Drivers
                .Include(l => l.Lease).ToListAsync();
        }

        public async Task<Driver> AddNewDriverAsync(NewDriverRequest newDriverRequest)
        {

            var newDriver =
                new Driver
                {
                    FirstName = newDriverRequest.FirstName,
                    LicenseNumber = newDriverRequest.LiscenseNumber
                };

            await _db.Drivers.AddAsync(newDriver);
            await _db.SaveChangesAsync();

            return newDriver;
        }
    }
}
