using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_webapi.Dtos.Charactor;
using dotnet_webapi.Dtos.Fight;
using dotnet_webapi.Dtos.Skill;
using dotnet_webapi.Dtos.Weapons;

namespace dotnet_webapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Charactor, GetCharactorDTO>();
            CreateMap<AddCharactorDTO, Charactor>();
            CreateMap<UpdateCharactorDTO, Charactor>();
            CreateMap<Weapons, GetWeaponDTO>();
            CreateMap<Skill, GetSkillDTO>();
            CreateMap<Charactor, HighScoreDTO>();
        }
    }
}