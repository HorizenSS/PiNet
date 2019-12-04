using PiDev.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Service
{
    public interface IUserService : IService<user>
    {
        user FindRoleByName(string name);
    }

}
