using CarBookingAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppRepositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity:BaseDomainEntity//TEntity is the Token for table entity
    {
        Task<List<TEntity>> GetAll();// to get a list of data
        Task<TEntity> Get(int id); // To get a list of data againest an Id
        Task<bool> Exists(int id); // To check a rocrd exists based on the given id
        Task Insert(TEntity entity);// To insert a record to a table
        Task Delete(int id);// TO delete a record based on id
        Task Update(TEntity entity);// To Update a record
        Task<int> SaveChanges(); // To save changes after the insert/Update kind of operations
    }
}
