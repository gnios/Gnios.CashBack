﻿using Gnios.CashBack.Api.GenericControllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.Entities
{
    [Serializable]
    public class AlbumEntity : Entity
    {
        public string Name { get; set; }
        
        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
