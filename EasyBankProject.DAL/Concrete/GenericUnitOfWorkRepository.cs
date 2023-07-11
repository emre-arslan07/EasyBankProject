using EasyBankProject.DAL.Abstract;
using EasyBankProject.DAL.EntityFramework;
using EasyBankProject.ENTITY.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.DAL.Concrete
{
    public class GenericUnitOfWorkRepository<T> : IGenericUnitOfWorkDal<T> where T : class, IEntity, new()
    {
        private readonly EasyBankProjectDbContext _dbContext;

        public GenericUnitOfWorkRepository(EasyBankProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Tables => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry=await Tables.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public Task<bool> AddRangeAsync(List<T> datas)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Tables.FindAsync(id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var query = Tables.AsQueryable();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            var query=Tables.Where(method);
            return query;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry=Tables.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<T> datas)
        {
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry=Tables.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
