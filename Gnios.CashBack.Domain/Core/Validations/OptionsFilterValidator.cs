using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.GenericControllers;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Domain.Album.Dto;

namespace Gnios.CashBack.Api.ModelTest
{
    public class OptionsFilterValidator : AbstractValidator<OptionsFilter>
    {
        public IBusiness<AlbumEntity, AlbumDto> Business { get; }
        public IMapper Mapper { get; }

        public OptionsFilterValidator()
        {
            RuleFor(x => x.id_like).IsNumericType();
            RuleFor(x => x._page).IsNumericType();
            RuleFor(x => x._skip).IsNumericType();
            RuleFor(x => x._take).IsNumericType();
        }
    }
}
