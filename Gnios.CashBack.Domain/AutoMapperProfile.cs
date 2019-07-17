using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.ApplicationCore.Sales;
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

            CreateMap<ProductDto, ProductEntity>();
            CreateMap<ProductDto, AlbumDto>().ReverseMap();
            CreateMap<CashbackEntity, CashbackDto>().ReverseMap();
            CreateMap<ProductEntity, ProductDto>().ConstructUsing(vt => new ProductDto(vt.Id, vt.Name, vt.Genre, vt.Price, vt.Cashback))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<ProductEntity, AlbumEntity>().ReverseMap();
            CreateMap<Expression<Func<SalesEntity, bool>>, Expression<Func<SalesDto, bool>>>().ReverseMap();
        }
    }
}
