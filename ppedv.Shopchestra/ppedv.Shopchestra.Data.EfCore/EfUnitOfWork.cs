using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

namespace ppedv.Shopchestra.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext _context = new EfContext();

        public EfUnitOfWork()
        {
            kundenRepo = new EfKundenRepository(_context);
        }

        private EfKundenRepository kundenRepo;

        public IKundenRepository KundenRepository => kundenRepo;

       
        public IRepository<T> GetRepository<T>() where T : Entity
        {
            if (typeof(T) == typeof(Kunde))
                return kundenRepo as IRepository<T>;
            else
                return new EfRepository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
