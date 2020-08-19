using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Contracts.DAL.Base.Mappers;
using Contracts.DAL.Base.Repositories;
using Contracts.Domain;

namespace DAL.Base.HttpClient.Services
{
    public class HttpClientBaseService<THttpClient, TDomainEntity, TDALEntity> : 
        HttpClientBaseService<Guid, THttpClient, TDomainEntity, TDALEntity>,
        IBaseRepository<TDALEntity>
        where TDALEntity : class, IDomainEntityId<Guid>, new()
        where TDomainEntity : class, IDomainEntityId<Guid>, new()
        where THttpClient : System.Net.Http.HttpClient
    {
        public HttpClientBaseService(THttpClient httpClient, string uri, IBaseDALMapper<TDomainEntity, TDALEntity> mapper) : base(
            httpClient, uri, mapper)
        {
            
        }
    }

    public class HttpClientBaseService<TKey, THttpClient, TDomainEntity, TDALEntity> :
        IBaseRepository<TKey, TDALEntity>
        where TDALEntity : class, IDomainEntityId<TKey>, new()
        where TDomainEntity : class, IDomainEntityId<TKey>, new()
        where THttpClient : System.Net.Http.HttpClient
        where TKey : IEquatable<TKey>
    {
        protected readonly THttpClient ServiceHttpClient;
        protected readonly string ServiceUri;

        protected readonly IBaseDALMapper<TDomainEntity, TDALEntity> Mapper;

        public HttpClientBaseService(THttpClient serviceHttpClient, string uri, IBaseDALMapper<TDomainEntity, TDALEntity> mapper)
        {
            ServiceHttpClient = serviceHttpClient;
            ServiceUri = uri;
            Mapper = mapper;

            if (ServiceUri == null)
            {
                throw new ArgumentNullException(typeof(TDALEntity).Name + " was not found as URI!");
            }
        }

        public virtual async Task<IEnumerable<TDALEntity>> GetAllAsync()
        {
            ServiceHttpClient.DefaultRequestHeaders.Accept.Clear();
            ServiceHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            ServiceHttpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = ServiceHttpClient.GetStreamAsync(ServiceUri);
            var domainEntities = await JsonSerializer.DeserializeAsync<IEnumerable<TDomainEntity>>(await streamTask);
            var result = domainEntities.Select(e => Mapper.Map(e));
            return result;
        }

        public virtual async Task<TDALEntity> FirstOrDefaultAsync(TKey id)
        {
            ServiceHttpClient.DefaultRequestHeaders.Accept.Clear();
            ServiceHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            ServiceHttpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = ServiceHttpClient.GetStreamAsync(ServiceUri);
            var domainEntities = await JsonSerializer.DeserializeAsync<IEnumerable<TDomainEntity>>(await streamTask);
            var domainEntity = domainEntities.FirstOrDefault(e => e.Id.Equals(id));
            var result = Mapper.Map(domainEntity);
            return result;
        }

        public TDALEntity Add(TDALEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}