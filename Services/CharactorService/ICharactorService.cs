using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Services.CharactorService
{
    public interface ICharactorService
    {
        List<Charactor> GetAllCharactor();
        Charactor GetCharactorById(int id);
        List<Charactor> AddCharactor(Charactor newCharactor);
    }
}