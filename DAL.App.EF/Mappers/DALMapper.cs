using AutoMapper;
using DAL.App.DTO;
using DAL.Base.Mappers;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class DALMapper<TLeftObject, TRightObject> : BaseDALMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public DALMapper() : base()
        {
            // add more mappings
            MapperConfigurationExpression.CreateMap<Bid, BidDAL>();
            MapperConfigurationExpression.CreateMap<BidDAL, Bid>();
            
            MapperConfigurationExpression.CreateMap<Item, ItemDAL>();
            MapperConfigurationExpression.CreateMap<ItemDAL, Item>();

            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}