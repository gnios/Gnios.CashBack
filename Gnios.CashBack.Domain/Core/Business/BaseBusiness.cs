using AutoMapper;
using Gnios.CashBack.Api.GenericControllers;
using Gnios.CashBack.Api.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gnios.CashBack.Domain.Album
{
    public class BaseBusiness<TEntity, TDto> : IBusiness<TEntity, TDto>
        where TEntity : IEntity
        where TDto : IDto
    {
        public IRepository<TEntity> Repository { get; }
        public IMapper Mapper { get; }

        public BaseBusiness(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual TDto Add(TDto entity)
        {
            var entityMigration = Mapper.Map<TEntity>(entity);
            var response = Repository.Add(entityMigration);
            return Mapper.Map<TDto>(response);
        }

        public virtual long Count()
        {
            return Repository.Count();
        }

        public virtual bool Exists(int id)
        {
            return Repository.Exists(id);
        }

        public virtual IEnumerable<TDto> Find(Expression<Func<TDto, bool>> query)
        {
            var queryMigration = Mapper.Map<Expression<Func<TEntity, bool>>>(query);
            IEnumerable<TEntity> datas = Repository.Find(queryMigration);
            return Mapper.Map<IEnumerable<TDto>>(Repository.Find(queryMigration));
        }

        public virtual TDto Get(int id)
        {
            var response = Repository.Get(id);
            return Mapper.Map<TDto>(response);
        }

        public virtual IEnumerable<TDto> GetAll(OptionsFilter options = null)
        {
            var response = Repository.GetAll(options);
            return Mapper.Map<IEnumerable<TDto>>(response);
        }

        public virtual void Remove(TDto entity)
        {
            var entityMigration = Mapper.Map<TEntity>(entity);
            Repository.Remove(entityMigration);
        }

        public virtual void Remove(int id)
        {
            Repository.Remove(id);
        }

        public virtual TDto Update(TDto entity)
        {
            var entityMigration = Mapper.Map<TEntity>(entity);
            var entityUpdated = Repository.Update(entityMigration);
            return Mapper.Map<TDto>(entityUpdated);
        }
    }
}
