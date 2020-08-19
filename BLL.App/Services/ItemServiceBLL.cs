using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Service;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Services;
using DAL.App.DTO;

namespace BLL.App.Services
{
    public class ItemServiceBLL : BaseEntityService<IAppUnitOfWorkHttpClient, IItemService, IItemServiceMapper, ItemDAL, ItemBLL>, IItemServiceBLL
    {
        public ItemServiceBLL(IAppUnitOfWorkHttpClient uow) : base(uow, uow.Items, new ItemServiceMapper())
        {
            
        }
        
        public virtual  async Task<IEnumerable<ItemBLL>> GetItemsForViewAsync(string? category, string? search)
        {
            return (await Repository.GetItemsForViewAsync(category, search)).Select(e => Mapper.Map(e));
        }
    }
}