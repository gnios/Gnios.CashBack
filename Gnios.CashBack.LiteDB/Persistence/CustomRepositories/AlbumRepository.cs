using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence.Repository.LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gnios.CashBack.LiteDB.Persistence.CustomRepositories
{
    public class AlbumRepository : LiteDBRepository<AlbumEntity>
    {
        public AlbumRepository(ILiteDBContext dbContext) : base(dbContext)
        {
        }
    }
}
