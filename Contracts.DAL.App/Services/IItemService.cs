using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Services
{
    public interface IItemService : IBaseRepository<ItemDAL>, IItemServiceCustom
    {
        
    }
}