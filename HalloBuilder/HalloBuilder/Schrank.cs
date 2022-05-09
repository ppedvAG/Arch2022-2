using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloBuilder
{
    internal class Schrank
    {
        private Schrank()
        {

        }

        public int AnzahlTüren { get; private set; }
        public int AnzahlBöden { get; private set; }
        public string Farbe { get; private set; }
        public Oberfläche Oberfläche { get; private set; }

        public class SchrankBuilder
        {
            Schrank newSchrank = new Schrank();

           public SchrankBuilder SetTüren(int anzTüren)
            {
                if (anzTüren < 2 || anzTüren > 9)
                    throw new ArgumentException("Türen sind doof");

                newSchrank.AnzahlTüren = anzTüren;

                return this;
            }

            public SchrankBuilder SetBöden(int anzBöden)
            {
                if (anzBöden < 2 || anzBöden > 9)
                    throw new ArgumentException("Böden sind doof");

                newSchrank.AnzahlBöden = anzBöden;

                return this;
            }

            public Schrank Create() => newSchrank;
        }

    }

    enum Oberfläche
    {
        Unbehandelt,
        Gewachst,
        Lackiert
    }
}
