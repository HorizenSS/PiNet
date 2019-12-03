using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;


namespace PiDev.ServicePattern
{
    public abstract class Service<T> : IServices<T> where T : class

    {
        IUnitOfWork utwk;

        protected Service(IUnitOfWork utwk)
        {
            this.utwk = utwk;
        }



        public void Add(T entity)
        {
            ////_repository.Add(entity);
            utwk.getRepository<T>().Add(entity);

        }

        public virtual void Update(int id, T entity)
        {
            //_repository.Update(entity);
            utwk.getRepository<T>().Update(id, entity);
        }

        public void Delete(T entity)
        {
            //   _repository.Delete(entity);
            utwk.getRepository<T>().Delete(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            // _repository.Delete(where);
            utwk.getRepository<T>().Delete(where);
        }

        public T GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.getRepository<T>().GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return utwk.getRepository<T>().GetAll();
            //return _repository.GetById(id);
            //  return utwk.getRepository<T>().GetById(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null, Expression<Func<T, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.getRepository<T>().GetMany(filter, orderBy);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            //return _repository.Get(where);
            return utwk.getRepository<T>().Get(where);
        }



        public void Commit()
        {

            utwk.Commit();


        }


        public void Dispose()
        {
            utwk.Dispose();
        }
        public List<T> GetInclude(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            return utwk.getRepository<T>().GetInclude(filter, orderBy, includes);
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            throw new NotImplementedException();
        }

        public void dispose()
        {
            throw new NotImplementedException();
        }
    }

}
