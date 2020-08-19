using AutoMapper;
using BLL.App.DTO;

namespace WebApp.ViewModels.Mappers
{
    public class VMMapper<TLeftObject, TRightObject> : BaseVMMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public VMMapper() : base()
        {
            // add more mappings

            MapperConfigurationExpression.CreateMap<BidBLL, BetVM>();
            MapperConfigurationExpression.CreateMap<BetVM, BidBLL>();
            
            MapperConfigurationExpression.CreateMap<ItemBLL, ItemVM>();
            MapperConfigurationExpression.CreateMap<ItemVM, ItemBLL>();

            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}