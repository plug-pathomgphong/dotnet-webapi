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

        public async Task<ServiceResponse<List<GetCharactorDTO>>> DeleteCharactor(int id)
        {
            ServiceResponse<List<GetCharactorDTO>> response = new ServiceResponse<List<GetCharactorDTO>>();
            try
            {
                Charactor charactor = charactors.First(c => c.Id == id);
                charactors.Remove(charactor);
                response.Data = charactors.Select(c => _mapper.Map<GetCharactorDTO>(c)).ToList();
                            
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;   
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

        public async Task<ServiceResponse<GetCharactorDTO>> UpdateCharactor(UpdateCharactorDTO updateCharactor)
        {
            ServiceResponse<GetCharactorDTO> response = new ServiceResponse<GetCharactorDTO>();
            try
            {
                Charactor charactor = charactors.FirstOrDefault(c => c.Id == updateCharactor.Id);

                _mapper.Map(updateCharactor, charactor);
                // charactor.Name = updateCharactor.Name;
                // charactor.HitPoints = updateCharactor.HitPoints;
                // charactor.Strength = updateCharactor.Strength;
                // charactor.Defense = updateCharactor.Defense;
                // charactor.Intelligence = updateCharactor.Intelligence;
                // charactor.Class = updateCharactor.Class;

                response.Data = _mapper.Map<GetCharactorDTO>(charactor);
            
                            
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;   
        }
    }
}