using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepositoryBase<T> GetRepositoryBase<T>() where T : class;
        void Commit();
        void Dispose();
    }
}
