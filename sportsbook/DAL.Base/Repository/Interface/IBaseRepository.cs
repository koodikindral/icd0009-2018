using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Base.Entity;

namespace DAL.Base.Repository.Interface
{
    public interface IBaseRepositoryAsync<TEntity> : IBaseRepositoryAsync<TEntity, int>
        where TEntity : class, IBaseEntity<int>, new()
    {
    }

    [Obsolete("IBaseRepository is deprecated, please use IBaseRepositoryAsync instead.")]
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, int>
        where TEntity : class, IBaseEntity<int>, new()
    {
    }

    public interface IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey : IComparable
    {
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(params object[] id);
    }

    public interface IBaseRepositoryAsync<TEntity, TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey : IComparable
    {
        Task<IEnumerable<TEntity>> AllAsync();
        Task<TEntity> FindAsync(params object[] id);
        Task AddAsync(TEntity entity);

    }

    [Obsolete("IBaseRepository is deprecated, please use IBaseRepositoryAsync instead.")]
    public interface IBaseRepository<TEntity, TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey : IComparable
    {
        IEnumerable<TEntity> All();
        TEntity Find(params object[] id);
        void Add(TEntity entity);
    }
}