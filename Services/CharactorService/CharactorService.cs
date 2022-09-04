using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_webapi.Dtos.Charactor;

namespace dotnet_webapi.Services.CharactorService
{
    public class CharactorService : ICharactorService
    {
        private static List<Charactor> charactors = new List<Charactor>{
            new Charactor(),
            new Charactor{ Id= 1, Name= "Sam"}
        };
        private readonly IMapper _mapper;

        public CharactorService(IMapper mapper)
        {
            _mapper = mapper; // Use with DTO
        }
        public async Task<ServiceResponse<List<GetCharactorDTO>>> AddCharactor(AddCharactorDTO newCharactor)
        {
            var serviceResponse = new ServiceResponse<List<GetCharactorDTO>>();
            Charactor charactor = _mapper.Map<Charactor>(newCharactor);
            charactor.Id = charactors.Max(c => c.Id) + 1;
            charactors.Add(charactor);
            serviceResponse.Data = charactors.Select(c => _mapper.Map<GetCharactorDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharactorDTO>>> GetAllCharactor()
        {
            return new ServiceResponse<List<GetCharactorDTO>> { Data = charactors.Select(c => _mapper.Map<GetCharactorDTO>(c)).ToList() };
        }

        public async Task<ServiceResponse<GetCharactorDTO>> GetCharactorById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharactorDTO>();
            var charactor = charactors.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharactorDTO>(charactor);
            return serviceResponse;
        }
    }
}