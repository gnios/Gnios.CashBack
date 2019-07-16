using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gnios.CashBack.Api.Persistence
{
    public interface IRepository<TEntity>
    where TEntity : IEntity
    {
        bool Exists(int id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);

        void Remove(int id);

        TEntity Get(int id);

        IQueryable<TEntity> GetAll();

        long Count();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> query);
    }
}
