using Gnios.CashBack.Api.Entities;

namespace Gnios.CashBack.Domain.Album.Dto
{
    public class ProductEntity : Entity
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public decimal Cashback { get; set; }
    }
}
