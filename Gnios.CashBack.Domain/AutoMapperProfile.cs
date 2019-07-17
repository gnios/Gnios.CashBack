using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Domain.Album.Dto;

namespace Gnios.CashBack.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AlbumEntity, AlbumDto>().ReverseMap();
        }
    }
}
