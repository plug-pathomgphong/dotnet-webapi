using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Services.CharactorService
{
    public interface ICharactorService
    {
        // Add Task<> when use Asynchronous calls
        Task<ServiceResponse<List<Charactor>>> GetAllCharactor();
        Task<ServiceResponse<Charactor>> GetCharactorById(int id);
        Task<ServiceResponse<List<Charactor>>> AddCharactor(Charactor newCharactor);
    }
}