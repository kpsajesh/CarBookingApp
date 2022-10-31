using CarBookingAppRepositories.Contracts;
using CareBookingAppData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppRepositories.Repositories
{
    public class CarModelRepository : GenericRepository<CarModel>, ICarModelRepository
    {
        private readonly CarBookingAppDbContext _context;

        public CarModelRepository(CarBookingAppDbContext context): base(context)
        {
            this._context = context;
        }       

        public async Task<List<CarModel>> GetCarModelBymake(int makeId)
        {
            var models = await _context.CarModels
                .Where(q => q.MakeId == makeId)
                .ToListAsync();
            return models;
        }

        public Task<CarModel> GetCarModelWithDetail(int id)
        {
            return  _context.CarModels.Include(q => q.Make).FirstOrDefaultAsync(q=> q.Id==id);
        }

        public async Task<List<CarModel>> GetCarsWithDetails()
        {            
            return await _context.CarModels.Include(q => q.Make).ToListAsync();
        }
    }
}
