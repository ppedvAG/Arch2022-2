using ppedv.Shopchestra.Model;
using Xunit;

namespace ppedv.Shopchestra.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void CalcBestellSumme_1_Pos_1_Menge_Results_12()
        {
            var b = new Bestellung();
            b.Positionen.Add(new BestellPosition() { Menge = 1, Einzelpreis = 12 });

            var core = new Core();

            var result = core.CalcBestellSumme(b);

            Assert.Equal(12m, result);
        }
    }
}