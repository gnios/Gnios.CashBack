using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Gnios.CashBack.Api.GenericControllers;
using LiteDB;

namespace Gnios.CashBack.Api.Persistence.Repository.LiteDB
{
    [Serializable]
    public class LiteDBRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private ILiteDBContext DbContext { get; set; }
        private LiteCollection<TEntity> _collection;

        private LiteCollection<TEntity> Collection
        {
            get
            {
                if (_collection == null)
                {
                    var collectionName = typeof(TEntity).Name;
                    _collection = DbContext.Repository.Database.GetCollection<TEntity>(collectionName);
                }
                return _collection;
            }
        }

        private string keyName = "_id";

        public LiteDBRepository(ILiteDBContext liteDBContext)
        {
            this.DbContext = liteDBContext;
        }

        public virtual bool Exists(int id)
        {
            return Collection.Exists(Query.EQ(keyName, new BsonValue(id)));
        }

        public virtual TEntity Add(TEntity entity)
        {
            Collection.Insert(entity);
            return entity;
        }

        public virtual Int64 Add(IEnumerable<TEntity> entities) => Collection.Insert(entities);

        public virtual Int64 AddBulk(IEnumerable<TEntity> entity) => Collection.Insert(entity);

        public virtual long Count() => Collection.Count();


        public virtual void Remove(TEntity entity) => Remove(entity.Id);

        public virtual void Remove(int id) => Collection.Delete(new BsonValue(id));

        public virtual TEntity Update(TEntity entity)
        {
            Collection.Update(entity);
            return entity;
        }

        public virtual TEntity Get(int id) => Collection.FindById(new BsonValue(id));

        public virtual IEnumerable<TEntity> GetAll(OptionsFilter options = null)
        {
            if (options == null)
            {
                return Collection.FindAll();
            }

            LiteQueryable<TEntity> queryDB = DbContext.Repository.Query<TEntity>();

            if (options.id_like != null)
            {
                foreach (var item in options.id_like)
                {
                    queryDB = queryDB.Where(x => options.id_like.Contains(x.Id.ToString()));
                }
            }

            if (options._filter != null)
            {
                var listPredicate = Filter.ByQueryParams<TEntity>(options);
                foreach (var predicate in listPredicate)
                {
                    queryDB = queryDB.Where(predicate);
                }
            }

            if (options._take != null)
            {
                queryDB = queryDB.Limit(int.Parse(options._take));
            }

            if (options._skip != null)
            {
                queryDB = queryDB.Skip(int.Parse(options._skip));
            }

            if (options._page != null)
            {
                var take = string.IsNullOrEmpty(options._take) ? 10 : int.Parse(options._take);
                var page = (int.Parse(options._page) - 1) * take;

                queryDB = queryDB.Skip(page).Limit(take);
            }

            if (options._sort != null)
            {
                return Filter.Sort(options, queryDB.ToList());
            }

            return queryDB.ToEnumerable();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> query)
        {
            return DbContext.Repository.Query<TEntity>().Where(query).ToList();
        }
    }
}