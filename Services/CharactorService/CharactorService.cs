using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Services.CharactorService
{
    public class CharactorService : ICharactorService
    {
        private static List<Charactor> charactors = new List<Charactor>{
            new Charactor(),
            new Charactor{ Id= 1, Name= "Sam"}
        };
        public async Task<ServiceResponse<List<Charactor>>> AddCharactor(Charactor newCharactor)
        {
            var serviceResponse = new ServiceResponse<List<Charactor>>();
            charactors.Add(newCharactor);
            serviceResponse.Data = charactors;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Charactor>>> GetAllCharactor()
        {
            return new ServiceResponse<List<Charactor>> { Data = charactors };
        }

        public async Task<ServiceResponse<Charactor>> GetCharactorById(int id)
        {
            var serviceResponse = new ServiceResponse<Charactor>();
            var charactor = charactors.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = charactor;
            return serviceResponse;
        }
    }
}