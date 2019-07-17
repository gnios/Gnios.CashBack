using Gnios.CashBack.Api.GenericControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gnios.CashBack.Api.Persistence
{
    public interface IBusiness<TEntity, TDto>
    where TEntity : IEntity
    where TDto : IDto
    {
        bool Exists(int id);

        TDto Add(TDto entity);

        TDto Update(int id, TDto recurso);

        void Remove(TDto entity);

        void Remove(int id);

        long Count();

        TDto Get(int id);

        IEnumerable<TDto> GetAll(OptionsFilter options = null);

        IEnumerable<TDto> Find(Expression<Func<TDto, bool>> query);
    }
}
