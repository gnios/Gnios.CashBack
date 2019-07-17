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
    [Serializable]
    public class SalesEntity : Entity
    {
        public IList<ProductEntity> Products { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Cashback { get; set; }
        public decimal Total { get; set; }
    }
}
