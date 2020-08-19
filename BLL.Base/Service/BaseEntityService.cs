using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.Base.Mappers;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Contracts.Domain;

namespace BLL.Base.Service
{
    public class BaseEntityService<TUOW, TRepository, TMapper, TDALEntity, TBLLEntity> :
        BaseEntityService<Guid, TUOW, TRepository, TMapper, TDALEntity, TBLLEntity>, IBaseEntityService<TBLLEntity>
        where TDALEntity : class, IDomainEntityId<Guid>, new()
        where TBLLEntity : class, IDomainEntityId<Guid>, new()
        where TUOW : IBaseUnitOfWork
        where TRepository : IBaseRepository<Guid, TDALEntity>
        where TMapper : IBaseBLLMapper<TDALEntity, TBLLEntity>
    {
        public BaseEntityService(TUOW uow, TRepository repository,
            TMapper mapper) : base(uow, repository, mapper)
        {
        }
    }

    public class BaseEntityService<TKey, TUOW, TRepository, TMapper, TDALEntity, TBLLEntity> : IBaseEntityService<TKey, TBLLEntity>
        where TKey : IEquatable<TKey>
        where TDALEntity : class, IDomainEntityId<TKey>, new()
        where TBLLEntity : class, IDomainEntityId<TKey>, new()
        where TUOW : IBaseUnitOfWork
        where TRepository : IBaseRepository<TKey, TDALEntity>
        where TMapper : IBaseBLLMapper<TDALEntity, TBLLEntity>
    {
        // ReSharper disable MemberCanBePrivate.Global
        protected readonly TUOW UOW;
        protected readonly TRepository Repository;

        protected readonly TMapper Mapper;
        // ReSharper enable MemberCanBePrivate.Global

        // ReSharper disable once MemberCanBeProtected.Global
        public BaseEntityService(TUOW uow, TRepository repository, TMapper mapper)
        {
            UOW = uow;
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<IEnumerable<TBLLEntity>> GetAllAsync()
        {
            var dalEntities = await Repository.GetAllAsync();
            var result = dalEntities.Select(e => Mapper.Map(e));
            return result;
        }

        public virtual async Task<TBLLEntity> FirstOrDefaultAsync(TKey id)
        {
            var dalEntity = await Repository.FirstOrDefaultAsync(id);
            var result = Mapper.Map(dalEntity);
            return result;
        }

        public TBLLEntity Add(TBLLEntity entity)
        {
            var dalEntity = Repository.Add(Mapper.Map(entity));
            var result = Mapper.Map(dalEntity);
            return result;
        }
    }
}