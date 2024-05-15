using AngularBetShop.DTOs;
using AngularBetShop.Interfaces;
using AngularBetShop.Models;
using AngularBetShop.UnitOfWork;
using System;

namespace AngularBetShop.Services
{
    public class FavoritesSevice
    {
        IUnitOfWork<Favorites> _unite;
        public FavoritesSevice(IUnitOfWork<Favorites> unite)
        {
            this._unite = unite;
        }

        public List<FavoritesDTO> GetAllFavoritess()
        {
            return _unite.Entity.GetAll().Select(f=> new FavoritesDTO (f.appUserId,
            f.productId
            )).ToList();

        }

        public List<FavoritesDTO> GetFavoritesById(string userId, string? include)
        {
            return _unite.Entity.GetElements(p => p.appUserId == userId, include)
                .Select(fav => new FavoritesDTO(fav.appUserId,fav.productId)).ToList();
        }

        public void DeleteFavorites(FavoritesDTO dTO)
        {
            _unite.Entity.Delete(_unite.Entity.GetElement(
                p => p.appUserId == dTO.appUserId && p.productId == dTO.productId, null));
            _unite.Save();
        }


        public void AddFavorites(FavoritesDTO favoritesDTO)
        {
            Favorites favorites = new Favorites
            {
                appUserId = favoritesDTO.appUserId,
                productId = favoritesDTO.productId
            };
            _unite.Entity.Add(favorites);
            _unite.Save();

        }

        public void UpdateFavorites(FavoritesDTO favoritesDTO)
        {

            Favorites favorites = new Favorites
            {
                appUserId = favoritesDTO.appUserId,
                productId = favoritesDTO.productId
            };
            _unite.Entity.Update(favorites);
            _unite.Save();

        }
    }
}
