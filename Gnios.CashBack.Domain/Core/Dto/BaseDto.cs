using Gnios.CashBack.Api.Persistence;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Gnios.CashBack.Api.Entities
{
    [Serializable]
    public abstract class BaseDto : IDto
    {
        public virtual int Id { get; set; }
    }
}
