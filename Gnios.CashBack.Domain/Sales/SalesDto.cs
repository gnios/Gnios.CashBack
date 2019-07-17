using Gnios.CashBack.Api.GenericControllers;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Domain.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.Entities
{
    [Feature("Sales", typeof(SalesEntity))]
    public class SalesDto : BaseDto
    {
        public IList<ProductDto> Products { get; set; }
        public DateTime SaleDate { get; set; }

        public decimal TotalCashback
        {
            get
            {
                return Products.Sum(x => x.Cashback);
            }
        }

        public decimal Total
        {
            get
            {
                return Products.Sum(x => x.Price);
            }
        }
    }
}
