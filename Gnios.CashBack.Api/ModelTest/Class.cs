using FluentValidation;
using Gnios.CashBack.Api.GenericControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.ModelTest
{
    [GeneratedController("api/Person")]
    public class Person : Entidade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().Length(0, 10);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Age).NotEmpty().InclusiveBetween(18, 60);
        }
    }
}
