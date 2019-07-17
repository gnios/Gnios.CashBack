using Gnios.CashBack.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gnios.CashBack.ApplicationCore.Sales
{
    [Serializable]
    public class CashbackEntity : Entity
    {
        public CashbackEntity()
        {
        }

        public CashbackEntity(string genre, DayOfWeek dayOfWeek, decimal percentage)
        {
            this.Genre= genre;
            DayOfWeek = dayOfWeek;
            this.Percentage = percentage;
        }

        public string Genre { get; set; }
        public decimal Percentage { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
