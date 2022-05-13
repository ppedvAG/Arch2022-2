using ppedv.Shopchestra.Logic;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

namespace ppedv.ShopchestraUI.Blazor.Data
{
    public class InstrumenteService
    {

        public Core Core { get; }

        public InstrumenteService(IUnitOfWork uow)
        {
            Core = new Core(uow);
        }

        public void CreateNewPusteDing()
        {
            var newDing = new Musikinstrument()
            {
                Bezeichnung = "Pusteding",
                Beschreibung = "Nicht umdrehen!",
                Hersteller = "Bosch"
            };
            Core.UnitOfWork.GetRepository<Musikinstrument>().Add(newDing);
            Core.UnitOfWork.Save();
        }

        public void CreateDemos()
        {
            for (int i = 0; i < 10; i++)
            {
                var m = Core.GetDemodatenService().CreateDemoMusikinstrument();
                Core.UnitOfWork.GetRepository<Musikinstrument>().Add(m);
            }
            Core.UnitOfWork.Save();

        }
    }
}
