using Gnios.CashBack.Api.Persistence.Repository.LiteDB;
using LiteDB;
using System;
using System.IO;
using FileMode = LiteDB.FileMode;

namespace Gnios.CashBack.Api.Persistence
{
    [Serializable]
    public class Context : ILiteDBContext
    {
        private LiteRepository db;

        public LiteRepository Repository
        {
            get
            {
                var appDomain = System.AppDomain.CurrentDomain;
                var basePath = appDomain.BaseDirectory;

                var pathDirectory = Path.Combine(basePath, "DB");
                if (!Directory.Exists(pathDirectory))
                    Directory.CreateDirectory(pathDirectory);

                var path = Path.Combine(pathDirectory, "liteDB");
                var connectionstring = new ConnectionString();
                connectionstring.Filename = path;
                connectionstring.Mode = FileMode.Shared;

                return db ?? (db = new LiteRepository(connectionstring));
            }

            set { db = value; }
        }
    }
}
