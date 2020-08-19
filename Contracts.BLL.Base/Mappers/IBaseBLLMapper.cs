using Contracts.DAL.Base.Mappers;

namespace Contracts.BLL.Base.Mappers
{
    public interface IBaseBLLMapper<TLeftObject, TRightObject> : IBaseDALMapper<TLeftObject, TRightObject>
        where TLeftObject: class?, new()
        where TRightObject: class?, new()
    {
        
    }
}