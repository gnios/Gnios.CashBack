﻿using Gnios.CashBack.Api.Persistence.Repository.LiteDB;
using LiteDB;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.Persistence
{
    [Serializable]
    public class Context : ILiteDBContext
    {
        private LiteDatabase db;

        public LiteDatabase Database
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
                connectionstring.Mode = LiteDB.FileMode.Exclusive;

                return db ?? (db = new LiteDatabase(connectionstring));
            }

            set { db = value; }
        }
    }
}