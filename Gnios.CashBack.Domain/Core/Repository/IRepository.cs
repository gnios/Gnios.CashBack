using Gnios.CashBack.Api.GenericControllers;
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

        long Count();

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll(OptionsFilter options = null);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> query);
    }
}
