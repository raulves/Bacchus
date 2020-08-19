using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IBidService : IBaseEntityService<BidBLL>, IBidRepositoryCustom<BidBLL>
    {
        // TODO : add custom methods
    }
}