using ppedv.Shopchestra.Model;
using System;
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

        [Fact]
        public void CalcBestellSumme_1_Pos_2_Menge_Results_24()
        {
            var b = new Bestellung();
            b.Positionen.Add(new BestellPosition() { Menge = 2, Einzelpreis = 12 });

            var core = new Core();

            var result = core.CalcBestellSumme(b);

            Assert.Equal(24m, result);
        }

        [Fact]
        public void CalcBestellSumme_2_Pos_2_Menge_Results_24()
        {
            var b = new Bestellung();
            b.Positionen.Add(new BestellPosition() { Menge = 2, Einzelpreis = 6 });
            b.Positionen.Add(new BestellPosition() { Menge = 2, Einzelpreis = 6 });

            var core = new Core();

            var result = core.CalcBestellSumme(b);

            Assert.Equal(24m, result);
        }

        [Fact]
        public void CalcBestellSumme_0_Pos_Results_0()
        {
            var b = new Bestellung();

            var core = new Core();

            var result = core.CalcBestellSumme(b);

            Assert.Equal(0m, result);
        }

        [Fact]
        public void CalcBestellSumme_Bestellung_null_throws_ArgumentNullEx()
        {
            var core = new Core();

            Assert.Throws<ArgumentNullException>(() => core.CalcBestellSumme(null));

            //Action act = () => core.CalcBestellSumme(null);
            //act.Should().Throw<ArgumentNullException>();
        }
    }
}