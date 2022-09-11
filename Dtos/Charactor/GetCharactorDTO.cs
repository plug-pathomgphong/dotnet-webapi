using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Dtos.Skill;
using dotnet_webapi.Dtos.Weapons;

namespace dotnet_webapi.Dtos.Charactor
{
    public class GetCharactorDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public Rpgclass Class { get; set; } = Rpgclass.Knight;
        public GetWeaponDTO Weapons { get; set; }
        public List<GetSkillDTO> Skills { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }


    }
}