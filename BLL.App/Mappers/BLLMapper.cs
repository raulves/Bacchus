using AutoMapper;
using AutoMapper.Configuration;
using BLL.App.DTO;
using BLL.Base.Mappers;
using DAL.App.DTO;

namespace BLL.App.Mappers
{
    public class BLLMapper<TLeftObject, TRightObject> : BaseBLLMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public BLLMapper() : base()
        { 
            // add more mappings
            MapperConfigurationExpression.CreateMap<BidDAL, BidBLL>();
            MapperConfigurationExpression.CreateMap<BidBLL, BidDAL>();
            
            MapperConfigurationExpression.CreateMap<ItemDAL, ItemBLL>();
            MapperConfigurationExpression.CreateMap<ItemBLL, ItemDAL>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}