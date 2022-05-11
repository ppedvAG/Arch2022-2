namespace ppedv.Shopchestra.Model.Contracts
{
    public interface IUnitOfWork
    {
        void Save();

        IKundenRepository KundenRepository { get; }

        IRepository<T> GetRepository<T>() where T : Entity;
    }
}
