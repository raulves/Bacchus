using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.Base.Mappers;
using Contracts.DAL.Base.Repositories;
using Contracts.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class EFBaseRepository<TDbContext, TDomainEntity, TDALEntity> :
        EFBaseRepository<Guid, TDbContext, TDomainEntity, TDALEntity>,
        IBaseRepository<TDALEntity>
        where TDALEntity : class, IDomainEntityId<Guid>, new()
        where TDomainEntity : class, IDomainEntityId<Guid>, new()
        where TDbContext : DbContext
    {
        public EFBaseRepository(TDbContext repoDbContext, IBaseDALMapper<TDomainEntity, TDALEntity> mapper) : base(
            repoDbContext, mapper)
        {
        }
    }

    public class EFBaseRepository<TKey, TDbContext, TDomainEntity, TDALEntity> :
        IBaseRepository<TKey, TDALEntity>
        where TDALEntity : class, IDomainEntityId<TKey>, new()
        where TDomainEntity : class, IDomainEntityId<TKey>, new()
        where TDbContext : DbContext
        where TKey : IEquatable<TKey>
    {
        // ReSharper disable MemberCanBePrivate.Global
        protected readonly TDbContext RepoDbContext;
        protected readonly DbSet<TDomainEntity> RepoDbSet;

        protected readonly IBaseDALMapper<TDomainEntity, TDALEntity> Mapper;
        // ReSharper enable MemberCanBePrivate.Global

        // ReSharper disable once MemberCanBeProtected.Global
        public EFBaseRepository(TDbContext repoDbContext, IBaseDALMapper<TDomainEntity, TDALEntity> mapper)
        {
            RepoDbContext = repoDbContext;
            RepoDbSet = RepoDbContext.Set<TDomainEntity>();
            Mapper = mapper;

            if (RepoDbSet == null)
            {
                throw new ArgumentNullException(typeof(TDALEntity).Name + " was not found as DbSet!");
            }
        }


        public virtual async Task<IEnumerable<TDALEntity>> GetAllAsync()
        {
            var domainEntities = await RepoDbSet.ToListAsync();
            var result = domainEntities.Select(e => Mapper.Map(e));
            return result;
        }

        public virtual async Task<TDALEntity> FirstOrDefaultAsync(TKey id)
        {
            var domainEntity = await RepoDbSet.FirstOrDefaultAsync(e => e.Id.Equals(id));
            var result = Mapper.Map(domainEntity);
            return result;
        }

        public virtual TDALEntity Add(TDALEntity entity)
        {
            var domainEntity = RepoDbSet.Add(Mapper.Map(entity)).Entity;
            var result = Mapper.Map(domainEntity);
            return result;
        }
        
    }
}