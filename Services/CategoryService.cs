using AngularBetShop.DTOs;
using AngularBetShop.Interfaces;
using AngularBetShop.Models;
using AngularBetShop.UnitOfWork;
using System.Collections.Generic;

namespace AngularBetShop.Services
{
    public class CategoryService
    {

        IUnitOfWork<Category> _unite;
        public CategoryService(IUnitOfWork<Category> unite)
        {
            this._unite = unite;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _unite.Entity.GetAll().Select(c => new CategoryDTO
            (c.id,
            c.name)).ToList();

        }

        public CategoryDTO? GetCategoryById(int id)
        {
            Category? category = _unite.Entity.GetById(id);
            if (category == null) return null;
            CategoryDTO? categoryDTO= new CategoryDTO
            (category.id,
            category.name
            );
            return categoryDTO;
        }

        public void DeleteCategory(int id)
        {
            _unite.Entity.Delete(_unite.Entity.GetById(id));
            _unite.Save();
        }


        public void AddCategory(CategoryAddDTO categoryDTO)
        {
            Category category = new Category
            {
               
                name = categoryDTO.name,
            };
            _unite.Entity.Add(category);
            _unite.Save();
        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {

            Category category = new Category
            {
                id = categoryDTO.id,
                name = categoryDTO.name,
            };
            _unite.Entity.Update(category);
            _unite.Save();
        }

    }
}
