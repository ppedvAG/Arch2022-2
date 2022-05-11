namespace ppedv.Shopchestra.Model.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Query();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }

    public interface IUnitOfWork
    {
        void Save();

        IRepository<T> GetRepository<T>() where T : Entity;
    }
}
