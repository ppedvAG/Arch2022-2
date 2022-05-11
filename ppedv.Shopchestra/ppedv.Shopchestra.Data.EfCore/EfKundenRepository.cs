using Microsoft.EntityFrameworkCore;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

namespace ppedv.Shopchestra.Data.EfCore
{
    public class EfKundenRepository : EfRepository<Kunde>, IKundenRepository
    {
        public EfKundenRepository(EfContext context) : base(context)
        { }

        public IEnumerable<Kunde> GetKundenWithOpenBills()
        {


            //_context.Database.ExecuteSqlRaw("SELECT * FROM...");
            return _context.Kunden
                           .Include(x => x.Bestellungen) //eager Loader
                           .ThenInclude(x => x.Positionen)
                           .ThenInclude(x => x.Produkt)
                           .OrderBy(x => x.Bestellungen.Count());
        }

        public override void Add(Kunde entity)
        {
            base.Add(entity);
            //....
        }
    }
}
