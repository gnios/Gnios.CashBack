using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using LiteDB;

namespace Gnios.CashBack.Api.Persistence.Repository.LiteDB
{
    [Serializable]
    public class LiteDBStorageRepository<TFile> where TFile : class, IStorageFile, new()
    {
        private LiteStorage _fileStorage;

        public ILiteDBContext DbContext { get; }

        private LiteStorage Collection
        {
            get
            {
                if (_fileStorage == null)
                {
                    _fileStorage = DbContext.Database.FileStorage;
                }
                return _fileStorage;
            }
        }
        
        public LiteDBStorageRepository(ILiteDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public TFile Add(TFile file)
        {
            _fileStorage.Upload(file.Id, nameof(file), new MemoryStream(file.Content));
            return file;
        }

        public TFile Get(String idOrName)
        {
            LiteFileInfo fileInfo = _fileStorage.FindById(idOrName);

            if (fileInfo == null)
            {
                return null;
            }

            return fileInfo.ToStorageFile<TFile>();
        }

        public IEnumerable<TFile> GetAll()
        {
            foreach (LiteFileInfo fileInfo in _fileStorage.FindAll())
            {
                yield return fileInfo.ToStorageFile<TFile>();
            }
        }

        public bool Remove(String id)
        {
            return _fileStorage.Delete(id);
        }

        public bool Remove(TFile file)
        {
            return Remove(file.Id);
        }

        public TFile Update(TFile file)
        {
            return Add(file);
        }
    }
}
