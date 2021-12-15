using AspnetRun.Application.Models;
using AspnetRun.Web.ViewModels;
using AutoMapper;

namespace AspnetRun.Web.Mapper
{
    public class AspnetRunProfile : Profile
    {
        public AspnetRunProfile()
        {
            CreateMap<RoomModel, RoomViewModel>().ReverseMap();
            CreateMap<WareHouseModel, WareHouseViewModel>().ReverseMap();
            CreateMap<BuildingModel, BuildingViewModel>().ReverseMap();
        }
    }
}
