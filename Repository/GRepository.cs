using AngularBetShop.DBContext;
using AngularBetShop.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace AngularBetShop.Repository
{
    public class GRepository<T> : IRepository<T> where T : class
    {
        private WFContext _context;
        public GRepository(WFContext context)
        {
            _context = context;
        }
        public void Add(T iteme)
        {
            _context.Set<T>().Add(iteme);
        }

        public void Delete(T iteme)
        {
            _context.Set<T>().Remove(iteme);
        }

        public List<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetElement(Func<T, bool> func, string? include)
        {
            if (include != null)
            {
                return _context.Set<T>().Include(include).Where(func).FirstOrDefault();
            }
            return _context.Set<T>().Where(func).FirstOrDefault();
        }

        public List<T> GetElements(Func<T, bool> func, string? include)
        {
            if (include != null) 
            { 
                return _context.Set<T>().Include(include).Where(func).ToList();
            }
            return _context.Set<T>().Where(func).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T iteme)
        {
            _context.Set<T>().Update(iteme);
        }
    }
}