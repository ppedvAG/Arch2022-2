using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

namespace ppedv.Shopchestra.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext _context = new EfContext();

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            return new EfRepository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected EfContext _context;

        public EfRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            //if(typeof(T) == typeof(Kunde))
            //    _context.Kunden.Add(entity as Kunde);

            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
