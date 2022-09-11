using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Dtos.Fight
{
    public class WeaponAttackDTO
    {
        public int AttackId { get; set; }
        public int OpponentId { get; set; }
    }
}