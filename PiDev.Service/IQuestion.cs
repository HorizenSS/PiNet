using PiDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Service
{
    public interface IQuestion
    {
        List<reponse> reponseD(int id);
    }
}
