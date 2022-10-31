using CareBookingAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppRepositories.Contracts
{
    public interface  ICarRepository:IGenericRepository<Car>
    {
        Task<Car> GetCarWithDetails(int id);
        Task<List<Car>> GetCarsWithDetails();
        Task<bool> IsNumberPlateExists(string Numberplate);
        Task<bool> IsNumberPlateExistsEdit(string Numberplate, int id);
    }
}
