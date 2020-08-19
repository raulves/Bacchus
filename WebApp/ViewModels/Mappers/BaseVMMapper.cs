using DAL.Base.Mappers;

namespace WebApp.ViewModels.Mappers
{
    public abstract class BaseVMMapper<TLeftObject, TRightObject> : BaseDALMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
    }
}