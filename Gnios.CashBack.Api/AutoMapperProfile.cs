using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Spotify;
using Gnios.CashBack.Domain.Album.Dto;

namespace Gnios.CashBack.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AlbumEntity, SpotifyAlbum>()
                .ForMember(destination => destination.name, map => map.MapFrom(source => source.Name))
                .ForMember(destination => destination.genre, map => map.MapFrom(source => source.Genre))
                .ReverseMap().ForAllOtherMembers(x => x.Ignore());
        }
    }
}
