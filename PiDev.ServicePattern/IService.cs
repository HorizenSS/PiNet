using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.ServicePattern
{
    public interface IService<T> : IDisposable where T : class
    {
        void Add(T entity);
        void Delete(Expression<Func<T, bool>> condition);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> condition);
        T GetById(long id);
        T GetById(string id);
        // GetMany() ou getMany(param)
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null,
            Expression<Func<T, bool>> orderBy = null);
        void Update(T entity);
        void Commit();
        void DeletebyCondition(Expression<Func<T, bool>> condition);
        //void Dispose(); hidden

    }
}
