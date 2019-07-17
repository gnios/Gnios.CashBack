using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.GenericControllers;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Domain.Album;
using Gnios.CashBack.Domain.Album.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gnios.CashBack.ApplicationCore.Album
{
    public class AlbumBusiness : BaseBusiness<AlbumEntity, AlbumDto>
    {
        public AlbumBusiness(IRepository<AlbumEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override IEnumerable<AlbumDto> GetAll(OptionsFilter options = null)
        {
            return base.GetAll(options);
        }
    }
}
