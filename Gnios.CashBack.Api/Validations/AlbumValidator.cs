using FluentValidation;
using Gnios.CashBack.Api.Entities;

namespace Gnios.CashBack.Api.ModelTest
{
    public class AlbumValidator : AbstractValidator<AlbumEntity>
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
