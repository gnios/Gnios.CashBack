using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.GenericControllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gnios.CashBack.Domain.Album.Dto
{
    [Feature("Album",typeof(AlbumEntity))]
    public class AlbumDto : BaseDto
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
