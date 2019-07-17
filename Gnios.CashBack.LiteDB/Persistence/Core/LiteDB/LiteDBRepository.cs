using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Gnios.CashBack.Api.GenericControllers;
using Gnios.CashBack.Api.Spotify;
using LiteDB;

namespace Gnios.CashBack.Api.Persistence.Repository.LiteDB
{
    [Serializable]
    public class LiteDBRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private string groupCacheKey;

        private ILiteDBContext DbContext { get; set; }
        public MemoryCacheService MemoryCache { get; }

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

        public LiteDBRepository(ILiteDBContext liteDBContext, MemoryCacheService memoryCache)
        {
            this.DbContext = liteDBContext;
            MemoryCache = memoryCache;
            groupCacheKey = typeof(TEntity).FullName;
        }

        public virtual bool Exists(int id)
        {
            return Collection.Exists(Query.EQ(keyName, new BsonValue(id)));
        }

        public virtual TEntity Add(TEntity entity)
        {
            MemoryCache.ClearCacheGroup(groupCacheKey);
            Collection.Insert(entity);
            return entity;
        }

        public virtual Int64 Add(IEnumerable<TEntity> entities)
        {
            MemoryCache.ClearCacheGroup(groupCacheKey);
            return Collection.Insert(entities);
        }

        public virtual Int64 AddBulk(IEnumerable<TEntity> entity)
        {
            MemoryCache.ClearCacheGroup(groupCacheKey);
            return Collection.Insert(entity);
        }

        public virtual long Count() => Collection.Count();

        public virtual void Remove(TEntity entity)
        {
            MemoryCache.ClearCacheGroup(groupCacheKey);
            Remove(entity.Id);
        }

        public virtual void Remove(int id)
        {
            MemoryCache.ClearCacheGroup(groupCacheKey);
            Collection.Delete(new BsonValue(id));
        }

        public virtual TEntity Update(int id, TEntity entity)
        {
            MemoryCache.ClearCacheGroup(groupCacheKey);
            entity.Id = id;
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

            MethodBase method = MethodBase.GetCurrentMethod();

            var key = $"{typeof(TEntity).FullName}-{method.Name}-{options.VersionObject}";

            return MemoryCache.GetOrCreate(
                   groupCacheKey, key, 3600,
                   (cacheEntry) =>
                   {
                       return GetAllCached(options);
                   });
        }

        private IEnumerable<TEntity> GetAllCached(OptionsFilter options)
        {
            LiteQueryable<TEntity> queryDB = DbContext.Repository.Query<TEntity>();

            if (options.id_like != null)
            {
                foreach (var item in options.id_like)
                {
                    queryDB = queryDB.Where(x => options.id_like.Contains(x.Id.ToString()));
                }
            }

            if (options._filter != null && options._filter.Count > 0)
            {
                var listPredicate = Filter.ByQueryParams<TEntity>(options);
                foreach (var predicate in listPredicate)
                {
                    queryDB = queryDB.Where(predicate);
                }
            }

            if (options._take != 0)
            {
                queryDB = queryDB.Limit(options._take);
            }

            if (options._skip != 0)
            {
                queryDB = queryDB.Skip(options._skip);
            }

            if (options._page != 0)
            {
                var take = options._take == 0 ? 10 : options._take;
                var page = (options._page - 1) * take;

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
            MethodBase method = MethodBase.GetCurrentMethod();
            var queryMD5 = HelperMD5.ComputeHash(HelperMD5.ObjectToByteArray(query));
            var key = $"{typeof(TEntity).FullName}-{method.Name}-{queryMD5}";
            return MemoryCache.GetOrCreate(
                   groupCacheKey, key, 3600,
                   (cacheEntry) =>
                   {
                       return DbContext.Repository.Query<TEntity>().Where(query).ToList();
                   });

        }
    }
}