using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AngularBetShop.Interfaces
{
    public interface IRepository<Entity>where Entity : class
    {
        public List<Entity> GetAll();
        public Entity GetById(int id);
        public void Delete (Entity iteme);
        public void Update(Entity iteme);
        public void Add(Entity iteme);
        public Entity GetElement(Func<Entity,bool>func,string? include);
        public List<Entity> GetElements(Func<Entity,bool>func,string? include);
        public void Save();

    }
}
