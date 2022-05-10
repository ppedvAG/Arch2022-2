using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Shopchestra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ppedv.Shopchestra.Data.EfCore.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void Can_create_DB()
        {
            var context = new EfContext();
            context.Database.EnsureDeleted();

            var res = context.Database.EnsureCreated();

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Can_CRUD_Kunde()
        {
            var k = new Kunde() { Name = $"Fred{Guid.NewGuid()}" };
            string newName = $"Wilma{Guid.NewGuid()}";

            using (var context = new EfContext()) //CREATE
            {
                context.Kunden.Add(k);
                context.SaveChanges();
            }

            using (var context = new EfContext()) //READ + UPDATE
            {
                var loaded = context.Kunden.Find(k.Id);
                Assert.AreEqual(k.Name, loaded.Name);

                loaded.Name = newName;
                context.SaveChanges();
            }

            using (var context = new EfContext()) //check UPDATE + DELETE
            {
                var loaded = context.Kunden.Find(k.Id);
                Assert.AreEqual(newName, loaded.Name);

                context.Kunden.Remove(loaded);
                context.SaveChanges();
            }

            using (var context = new EfContext()) //READ + UPDATE
            {
                var loaded = context.Kunden.Find(k.Id);
                Assert.IsNull(loaded);
            }
        }


        [TestMethod]
        public void Can_CR_Kunde()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            
            //var k = fix.Build<Kunde>().Without(x => x.Id).Create();
            var k = fix.Create<Kunde>();

            using (var context = new EfContext())
            {
                context.Kunden.Add(k);
                context.SaveChanges();
            }
        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}