using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Services.CharactorService
{
    public interface ICharactorService
    {
        // Add Task<> when use Asynchronous calls
        Task<List<Charactor>> GetAllCharactor();
        Task<Charactor> GetCharactorById(int id);
        Task<List<Charactor>> AddCharactor(Charactor newCharactor);
    }
}