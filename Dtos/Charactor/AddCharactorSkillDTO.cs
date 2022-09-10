using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Dtos.Charactor
{
    public class AddCharactorSkillDTO
    {
        public int CharactorId { get; set; }
        public int SkillId { get; set; }
    }
}