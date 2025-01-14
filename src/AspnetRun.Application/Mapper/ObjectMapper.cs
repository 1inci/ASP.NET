﻿using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AutoMapper;
using System;

namespace AspnetRun.Application.Mapper
{
    // The best implementation of AutoMapper for class libraries -> https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<AspnetRunDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class AspnetRunDtoMapper : Profile
    {
        public AspnetRunDtoMapper()
        {
            CreateMap<Room, RoomModel>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.RoomName)).ReverseMap();

            CreateMap<WareHouse, WareHouseModel>()
               .ForMember(dest => dest.WareHouseName, opt => opt.MapFrom(src => src.WareHouseName)).ReverseMap();


            CreateMap<Building, BuildingModel>().ReverseMap();
        }
    }
}
