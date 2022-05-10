using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

namespace ppedv.Shopchestra.Logic
{
    public class Core
    {
        public IRepository Repository { get; init; }

        public Core()
        {
            Repository = new Data.EfCore.EfRepository();
        }

        public Kunde? GetVIPCustomer()
        {
            return Repository.GetAll<Kunde>().OrderBy(x => x.Bestellungen.Count).FirstOrDefault();
        }


        public decimal CalcBestellSumme(Bestellung bestellung)
        {
            return bestellung.Positionen.Sum(x => x.Einzelpreis * (decimal)x.Menge);
        }

    }
}