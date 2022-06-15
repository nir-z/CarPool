using CarPool.API.Models;
using CarPool.BL;
using CarPool.BL.CarAssignment;
using CarPool.BL.Cars;
using CarPool.BL.Drivers;
using CarPool.EF.Models;
using CarPool.Models;
using CarPool.Models.Consts.Authentication;
using CarPool.Models.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarPool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarPoolController : ControllerApiBase
    {

        private readonly ILogger<CarPoolController> _logger;
        private readonly IDriversManager _driverManager;
        private readonly ICarAssignmentsManager _carAssignmentsManager;
        private readonly ICarsManager _carsManager;

        public CarPoolController(
            ILogger<CarPoolController> logger,
            IDriversManager driverManager,
            ICarAssignmentsManager carAssignmentsManager,
            ICarsManager carsManager)
        {
            _logger = logger;
            _driverManager = driverManager;
            _carAssignmentsManager = carAssignmentsManager;
            _carsManager = carsManager;
        }


        [HttpGet("/drivers")]
        [Authorize(AuthenticationSchemes = AuthConsts.ASYMETRIC)]
        public async Task<ActionResult<IList<Driver>>> GetDrivers()
        {
            try
            {
                var drivers = await _driverManager.GetAllDriversAsync();

                return Ok(drivers);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResult(ex);
            }
        }

        [HttpPost("/drivers")]
        [Authorize(AuthenticationSchemes = AuthConsts.ASYMETRIC)]
        public async Task<ActionResult<Driver>> AddDriver(NewDriverRequest newDriverRequest)
        {
            try
            {
                var driver = await _driverManager.AddNewDriverAsync(newDriverRequest);

                return Ok(driver);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResult(ex);
            }
        }


        [HttpGet("/carlease")]
        [Authorize(AuthenticationSchemes = AuthConsts.ASYMETRIC)]
        public async Task<ActionResult<CarLease>> GetAllLeases()
        {
            try
            {
                var leases = await _carAssignmentsManager.GetAllLeasesAsync();

                return Ok(leases);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResult(ex);
            }
        }

        [HttpPost("/carlease")]
        [Authorize(AuthenticationSchemes = AuthConsts.ASYMETRIC)]
        public async Task<ActionResult<CarLease>> AssignCarToDriver([FromBody] CarAssignmentRequest newCarAssignmentRequest) 
        {
            try
            {
                var drivers = await _carAssignmentsManager.AssignCarToDriverAsync(newCarAssignmentRequest);

                return Ok(drivers);
            }
            catch (AppException ae)
            {
                return StatusCode(ae.StatusCode, new { data = ae.PayloadMsg });
            }
            catch (Exception ex)
            {
                return InternalServerErrorResult(ex);
            }
        }

        [HttpPost("/cars")]
        [Authorize(AuthenticationSchemes = AuthConsts.ASYMETRIC)]
        public async Task<ActionResult<CarLease>> AddCar([FromBody] NewCarRequest newCarRequest)
        {
            try
            {
                var car = await _carsManager.AddNewCarAsync(newCarRequest);

                return Ok(car);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResult(ex);
            }
        }

        [HttpGet("/cars")]
        [Authorize(AuthenticationSchemes = AuthConsts.ASYMETRIC)]
        public async Task<ActionResult<Car>> GetAllCars()
        {
            try
            {
                var cars = await _carsManager.GetAllCarsAsync();

                return Ok(cars);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResult(ex);
            }
        }
    }
}
