using System.Linq.Expressions;
using BMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BMS.Infrastructure.Persistence.Repositories;

public interface IRepository<TEntity, TContext> where TEntity : BaseEntity
    where TContext : DbContext
{
    TEntity Get(Expression<Func<TEntity, bool>> predicate);

    IList<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
}