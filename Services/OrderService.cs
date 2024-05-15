using AngularBetShop.DTOs;
using AngularBetShop.Interfaces;
using AngularBetShop.Models;
using AngularBetShop.UnitOfWork;
using System.Collections.Generic;

namespace AngularBetShop.Services
{
    public class OrderService
    {
        IUnitOfWork<Order> _unite;
        public OrderService(IUnitOfWork<Order> unite)
        {
            this._unite = unite;
        }

        public List<OrderDOT> GetAllOrders()
        {
            return _unite.Entity.GetAll().Select(d => new OrderDOT
            (d.id,
            d.quantity,
            d.state,
            d.totalPrice,
            d.checkOutDate,
            d.appUserId)).ToList();

        }

        public OrderDOT GetOrderById(int id)
        {
            Order order = _unite.Entity.GetById(id);
            if (order == null) { return null; }
            return new OrderDOT
            (order.id,
            order.quantity,
            order.state,
            order.totalPrice,
            order.checkOutDate,
            order.appUserId);

        }

        public void DeleteOrder(int id)
        {
            _unite.Entity.Delete(_unite.Entity.GetById(id));
            _unite.Save();
        }


        public void AddOrder(OrderAddDOT orderDTO)
        {
            Order order = new Order
            {
                
                quantity = orderDTO.quantity,
                state = orderDTO.state,
                totalPrice = orderDTO.totalPrice,
                checkOutDate = orderDTO.checkOutDate,
                appUserId = orderDTO.appUserId,
            };
            _unite.Entity.Add(order);
            _unite.Save();

        }

        public void UpdateOrder(OrderDOT orderDTO)
        {

            Order order = new Order
            {
                id = orderDTO.id,
                quantity = orderDTO.quantity,
                state = orderDTO.state,
                totalPrice = orderDTO.totalPrice,
                checkOutDate = orderDTO.checkOutDate,
                appUserId = orderDTO.appUserId
                
            };
            _unite.Entity.Update(order);
            _unite.Save();

        }

    }
}
