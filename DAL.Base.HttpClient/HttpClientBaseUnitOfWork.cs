using System;
using System.Threading.Tasks;

namespace DAL.Base.HttpClient
{
    public class HttpClientBaseUnitOfWork<TKey, THttpClient> : BaseUnitOfWork<TKey>
        where THttpClient : System.Net.Http.HttpClient 
        where TKey : IEquatable<TKey>
    {
        protected readonly THttpClient UOWHttpClient;

        public HttpClientBaseUnitOfWork(THttpClient uowHttpClient)
        {
            UOWHttpClient = uowHttpClient;
        }
        public override Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}