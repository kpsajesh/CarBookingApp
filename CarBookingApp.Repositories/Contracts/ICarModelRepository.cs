using CareBookingAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppRepositories.Contracts
{
    public interface  ICarModelRepository:IGenericRepository<CarModel>
    {
        Task<List<CarModel>> GetCarModelBymake(int makeId);
        Task<List<CarModel>> GetCarsWithDetails();
        Task<CarModel> GetCarModelWithDetail(int id);
    }
}
