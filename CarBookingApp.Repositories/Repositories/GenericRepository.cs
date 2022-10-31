using CarBookingAppData;
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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDomainEntity
    {
        private readonly CarBookingAppDbContext _context;
        private readonly DbSet<TEntity> _db;

        public GenericRepository(CarBookingAppDbContext context)
        {
            this._context = context; // Connection to the entire Database
            _db = _context.Set<TEntity>(); // Set creates DbSet relative to TEntity, ie to the specific table instructed while calling
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await _db.ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _db.AnyAsync(e => e.Id==id);
        }

        public async Task Insert(TEntity entity)
        {
            await _db.AddAsync(entity);
            await SaveChanges();
        }
        
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id); //Finds the record based on given id
            _db.Remove(entity); // Delete the found record
            await SaveChanges();
        }
        public async Task Update(TEntity entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }      

        public async Task<int> SaveChanges()
        {
            foreach(var entry in _context.ChangeTracker.Entries<BaseDomainEntity>().Where(q=> q.State==EntityState.Added)) 
            {
                entry.Entity.CreatedDate = DateTime.Now;
            }
            foreach (var entry in _context.ChangeTracker.Entries<BaseDomainEntity>().Where(q => q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedDate = DateTime.Now;
            }
            foreach (var entry in _context.ChangeTracker.Entries<BaseDomainEntity>().Where(q => q.State == EntityState.Deleted))
            {
                //entry.Entity.UpdatedDate = DateTime.Now;
            }
            return await _context.SaveChangesAsync();
        }        
    }
}
