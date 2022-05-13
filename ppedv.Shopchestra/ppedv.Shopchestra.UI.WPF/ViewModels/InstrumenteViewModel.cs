using CommunityToolkit.Mvvm.ComponentModel;
using ppedv.Shopchestra.Logic;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ppedv.Shopchestra.UI.WPF.ViewModels
{
    public class InstrumenteViewModel /*: ObservableObject*/
    {
        Core core;

        public Musikinstrument SelectedInstrument { get; set; }

        public ObservableCollection<Musikinstrument> Musikinstrumente { get; set; } = new ObservableCollection<Musikinstrument>();

        public InstrumenteViewModel()
        {
            core = new Core(new Data.EfCore.EfUnitOfWork());
            LoadAll();
        }

        private void LoadAll()
        {
            Musikinstrumente.Clear();
            core.UnitOfWork.GetRepository<Musikinstrument>().GetAll().ToList().ForEach(x => Musikinstrumente.Add(x));
        }
    }
}
