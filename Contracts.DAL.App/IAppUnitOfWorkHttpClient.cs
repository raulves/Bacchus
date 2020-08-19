using Contracts.DAL.App.Services;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWorkHttpClient : IBaseUnitOfWork
    {
        IItemService Items { get; }
    }
}