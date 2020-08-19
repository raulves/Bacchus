using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Service;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.App.Services
{
    public class BidService : BaseEntityService<IAppUnitOfWork, IBidRepository, IBidServiceMapper, BidDAL, BidBLL>, IBidService
    {
        public BidService(IAppUnitOfWork uow) : base(uow, uow.Bids, new BidServiceMapper())
        {
            
        }
    }
}