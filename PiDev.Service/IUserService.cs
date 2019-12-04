using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiDev.ServicePattern;
using PiDev.Domain.Entities;

namespace PiDev.Service
{
    public interface IUserService : IServices<user>
    {
        user FindRoleByName(string name);
    }
}
