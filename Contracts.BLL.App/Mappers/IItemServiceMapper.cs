using BLL.App.DTO;
using Contracts.BLL.Base.Mappers;
using DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IItemServiceMapper : IBaseBLLMapper<ItemDAL, ItemBLL>
    {
        
    }
}