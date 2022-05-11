using Moq;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var core = new Core(null);

            var result = core.CalcBestellSumme(b);

            Assert.Equal(12m, result);
        }

        [Fact]
        public void CalcBestellSumme_1_Pos_2_Menge_Results_24()
        {
            var b = new Bestellung();
            b.Positionen.Add(new BestellPosition() { Menge = 2, Einzelpreis = 12 });

            var core = new Core(null);

            var result = core.CalcBestellSumme(b);

            Assert.Equal(24m, result);
        }

        [Fact]
        public void CalcBestellSumme_2_Pos_2_Menge_Results_24()
        {
            var b = new Bestellung();
            b.Positionen.Add(new BestellPosition() { Menge = 2, Einzelpreis = 6 });
            b.Positionen.Add(new BestellPosition() { Menge = 2, Einzelpreis = 6 });

            var core = new Core(null);

            var result = core.CalcBestellSumme(b);

            Assert.Equal(24m, result);
        }

        [Fact]
        public void CalcBestellSumme_0_Pos_Results_0()
        {
            var b = new Bestellung();

            var core = new Core(null);

            var result = core.CalcBestellSumme(b);

            Assert.Equal(0m, result);
        }

        [Fact]
        public void CalcBestellSumme_Bestellung_null_throws_ArgumentNullEx()
        {
            var core = new Core(null);

            Assert.Throws<ArgumentNullException>(() => core.CalcBestellSumme(null));

            //Action act = () => core.CalcBestellSumme(null);
            //act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetVIPCustomer_3Kunden_Barney_should_be_VIP()
        {
            var core = new Core(new TestUoW());

            var result = core.GetVIPCustomer();

            Assert.Equal("Barney", result.Name);
        }

        //[Fact]
        //public void GetVIPCustomer_3Kunden_Barney_should_be_VIP_moq()
        //{
        //    var mock = new Mock<IRepository>();
        //    mock.Setup(x => x.GetAll<Kunde>()).Returns(() =>
        //    {
        //        var k1 = new Kunde() { Name = "Fred" };
        //        k1.Bestellungen.Add(new Bestellung());

        //        var k2 = new Kunde() { Name = "Barney" };
        //        k2.Bestellungen.Add(new Bestellung());
        //        k2.Bestellungen.Add(new Bestellung());
        //        k2.Bestellungen.Add(new Bestellung());

        //        var k3 = new Kunde() { Name = "Wilma" };
        //        k3.Bestellungen.Add(new Bestellung());
        //        k3.Bestellungen.Add(new Bestellung());

        //        return new[] { k1,  k3 , k2, };
        //    });

        //    var core = new Core(mock.Object);

        //    var result = core.GetVIPCustomer();

        //    Assert.Equal("Barney", result.Name);
        //}

    }

    class TestUoW : IUnitOfWork
    {
        public IRepository<T> GetRepository<T>() where T : Entity
        {
            return new TestRepo<T>();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }



    class TestRepo<T> : IRepository<T> where T : Entity 
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
           
                throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
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

                return new[] { k1, k2, k3 }.Cast<T>().AsQueryable();
            }
            else
                throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }

    
}