using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Domain.Album.Dto;

namespace Gnios.CashBack.Api.ModelTest
{
    public class AlbumValidator : AbstractValidator<AlbumDto>
    {
        public AlbumValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Genre).NotEmpty().NotNull();
            RuleFor(x => x.Price).NotEmpty().NotNull();
        }
    }
}
