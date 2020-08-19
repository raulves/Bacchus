using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Domain;

namespace Contracts.DAL.Base.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseRepository<Guid, TEntity> 
        where TEntity : class, IDomainEntityId<Guid>, new()
    {
    }

    public interface IBaseRepository<in TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : class, IDomainEntityId<TKey>, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FirstOrDefaultAsync(TKey id);
        TEntity Add(TEntity entity);
    }
}