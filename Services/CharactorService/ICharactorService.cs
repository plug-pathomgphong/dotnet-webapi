using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Dtos.Charactor;

namespace dotnet_webapi.Services.CharactorService
{
    public interface ICharactorService
    {
        // Add Task<> when use Asynchronous calls
        Task<ServiceResponse<List<GetCharactorDTO>>> GetAllCharactor();
        Task<ServiceResponse<GetCharactorDTO>> GetCharactorById(int id);
        Task<ServiceResponse<List<GetCharactorDTO>>> AddCharactor(AddCharactorDTO newCharactor);
    }
}