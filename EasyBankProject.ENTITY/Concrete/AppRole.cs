using EasyBankProject.ENTITY.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.ENTITY.Concrete
{
    public class AppRole:IdentityRole<int>,IEntity
    {

    }
}
