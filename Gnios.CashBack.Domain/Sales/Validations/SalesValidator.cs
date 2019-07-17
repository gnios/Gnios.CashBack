using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Domain.Album.Dto;

namespace Gnios.CashBack.Api.ModelTest
{
    public class SalesValidator : AbstractValidator<SalesDto>
    {
        public IBusiness<AlbumEntity, AlbumDto> Business { get; }
        public IMapper Mapper { get; }

        public SalesValidator(IBusiness<AlbumEntity, AlbumDto> businessAlbum,
            IMapper mapper)
        {
            Business = businessAlbum;
            Mapper = mapper;
            RuleFor(x => x.SaleDate).NotEmpty().NotNull();
            RuleFor(x => x.Products).NotEmpty().NotNull();
            RuleForEach(x => x.Products).SetValidator(new ProductItemValidator(businessAlbum, mapper));
        }

        private class ProductItemValidator : AbstractValidator<ProductDto>
        {
            public IBusiness<AlbumEntity, AlbumDto> Business { get; }
            public IMapper Mapper { get; }

            public ProductItemValidator(IBusiness<AlbumEntity, AlbumDto> business,
                IMapper mapper)
            {
                RuleFor(x => x.Id).NotEmpty().NotNull();
                RuleFor(x => x).Must(x => ProductExists(x)).WithMessage(x => $"O produto {x.Id} não existe.");
                Business = business;
                Mapper = mapper;
            }
            private bool ProductExists(ProductDto product)
            {
                if (!Business.Exists(product.Id))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
