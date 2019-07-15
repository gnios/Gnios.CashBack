using Gnios.CashBack.Api.GenericControllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.Entities
{
    [Feature("api/Album")]
    public class Album : Entity<Guid>, IProduct
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
