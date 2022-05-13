using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

namespace ppedv.ShopchestraUI.Blazor.Data
{
    public class InstrumenteService
    {
        public IUnitOfWork Uow { get; }


        public InstrumenteService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        public void CreateNewPusteDing()
        {
            var newDing = new Musikinstrument()
            {
                Bezeichnung = "Pusteding",
                Beschreibung = "Nicht umdrehen!",
                Hersteller = "Bosch"
            };
            Uow.GetRepository<Musikinstrument>().Add(newDing);
            Uow.Save();
        }
    }
}
