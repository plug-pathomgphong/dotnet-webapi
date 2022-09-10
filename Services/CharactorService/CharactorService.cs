using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharactorService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper; // Use with DTO
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetCharactorDTO>>> AddCharactor(AddCharactorDTO newCharactor)
        {
            var serviceResponse = new ServiceResponse<List<GetCharactorDTO>>();
            Charactor charactor = _mapper.Map<Charactor>(newCharactor);
            charactor.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Charactors.Add(charactor);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Charactors
                .Where(c => c.User.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharactorDTO>(c))
                .ToListAsync();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharactorDTO>>> GetAllCharactor()
        {
            var response = new ServiceResponse<List<GetCharactorDTO>>();
            var dbCharactors = await _context.Charactors
                .Where(c => c.User.Id == GetUserId())
                .ToListAsync();
            response.Data = dbCharactors.Select(c => _mapper.Map<GetCharactorDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharactorDTO>> GetCharactorById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharactorDTO>();
            var dbCharactor = await _context.Charactors
                .Include(c => c.Weapons)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetCharactorDTO>(dbCharactor);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharactorDTO>> UpdateCharactor(UpdateCharactorDTO updateCharactor)
        {
            ServiceResponse<GetCharactorDTO> response = new ServiceResponse<GetCharactorDTO>();
            try
            {
                var charactor = await _context.Charactors
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == updateCharactor.Id);

                if(charactor.User.Id == GetUserId())
                {
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
                else
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                }



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
                Charactor charactor = await _context.Charactors
                    .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

                if(charactor != null)
                {
                    _context.Charactors.Remove(charactor);
                    await _context.SaveChangesAsync();
                    response.Data = _context.Charactors
                        .Where(c => c.User.Id == GetUserId())
                        .Select(c => _mapper.Map<GetCharactorDTO>(c)).ToList();                    
                }
                else
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                }


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCharactorDTO>> AddCharactorSkill(AddCharactorSkillDTO newCharactorSkill)
        {
            var response = new ServiceResponse<GetCharactorDTO>();
            try
            {
                var charactor = await _context.Charactors
                    .Include(c => c.Weapons)
                    .Include(c => c.Skills)
                    .FirstOrDefaultAsync(c => c.Id == newCharactorSkill.CharactorId &&
                    c.User.Id == GetUserId());

                if(charactor == null)
                {
                    response.Success = false;
                    response.Message = "Charactor not found.";
                    return response;
                }

                var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == newCharactorSkill.SkillId);
                if(skill == null)
                {
                    response.Success = false;
                    response.Message = "Skill not found.";
                    return response;
                }

                charactor.Skills.Add(skill);
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
    }
}