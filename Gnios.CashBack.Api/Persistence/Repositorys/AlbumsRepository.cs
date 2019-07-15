using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence.Repository.LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.Persistence.Repositorys
{
    [Serializable]
    public class AlbumsRepository : LiteDBRepository<Album, Guid>, IAlbumsRepository
    {
        public AlbumsRepository():base(new Context())
        {
        }
    }
}
