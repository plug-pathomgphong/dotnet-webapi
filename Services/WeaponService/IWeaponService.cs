using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Dtos.Charactor;
using dotnet_webapi.Dtos.Weapons;

namespace dotnet_webapi.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharactorDTO>> AddWeapon(AddWeaponDTO newWeapon);
    }
}