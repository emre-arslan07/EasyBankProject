using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.BLL.Abstract
{
    public interface IGenericUnitOfWorkService<T>
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        Task<bool> Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        Task<bool> Update(T model);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        //Task<T> GetSingleNameMailAsync(UserLogin user);
        Task<T> GetByIdAsync(int id);
    }
}
