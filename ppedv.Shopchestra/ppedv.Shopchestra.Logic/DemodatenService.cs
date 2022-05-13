using Bogus;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Shopchestra.Logic
{
    public class DemodatenService
    {
        private readonly IUnitOfWork uow;

        public DemodatenService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Musikinstrument CreateDemoMusikinstrument()
        {
            var faker = new Faker<Musikinstrument>("de");
            faker.UseSeed(5);
            faker.RuleFor(x => x.Beschreibung, x => x.Commerce.ProductDescription());
            faker.RuleFor(x => x.Bezeichnung, x => x.Commerce.ProductName());
            faker.RuleFor(x => x.Hersteller, x => x.Vehicle.Manufacturer());
            faker.RuleFor(x => x.Seriennummer, x => x.Commerce.Ean13()); ;
            faker.RuleFor(x => x.Preis, x => x.Commerce.Random.Decimal(1, 1000));
            faker.RuleFor(x => x.Klassifikation, x => x.PickRandom<Klassifikation>());
            faker.RuleFor(x => x.Material, x => x.PickRandom<Material>());

            return faker.Generate();
        }
    }
}
