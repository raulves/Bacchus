using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLLHttpClient : IBaseBLL
    {
        public IItemServiceBLL Items { get; }
    }
}