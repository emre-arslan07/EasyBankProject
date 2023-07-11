using EasyBankProject.BLL.Abstract;
using EasyBankProject.DAL.Abstract;
using EasyBankProject.DAL.UnitOfWork;
using EasyBankProject.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.BLL.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _customerAccountDal = customerAccountDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(CustomerAccount model)
        {
            await _customerAccountDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveAsycn()>=1)
            {
                return true;
            }
            else { return false; }
        }

        public Task<bool> AddRangeAsync(List<CustomerAccount> datas)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerAccount> GetByIdAsync(int id)
        {
           return await _customerAccountDal.GetByIdAsync(id);
        }

        public async Task<CustomerAccount> GetSingleAsync(Expression<Func<CustomerAccount, bool>> method)
        {
            return await _customerAccountDal.GetSingleAsync(method);
        }

        public IQueryable<CustomerAccount> GetWhere(Expression<Func<CustomerAccount, bool>> method)
        {
            return _customerAccountDal.GetWhere(method);
        }

        public async Task<bool> Remove(CustomerAccount model)
        {
            _customerAccountDal.Remove(model);
            if (await _unitOfWorkDal.SaveAsycn()>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<CustomerAccount> datas)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CustomerAccount model)
        {
            _customerAccountDal.Update(model);
            if (await _unitOfWorkDal.SaveAsycn()>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
