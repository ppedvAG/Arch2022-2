using Microsoft.Toolkit.Diagnostics;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

namespace ppedv.Shopchestra.Logic
{
    public class Core
    {
        public IUnitOfWork UnitOfWork { get; init; }

        public Core(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Kunde? GetVIPCustomer()
        {
                             //.MaxBy(x => x.Bestellungen.Count);
            return UnitOfWork.GetRepository<Kunde>().Query()
                             .OrderByDescending(x => x.Bestellungen.Count)
                             .FirstOrDefault();
        }


        public decimal CalcBestellSumme(Bestellung bestellung)
        {
            //if (bestellung == null)
            //    throw new ArgumentNullException();
            Guard.IsNotNull(bestellung, nameof(bestellung));
            Guard.IsNotNull(bestellung.Positionen, nameof(bestellung.Positionen));

            return bestellung.Positionen.Sum(x => x.Einzelpreis * (decimal)x.Menge);
        }

    }
}