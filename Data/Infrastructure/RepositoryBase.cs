using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Data.Infrastructure
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        MyDBContext ctx;
        readonly DbSet<T> dbset;
        public RepositoryBase(IDataBaseFactory Factory)
        {
            ctx = Factory.Ctxt;
            dbset = ctx.Set<T>();
        }
        public void Add(T Entity)
        {
            dbset.Add(Entity);
        }

        public void Commit()
        {
            ctx.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> Condition)
        {
            IEnumerable<T> query = dbset.Where(Condition);
            if (query != null)
            {
                foreach (T entity in query)
                    dbset.Remove(entity);

            }
        }

        public void Delete(T Entity)
        {
            dbset.Remove(Entity);
        }

        public T GetById(string id)
        {
            return dbset.Find(id);
        }


        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> Condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            IQueryable<T> query = dbset;
            if (Condition != null)
                query = query.Where(Condition);
            if (orderBy != null)
                query = query.OrderBy(orderBy);
            return query.AsEnumerable();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public void Update(T Entity)
        {
            dbset.Attach(Entity);
            ctx.Entry<T>(Entity).State = EntityState.Modified;
        }
    }
}
