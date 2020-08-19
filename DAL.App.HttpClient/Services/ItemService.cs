using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Contracts.DAL.App.Services;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.HttpClient.Services;
using Domain.App;

namespace DAL.App.HttpClient.Services
{
    public class ItemService : HttpClientBaseService<System.Net.Http.HttpClient, Item, ItemDAL>, IItemService
    {
        public ItemService(System.Net.Http.HttpClient httpClient, string uri) : base(httpClient, uri, new DALMapper<Item, ItemDAL>())
        {
        }

        public async Task<IEnumerable<ItemDAL>> GetItemsForViewAsync(string? category, string? search)
        {
            ServiceHttpClient.DefaultRequestHeaders.Accept.Clear();
            ServiceHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            ServiceHttpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = ServiceHttpClient.GetStreamAsync(ServiceUri);
            var domainEntities = await JsonSerializer.DeserializeAsync<IEnumerable<Item>>(await streamTask);

            if (!String.IsNullOrEmpty(search))
            {
                domainEntities = domainEntities
                    .Where(i => i.ItemName.ToLower().Contains(search.ToLower())
                                || i.ItemCategory.ToLower().Contains(search.ToLower())
                                || i.ItemDescription.ToLower().Contains(search.ToLower()));
            }

            if (!String.IsNullOrEmpty(category))
            {
                domainEntities = domainEntities
                    .Where(c => c.ItemCategory.ToLower().Equals(category.ToLower()));
            }
            var result = domainEntities.Select(e => Mapper.Map(e));
            return result;
        }
    }
}