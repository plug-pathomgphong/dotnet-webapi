using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Dtos.Fight
{
    public class SkillAttackDTO
    {
        public int AttackId { get; set; }
        public int OpponentId { get; set; }
        public int SkillId { get; set; }
    }
}