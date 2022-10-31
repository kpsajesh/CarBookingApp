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

    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly CarBookingAppDbContext _context;
        public CarRepository(CarBookingAppDbContext context): base(context)
        {
            this._context = context;
        }

        public async Task<List<Car>> GetCarsWithDetails()
        {
            return await _context.Cars
                .Include(q => q.Make)
                .Include(q => q.Style)
                .Include(q => q.CarModel)
               .ToListAsync(); ;
        }

        public async Task<Car> GetCarWithDetails(int id)
        {
            return await _context.Cars
                .Include(q => q.Make)
                .Include(q => q.Style)
                .Include(q => q.CarModel)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
