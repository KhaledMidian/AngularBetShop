namespace AngularBetShop.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepository<T> Entity { get; }
        void Save();
    }
}
