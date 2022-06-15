using CarPool.API.Models;
using CarPool.EF.DB;
using CarPool.EF.Models;
using CarPool.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.BL.CarAssignment
{
    public class CarAssignmentsManager: ICarAssignmentsManager
    {
        private readonly CarPoolDbContext _db;

        public CarAssignmentsManager(CarPoolDbContext db)
        {
            _db = db;
        }


        public async Task<IList<CarLease>> GetAllLeasesAsync()
        {

            return await _db.CarLeases
                .Include(c => c.Car)
                .Include(d => d.Driver)
                .ToListAsync();

        }

        public async Task<CarLease> AssignCarToDriverAsync(CarAssignmentRequest carAssignmentRequest)
        {
            if (_db.CarLeases.Any(o => o.Id == carAssignmentRequest.CarId && o.Id == carAssignmentRequest.DriverId))
            {
                throw new AppException()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    PayloadMsg = "Driver is already assigned to this car"
                };
            }

            var newCarLease = new CarLease()
            {
                DriverId = carAssignmentRequest.DriverId,
                CarId = carAssignmentRequest.CarId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(carAssignmentRequest.PeriodOfLease)
            };

           await _db.CarLeases.AddAsync(newCarLease);

           await _db.SaveChangesAsync();

           return newCarLease;

        }
    }
}
