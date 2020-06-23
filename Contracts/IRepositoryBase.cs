using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
    // generic repository that will serve all the CRUD methods
    // this interface will be implemented and injected as a service to be used by many controllers for many models
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
