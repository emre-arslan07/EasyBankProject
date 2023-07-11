using EasyBankProject.BLL.Abstract;
using EasyBankProject.DAL.Abstract;
using EasyBankProject.DAL.Concrete;
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
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(CustomerAccountProcess model)
        {
            await _customerAccountProcessDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveAsycn() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public Task<bool> AddRangeAsync(List<CustomerAccountProcess> datas)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAccountProcess> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAccountProcess> GetSingleAsync(Expression<Func<CustomerAccountProcess, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CustomerAccountProcess> GetWhere(Expression<Func<CustomerAccountProcess, bool>> method)
        {
            return _customerAccountProcessDal.GetWhere(method);
        }

        public async Task<bool> Remove(CustomerAccountProcess model)
        {
             _customerAccountProcessDal.Remove(model);
            if (await _unitOfWorkDal.SaveAsycn() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<CustomerAccountProcess> datas)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CustomerAccountProcess model)
        {
            _customerAccountProcessDal.Update(model);
            if (await _unitOfWorkDal.SaveAsycn() >= 1)
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

