using System.Linq.Expressions;
using DataAccess.Entities.Common;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Repository.Common;

public class BaseRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
{
    private readonly IServiceScopeFactory _scopeFactory;

    public BaseRepository(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var dbSet = context.Set<TEntity>();

        IQueryable<TEntity> query = dbSet;

        if (filter != null) query = query.Where(filter);

        foreach (var includeProperty in includeProperties) query = query.Include(includeProperty);
        
        return orderBy != null ? orderBy(query).ToList() : query.ToList();
    }


    public virtual IEnumerable<TEntity> GetPaged(int pageNumber = 1,
        int pageSize = 25,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var dbSet = context.Set<TEntity>();

        IQueryable<TEntity> query = dbSet;
        
        if (filter != null) query = query.Where(filter);

        foreach (var includeProperty in includeProperties) query = query.Include(includeProperty);
        
        query = orderBy != null ? orderBy(query) : query;
        
        return query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToList();
    }

    public virtual int Count(Expression<Func<TEntity, bool>>? filter = null)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var dbSet = context.Set<TEntity>();
        IQueryable<TEntity> query = dbSet;

        if (filter != null) query = query.Where(filter);
        
        return query.Count();
    }
    
    public virtual TEntity GetById(params object[] id)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var dbSet = context.Set<TEntity>();
        
        return dbSet.Find(id);
    }

    public virtual void Insert(TEntity entity)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var dbSet = context.Set<TEntity>();
        
        dbSet.Add(entity);
        context.SaveChanges();
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var dbSet = context.Set<TEntity>();
        
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
        context.SaveChanges();

        //// test2
        // TEntity existing = _context.Set<TEntity>().Find(entityToUpdate.Id);
        // if (existing != null)
        // {
        //     _context.Entry(existing).CurrentValues.SetValues(entityToUpdate);
        //     _context.SaveChanges();
        // }
        
        //// test3
        // TEntity existing = _context.Set<TEntity>().Find(entityToUpdate.Id);
        // if (existing != null)
        // {
        //     _context.Entry(existing).State = EntityState.Detached;
        // }
        // _dbSet.Attach(entityToUpdate);
        // _context.Entry(entityToUpdate).State = EntityState.Modified;
        // _context.SaveChanges();
    }

    public virtual void Delete(params object[] id)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var dbSet = context.Set<TEntity>();
        
        var entityToDelete = dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TradingAppContext>();
        var dbSet = context.Set<TEntity>();
        
        if (context.Entry(entityToDelete).State == EntityState.Detached) dbSet.Attach(entityToDelete);
        dbSet.Remove(entityToDelete);
        context.SaveChanges();

    }
    
}