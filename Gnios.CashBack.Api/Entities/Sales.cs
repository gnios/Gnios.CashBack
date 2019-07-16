using Gnios.CashBack.Api.GenericControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.Entities
{
    [Feature("api/sales")]
    public class Sales : Entity
    {
        public IList<IProduct> Products { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
