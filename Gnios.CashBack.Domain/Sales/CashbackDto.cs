using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.GenericControllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gnios.CashBack.ApplicationCore.Sales
{
    [Feature("Cashback",typeof(CashbackEntity))]
    [Serializable]
    public class CashbackDto : BaseDto
    {
        public CashbackDto()
        {
        }

        public string Genre { get; set; }
        public decimal Percentage { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
