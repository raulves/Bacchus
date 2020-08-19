using System;
using Contracts.DAL.App;
using Contracts.DAL.App.Services;
using DAL.App.HttpClient.Services;
using DAL.Base.HttpClient;

namespace DAL.App.HttpClient
{
    public class HttpClientAppUnitOfWork : HttpClientBaseUnitOfWork<Guid, System.Net.Http.HttpClient>, IAppUnitOfWorkHttpClient
    {
        // Hack with DI
        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        public HttpClientAppUnitOfWork() : base(client)
        {
        }


        public IItemService Items => GetRepository<IItemService>(() =>
            new ItemService(UOWHttpClient, "http://uptime-auction-api.azurewebsites.net/api/Auction"));
    }
}