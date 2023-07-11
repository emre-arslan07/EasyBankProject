using EasyBankProject.DAL.Abstract;
using EasyBankProject.DAL.EntityFramework;
using EasyBankProject.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.DAL.Concrete
{
    public class EFCustomerAccountDal:GenericUnitOfWorkRepository<CustomerAccount>,ICustomerAccountDal
    {
        public EFCustomerAccountDal(EasyBankProjectDbContext dbContext):base(dbContext) 
        {

        }
    }
}
