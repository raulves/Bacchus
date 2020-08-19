using System.Collections.Generic;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Services;

namespace Contracts.BLL.App.Services
{
    public interface IItemServiceBLL : IBaseEntityService<ItemBLL>, IItemServiceCustom<ItemBLL>
    {
        // TODO : add custom methods
    }
}