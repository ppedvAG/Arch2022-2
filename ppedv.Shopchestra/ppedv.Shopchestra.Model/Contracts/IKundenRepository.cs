namespace ppedv.Shopchestra.Model.Contracts
{
    public interface IKundenRepository : IRepository<Kunde>
    {
        IEnumerable<Kunde> GetKundenWithOpenBills();
    }
}
