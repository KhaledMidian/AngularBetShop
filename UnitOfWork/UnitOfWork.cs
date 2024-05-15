using AngularBetShop.DBContext;
using AngularBetShop.Interfaces;
using AngularBetShop.Models;
using AngularBetShop.Repository;

namespace AngularBetShop.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly WFContext    _context;
        private IRepository<T> _entity;
        public UnitOfWork(WFContext context)
        {
            this._context = context;
        }

        public IRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity= new GRepository <T> (this._context));
            }
        }

        public void Save ()
        {
           _context.SaveChanges();
        }
    }
}
