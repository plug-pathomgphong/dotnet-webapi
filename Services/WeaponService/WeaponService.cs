using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_webapi.Data;
using dotnet_webapi.Dtos.Charactor;
using dotnet_webapi.Dtos.Weapons;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<GetCharactorDTO>> AddWeapon(AddWeaponDTO newWeapon)
        {
            ServiceResponse<GetCharactorDTO> response = new ServiceResponse<GetCharactorDTO>();
            try
            {
                Charactor charactor = await _context.Charactors
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharactorId &&
                    c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                
                if(charactor == null)
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }

                Weapons weapon = new Weapons
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Charactor = charactor
                };

                _context.Weapons.Add(weapon);
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