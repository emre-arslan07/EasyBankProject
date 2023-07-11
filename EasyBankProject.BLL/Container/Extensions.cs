using EasyBankProject.BLL.Abstract;
using EasyBankProject.BLL.Concrete;
using EasyBankProject.DAL.Abstract;
using EasyBankProject.DAL.Concrete;
using EasyBankProject.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.BLL.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(IServiceCollection services)
        {
            services.AddScoped<ICustomerAccountDal,EFCustomerAccountDal>();
            services.AddScoped<ICustomerAccountService,CustomerAccountManager>();

            services.AddScoped<ICustomerAccountProcessDal,EFCustomerAccountProcessDal>();
            services.AddScoped<ICustomerAccountProcessService,CustomerAccountProcessManager>();

            services.AddScoped<IUnitOfWorkDal,UnitOfWorkDal>();
        }
    }
}
