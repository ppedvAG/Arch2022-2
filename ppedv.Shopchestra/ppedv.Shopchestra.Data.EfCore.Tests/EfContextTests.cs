using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}