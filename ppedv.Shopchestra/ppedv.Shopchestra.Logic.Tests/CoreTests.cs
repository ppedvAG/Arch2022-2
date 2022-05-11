using Moq;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;
using System;
using System.Collections.Generic;
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

        [Fact]
        public void GetVIPCustomer_3Kunden_Barney_should_be_VIP()
        {
            var core = new Core(new TestRepo());

            var result = core.GetVIPCustomer();

            Assert.Equal("Barney", result.Name);
        }

        [Fact]
        public void GetVIPCustomer_3Kunden_Barney_should_be_VIP_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Kunde>()).Returns(() =>
            {
                var k1 = new Kunde() { Name = "Fred" };
                k1.Bestellungen.Add(new Bestellung());

                var k2 = new Kunde() { Name = "Barney" };
                k2.Bestellungen.Add(new Bestellung());
                k2.Bestellungen.Add(new Bestellung());
                k2.Bestellungen.Add(new Bestellung());

                var k3 = new Kunde() { Name = "Wilma" };
                k3.Bestellungen.Add(new Bestellung());
                k3.Bestellungen.Add(new Bestellung());

                return new[] { k1,  k3 , k2, };
            });

            var core = new Core(mock.Object);

            var result = core.GetVIPCustomer();

            Assert.Equal("Barney", result.Name);
        }

    }

    class TestRepo : IRepository
    {
        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T) == typeof(Kunde))
            {
                var k1 = new Kunde() { Name = "Fred" };
                k1.Bestellungen.Add(new Bestellung());

                var k2 = new Kunde() { Name = "Barney" };
                k2.Bestellungen.Add(new Bestellung());
                k2.Bestellungen.Add(new Bestellung());
                k2.Bestellungen.Add(new Bestellung());

                var k3 = new Kunde() { Name = "Wilma" };
                k3.Bestellungen.Add(new Bestellung());
                k3.Bestellungen.Add(new Bestellung());

                yield return k1 as T;
                yield return k2 as T;
                yield return k3 as T;
            }
            else
                throw new NotImplementedException();
        }
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }


        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}