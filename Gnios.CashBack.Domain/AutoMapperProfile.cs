using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Domain.Album.Dto;
using System;
using System.Linq.Expressions;

namespace Gnios.CashBack.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AlbumEntity, AlbumDto>().ReverseMap();
            CreateMap<SalesEntity, SalesDto>().ReverseMap();
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<ProductEntity, AlbumEntity>().ReverseMap();
            CreateMap<ProductDto, AlbumDto>().ReverseMap();
            CreateMap<Expression<Func<SalesEntity, bool>>, Expression<Func<SalesDto, bool>>>().ReverseMap();
        }
    }
}
