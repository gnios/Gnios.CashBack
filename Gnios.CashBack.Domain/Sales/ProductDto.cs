using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.GenericControllers;

namespace Gnios.CashBack.Domain.Album.Dto
{
    public class ProductDto : BaseDto
    {
        public ProductDto(int id, string name, string genre, decimal price, decimal cashback)
        {
            this.Id = id;
            this.Name = name;
            this.Genre = genre;
            this.Price = price;
            this.Cashback = cashback;
        }

        public string Name { get; private set; }

        public string Genre { get; private set; }

        public decimal Price { get; private set; }

        public decimal Cashback { get; private set; }
    }
}
