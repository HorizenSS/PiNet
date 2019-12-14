using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructures;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
       // private FormationContext ctx = null;
        IDataBaseFactory factory = null;
        public UnitOfWork(IDataBaseFactory factory)
        {
            this.factory = factory;
            //this.ctx = factory.DataContext;
        }
        public void Commit() 
        {
            //ctx.SaveChanges();
           try { 
             factory.DataContext.SaveChanges();
            }catch(Exception e)
            {
                Debug.WriteLine(e.GetBaseException());
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException.Message);
            }


        }

        public void Dispose()
        {
            factory.Dispose();
        }

        public IRepositoryBase<T> GetRepositoryBase<T>() where T : class
        {
            return new RepositoryBase<T>(factory.DataContext);
        }
        
    }
    
}
