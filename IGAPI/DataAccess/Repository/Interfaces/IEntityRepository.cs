using System.Linq.Expressions;
using DataAccess.Entities.Common;

namespace DataAccess.Repository.Interfaces;

public interface IEntityRepository<T> where T : BaseEntity
{
    public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        params Expression<Func<T, object>>[] includeProperties);

    public IEnumerable<T> GetPaged(int pageNumber = 1,
        int pageSize = 25,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        params Expression<Func<T, object>>[] includeProperties);
    
    public T
        GetById(params object[] id); //uses params keyword which allows searching tables with composite primary key.

    public void Insert(T entity);
    public void Update(T entityToUpdate);

    //Deletes the object based on the primary key and uses params to support entities with composite primary key
    public void Delete(params object[] id);
    public void Delete(T entityToDelete);

    public int Count(Expression<Func<T, bool>>? filter = null);
}