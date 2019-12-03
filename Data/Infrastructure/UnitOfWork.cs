using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        IDataBaseFactory Factory;
        public UnitOfWork(IDataBaseFactory factory)
        {
            Factory = factory;
        }
        public void Commit()
        {
            Factory.Ctxt.SaveChanges();
        }

        public void Dispose()
        {
            Factory.Dispose();
        }

        public IRepositoryBase<T> GetRepositoryBase<T>() where T : class
        {
            return new RepositoryBase<T>(Factory);
        }
    }
}
