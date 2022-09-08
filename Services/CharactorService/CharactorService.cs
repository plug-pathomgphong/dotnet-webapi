using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_webapi.Data;
using dotnet_webapi.Dtos.Charactor;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi.Services.CharactorService
{
    public class CharactorService : ICharactorService
    {
        private static List<Charactor> charactors = new List<Charactor>{
            new Charactor(),
            new Charactor{ Id= 1, Name= "Sam"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharactorService(IMapper mapper, DataContext context)
        {
            _mapper = mapper; // Use with DTO
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharactorDTO>>> AddCharactor(AddCharactorDTO newCharactor)
        {
            var serviceResponse = new ServiceResponse<List<GetCharactorDTO>>();
            Charactor charactor = _mapper.Map<Charactor>(newCharactor);
            _context.Charactors.Add(charactor);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Charactors.Select(c => _mapper.Map<GetCharactorDTO>(c)).ToListAsync();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharactorDTO>>> GetAllCharactor(int userId)
        {
            var response = new ServiceResponse<List<GetCharactorDTO>>();
            var dbCharactors = await _context.Charactors
                .Where(c => c.User.Id == userId)
                .ToListAsync();
            response.Data = dbCharactors.Select(c => _mapper.Map<GetCharactorDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharactorDTO>> GetCharactorById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharactorDTO>();
            var dbCharactor = await _context.Charactors.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharactorDTO>(dbCharactor);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharactorDTO>> UpdateCharactor(UpdateCharactorDTO updateCharactor)
        {
            ServiceResponse<GetCharactorDTO> response = new ServiceResponse<GetCharactorDTO>();
            try
            {
                var charactor = await _context.Charactors.FirstOrDefaultAsync(c => c.Id == updateCharactor.Id);

                _mapper.Map(updateCharactor, charactor);
                // charactor.Name = updateCharactor.Name;
                // charactor.HitPoints = updateCharactor.HitPoints;
                // charactor.Strength = updateCharactor.Strength;
                // charactor.Defense = updateCharactor.Defense;
                // charactor.Intelligence = updateCharactor.Intelligence;
                // charactor.Class = updateCharactor.Class;

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharactorDTO>(charactor);


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetCharactorDTO>>> DeleteCharactor(int id)
        {
            ServiceResponse<List<GetCharactorDTO>> response = new ServiceResponse<List<GetCharactorDTO>>();
            try
            {
                Charactor charactor = await _context.Charactors.FirstAsync(c => c.Id == id);
                _context.Charactors.Remove(charactor);

                await _context.SaveChangesAsync();

                response.Data = _context.Charactors.Select(c => _mapper.Map<GetCharactorDTO>(c)).ToList();

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