using System;
using System.Collections.Generic;
using System.Text;

namespace Gnios.CashBack.ApplicationCore.Core
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
