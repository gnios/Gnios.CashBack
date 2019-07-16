using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                    _collection = DbContext.Database.GetCollection<TEntity>(collectionName);
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

        public virtual Int64 AddBulk(IEnumerable<TEntity> entity, int chunkSize = 32768) => Collection.Insert(entity);

        public virtual long Count() => Collection.Count();

        public virtual TEntity Get(int id) => Collection.FindById(new BsonValue(id));

        public virtual IQueryable<TEntity> GetAll() => Collection.FindAll().AsQueryable();

        public virtual void Remove(TEntity entity) => Remove(entity.Id);

        public virtual void Remove(int id) => Collection.Delete(new BsonValue(id));

        public virtual TEntity Update(TEntity entity)
        {
            Collection.Update(entity);
            return entity;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> query) => Collection.Find(query).AsQueryable();
    }
}