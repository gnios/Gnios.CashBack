using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Api.Spotify;
using Gnios.CashBack.ApplicationCore.Sales;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnios.CashBack.Api
{
    public class DbInitializer
    {
        public DbInitializer(IRepository<AlbumEntity> repository,
            IRepository<CashbackEntity> repositoryCashback,
            MemoryCacheService cache,
            ClientRest client, IMapper mapper)
        {
            Repository = repository;
            RepositoryCashback = repositoryCashback;
            Cache = cache;
            Client = client;
            Mapper = mapper;
        }

        public IRepository<AlbumEntity> Repository { get; }
        public IRepository<CashbackEntity> RepositoryCashback { get; }
        public MemoryCacheService Cache { get; }
        public ClientRest Client { get; }
        public IMapper Mapper { get; }

        public void Seed()
        {
            if (!Repository.GetAll().Any())
            {
                var spotifyAlbums = Client.GetAlbums();
                var albums = Mapper.Map<List<AlbumEntity>>(spotifyAlbums);
                Repository.AddBulk(albums);
            }

            if (!RepositoryCashback.GetAll().Any())
            {
                RepositoryCashback.Add(new CashbackEntity("pop", DayOfWeek.Sunday, 0.25m));
                RepositoryCashback.Add(new CashbackEntity("pop", DayOfWeek.Monday, 0.07m));
                RepositoryCashback.Add(new CashbackEntity("pop", DayOfWeek.Tuesday, 0.06m));
                RepositoryCashback.Add(new CashbackEntity("pop", DayOfWeek.Wednesday, 0.02m));
                RepositoryCashback.Add(new CashbackEntity("pop", DayOfWeek.Thursday, 0.10m));
                RepositoryCashback.Add(new CashbackEntity("pop", DayOfWeek.Friday, 0.15m));
                RepositoryCashback.Add(new CashbackEntity("pop", DayOfWeek.Saturday, 0.20m));

                RepositoryCashback.Add(new CashbackEntity("mpb", DayOfWeek.Sunday, 0.30m));
                RepositoryCashback.Add(new CashbackEntity("mpb", DayOfWeek.Monday, 0.05m));
                RepositoryCashback.Add(new CashbackEntity("mpb", DayOfWeek.Tuesday, 0.10m));
                RepositoryCashback.Add(new CashbackEntity("mpb", DayOfWeek.Wednesday, 0.15m));
                RepositoryCashback.Add(new CashbackEntity("mpb", DayOfWeek.Thursday, 0.20m));
                RepositoryCashback.Add(new CashbackEntity("mpb", DayOfWeek.Friday, 0.25m));
                RepositoryCashback.Add(new CashbackEntity("mpb", DayOfWeek.Saturday, 0.30m));

                RepositoryCashback.Add(new CashbackEntity("classical", DayOfWeek.Sunday, 0.35m));
                RepositoryCashback.Add(new CashbackEntity("classical", DayOfWeek.Monday, 0.03m));
                RepositoryCashback.Add(new CashbackEntity("classical", DayOfWeek.Tuesday, 0.05m));
                RepositoryCashback.Add(new CashbackEntity("classical", DayOfWeek.Wednesday, 0.08m));
                RepositoryCashback.Add(new CashbackEntity("classical", DayOfWeek.Thursday, 0.13m));
                RepositoryCashback.Add(new CashbackEntity("classical", DayOfWeek.Friday, 0.18m));
                RepositoryCashback.Add(new CashbackEntity("classical", DayOfWeek.Saturday, 0.25m));

                RepositoryCashback.Add(new CashbackEntity("rock", DayOfWeek.Sunday, 0.40m));
                RepositoryCashback.Add(new CashbackEntity("rock", DayOfWeek.Monday, 0.10m));
                RepositoryCashback.Add(new CashbackEntity("rock", DayOfWeek.Tuesday, 0.15m));
                RepositoryCashback.Add(new CashbackEntity("rock", DayOfWeek.Wednesday, 0.15m));
                RepositoryCashback.Add(new CashbackEntity("rock", DayOfWeek.Thursday, 0.15m));
                RepositoryCashback.Add(new CashbackEntity("rock", DayOfWeek.Friday, 0.20m));
                RepositoryCashback.Add(new CashbackEntity("rock", DayOfWeek.Saturday, 0.40m));
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
