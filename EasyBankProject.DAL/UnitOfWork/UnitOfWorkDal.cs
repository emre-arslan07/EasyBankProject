using EasyBankProject.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.DAL.UnitOfWork
{
    public class UnitOfWorkDal : IUnitOfWorkDal
    {
        private readonly EasyBankProjectDbContext _dbContext;

        public UnitOfWorkDal(EasyBankProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsycn()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
