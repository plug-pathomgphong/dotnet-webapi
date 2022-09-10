using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Models
{
    public class Weapons
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public Charactor Charactor { get; set; }
        public int CharactorId { get; set; }
    }
}