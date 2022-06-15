using CarPool.API.Models;
using CarPool.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.BL.CarAssignment
{
    public interface ICarAssignmentsManager
    {
        Task<CarLease> AssignCarToDriverAsync(CarAssignmentRequest carAssignmentRequest);
        Task<IList<CarLease>> GetAllLeasesAsync();
    }
}
