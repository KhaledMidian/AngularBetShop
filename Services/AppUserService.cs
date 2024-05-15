using AngularBetShop.DTOs;
using AngularBetShop.Interfaces;
using AngularBetShop.Models;
using AngularBetShop.UnitOfWork;
using System.Security.Cryptography;

namespace AngularBetShop.Services
{
    public class AppUserService
    {
        public class UserService
        {
            IUnitOfWork<AppUser> _unit;
            public UserService(IUnitOfWork<AppUser> unit)
            {
                this._unit = unit;
            }

            public List<AppUserDTO> GetAll()
            {
                return _unit.Entity.GetAll().Select(a => new AppUserDTO(a.Id,
            a.UserName,
            a.Email,
            a.PasswordHash,
            a.PhoneNumber)).ToList();
            }


            public AppUserDTO GetById(string id)
            {

                AppUser appUser = _unit.Entity.GetElement(a => a.Id == id, null);
                return new AppUserDTO(appUser.Id,
                                        appUser.UserName,
                                        appUser.Email,
                                        appUser.PasswordHash,
                                        appUser.PhoneNumber);
            }

            public void Update(AppUserDTO appUserDTO)
            {
                AppUser appUser = new AppUser()
                {
                    Id = appUserDTO.id ,
                    UserName = appUserDTO.userName,
                    Email = appUserDTO.email,
                    PasswordHash = appUserDTO.passwordHash,
                    PhoneNumber = appUserDTO.phoneNumber,
                    orderList = appUserDTO.orderList,
                    favoriteProducts = appUserDTO.favoriteProducts
                };
                _unit.Entity.Update(appUser);
            }

            public void Delete(string id)
            {
                AppUser appUser = _unit.Entity.GetElement(a=> a.Id == id, null);
                _unit.Entity.Delete(appUser);
            }


            public void Add(AppUserDTO appUserDTO)
            {
                AppUser appUser = new AppUser()
                {
                    Id = appUserDTO.id,
                    UserName = appUserDTO.userName,
                    Email = appUserDTO.email,
                    PasswordHash = appUserDTO.passwordHash,
                    PhoneNumber = appUserDTO.phoneNumber,
                    orderList = appUserDTO.orderList,
                    favoriteProducts = appUserDTO.favoriteProducts
                };
                _unit.Entity.Add(appUser);
            }

            public void Save()
            {
                _unit.Save();
            }
        }
        
    }
}
