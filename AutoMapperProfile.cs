using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_webapi.Dtos.Charactor;

namespace dotnet_webapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Charactor, GetCharactorDTO>();
            CreateMap<AddCharactorDTO, Charactor>();
        }
    }
}