using AngularBetShop.DTOs;
using AngularBetShop.Interfaces;
using AngularBetShop.Models;
using AngularBetShop.UnitOfWork;

namespace AngularBetShop.Services
{
    public class CartService
    {
        IUnitOfWork<Cart> _unite;
        public CartService(IUnitOfWork<Cart> unite)
        {
            this._unite = unite;
        }

        public List<CartDTO> GetAllCarts()
        {
            return _unite.Entity.GetAll().Select(c => new CartDTO(
            c.quantity,
            c.subPrice,
            c.productId,
            c.orderId
            )).ToList();

        }

        public List<CartDTO> GetCartById(int orderId, string? include)
        {
            return _unite.Entity.GetElements(c => c.orderId == orderId , include).Select(
                cart =>new CartDTO(
                cart.quantity,
                cart.subPrice,
                cart.productId,
                cart.orderId
                )).ToList();  
        }

        public void DeleteCart(CartDTO cartDTO)
        {
            _unite.Entity.Delete(_unite.Entity.GetElement(
                c => c.orderId == cartDTO.orderId && c.productId == cartDTO.productId, null));
            _unite.Save();
        }


        public void AddCart(CartDTO cartDTO)
        {
            Cart cart = new Cart
            {
                quantity = cartDTO.quantity,
                productId = cartDTO.productId,
                subPrice = cartDTO.subPrice,
                orderId=cartDTO.orderId
            };
            _unite.Entity.Add(cart);
            _unite.Save();


        }

        public void UpdateCart(CartDTO cartDTO)
        {

            Cart cart = new Cart
            {
                quantity = cartDTO.quantity,
                productId = cartDTO.productId,
                subPrice = cartDTO.subPrice,
                orderId = cartDTO.orderId
            };
            _unite.Entity.Update(cart);
            _unite.Save();


        }
    }
}
