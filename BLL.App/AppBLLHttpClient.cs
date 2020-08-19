using BLL.App.Services;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App
{
    public class AppBLLHttpClient : BaseBLL<IAppUnitOfWorkHttpClient>, IAppBLLHttpClient
    {
        public AppBLLHttpClient(IAppUnitOfWorkHttpClient uow) : base(uow)
        {
            
        }
        public IItemServiceBLL Items => GetService<IItemServiceBLL>(() => new ItemServiceBLL(UOW));
    }
}