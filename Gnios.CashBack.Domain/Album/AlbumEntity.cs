using Gnios.CashBack.Api.GenericControllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.Entities
{
    [Serializable]
    public class AlbumEntity : Entity
    {
        public AlbumEntity()
        {
            Random random = new Random();
            const int maxValue = 100;
            const int minValue = 1;
            var randomPrice = random.NextDouble() * (maxValue - minValue) + minValue;
            this.Price = Convert.ToDecimal(Math.Round(randomPrice, 2));
        }
        public string Name { get; set; }
        
        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
