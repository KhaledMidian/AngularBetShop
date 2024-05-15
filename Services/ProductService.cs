using AngularBetShop.DTOs;
using AngularBetShop.Interfaces;
using AngularBetShop.Models;
using AngularBetShop.UnitOfWork;
using System.Collections.Generic;
using System.Net.Sockets;

namespace AngularBetShop.Services
{
    public class ProductService
    {
        IUnitOfWork<Product> _unite;
        public ProductService(IUnitOfWork<Product> unite)
        {
            this._unite = unite;
        }

        public List<ProductDTO> GetAllProducts()
        {
            return _unite.Entity.GetAll().Select(p=>new ProductDTO
            (p.id,
            p.name,
            p.description,
            p.price,
            p.rating,
            p.quantity,
            p.categoryId,
            p.image)).ToList();

        }

        public ProductDTO? GetProductById(int id)
        {
            Product? product = _unite.Entity.GetById(id);
            if (product == null) return null;
            ProductDTO? productDTO=new ProductDTO
            (product.id,
            product.name,
            product.description,
            product.price,
            product.rating,
            product.quantity,
            product.categoryId,
            product.image);
            return productDTO;

        }

        public void DeleteProduct(int id)
        {
            _unite.Entity.Delete(_unite.Entity.GetById(id));
            _unite.Save();

        }


        public void AddProduct(ProductAddDTO productDTO)
        {
            Product product = new Product ()
            {
               
                name = productDTO.name,
                description = productDTO.description,
                price = productDTO.price,
                rating = productDTO.rating,
                quantity = productDTO.quantity,
                categoryId = productDTO.categoryId,
                image = productDTO.image
            };
            _unite.Entity.Add(product);
            _unite.Save();


        }

        public void UpdateProduct(ProductDTO productDTO)
        {

            Product product = new Product
            {
                id = productDTO.id,
                name = productDTO.name,
                description = productDTO.description,
                price = productDTO.price,
                rating = productDTO.rating,
                quantity = productDTO.quantity,
                categoryId = productDTO.categoryId,
                image = productDTO.image

            };
            _unite.Entity.Update(product);
            _unite.Save();

        }

        



    }
}
