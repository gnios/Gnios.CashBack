using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Api.Spotify;
using System.Collections.Generic;
using System.Linq;

namespace Gnios.CashBack.Api
{
    public class DbInitializer
    {
        public DbInitializer(IRepository<AlbumEntity> repository, MemoryCacheService cache, ClientRest client, IMapper mapper)
        {
            Repository = repository;
            Cache = cache;
            Client = client;
            Mapper = mapper;
        }

        public IRepository<AlbumEntity> Repository { get; }
        public MemoryCacheService Cache { get; }
        public ClientRest Client { get; }
        public IMapper Mapper { get; }

        public void Seed()
        {
            ClearDataBase();
            if (!Repository.GetAll().Any())
            {
                var spotifyAlbums = Client.GetAlbums();
                var albums = Mapper.Map<List<AlbumEntity>>(spotifyAlbums);
                Repository.AddBulk(albums);
            }
        }

        public void ClearDataBase()
        {
            foreach (var item in Repository.GetAll())
            {
                Repository.Remove(item);
            }
        }
    }
}
