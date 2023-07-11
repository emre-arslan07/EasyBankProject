using EasyBankProject.ENTITY.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.DAL.Abstract
{
    public interface IRepository<T> where T:class,IEntity,new()
    {
        DbSet<T> Tables { get; }
    }
}
