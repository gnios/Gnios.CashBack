using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.GenericControllers;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.ApplicationCore.Sales;
using Gnios.CashBack.Domain.Album;
using Gnios.CashBack.Domain.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnios.CashBack.ApplicationCore.Album
{
    public class SalesBusiness : BaseBusiness<SalesEntity, SalesDto>
    {
        public IRepository<AlbumEntity> RepositoryAlbum { get; }
        public IRepository<CashbackEntity> RepositoryCashback { get; }

        public SalesBusiness(IRepository<SalesEntity> repository,
            IRepository<AlbumEntity> repositoryAlbum,
            IRepository<CashbackEntity> repositoryCashback,
            IMapper mapper) : base(repository, mapper)
        {
            RepositoryAlbum = repositoryAlbum;
            RepositoryCashback = repositoryCashback;
        }


        public override SalesDto Add(SalesDto dto)
        {
            var entity = Mapper.Map<SalesEntity>(dto);
            var products = GetProducts(entity);
            entity.Products = CalcCashback(products,entity.SaleDate);
            var entityAdded = Repository.Add(entity);
            return Mapper.Map<SalesDto>(entityAdded);
        }

        public override SalesDto Update(int id, SalesDto dto)
        {
            var entity = Mapper.Map<SalesEntity>(dto);
            var products = GetProducts(entity);
            entity.Products = CalcCashback(products,entity.SaleDate);
            var entityUpdated = Repository.Update(id, entity);
            return Mapper.Map<SalesDto>(entityUpdated);
        }

        private IList<ProductEntity> GetProducts(SalesEntity entity)
        {
            var ids = entity.Products.Select(x => x.Id).ToArray();
            var products = RepositoryAlbum.Find(x => ids.Contains(x.Id)).ToList();
            return Mapper.Map<List<ProductEntity>>(products);
        }

        private IList<ProductEntity> CalcCashback(IList<ProductEntity> products, DateTime salesDate)
        {
            var cashbackRules = RepositoryCashback.GetAll();

            foreach (var item in products)
            {
                var rule = cashbackRules.FirstOrDefault(x => x.Genre.Equals(item.Genre) && x.DayOfWeek == salesDate.DayOfWeek);
                if (rule != null)
                {
                    item.Cashback = item.Price * rule.Percentage;
                }
            }

            return products.ToList();
        }
    }
}
