using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using NUnit.Framework;
using System.Linq;

namespace ppedv.Shopchestra.UI.WPF.UITests_FlaUI
{
    public class Tests
    {

        private const string wpfAppPath = @"C:\Users\Fred\source\repos\Arch2022-2\ppedv.Shopchestra\ppedv.Shopchestra.UI.WPF\bin\Debug\net6.0-windows\ppedv.Shopchestra.UI.WPF.exe";

        [OneTimeSetUp]
        public void SetUp()
        {

            app = FlaUI.Core.Application.Launch(wpfAppPath);
        }
        Application app;

        [Test]
        public void Test1()
        {
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);

                var m = window.FindFirstChild(cf => cf.ByAutomationId("menu"))?.AsMenu();
                
                Assert.AreEqual("Datei", m.Items.First().Text);
                m.Items.First().Click();
                //var mi = window.FindFirstChild(cf => cf.ByClassName(className: "MenuItem"))?.AsMenuItem();
                //Assert.AreEqual("Öffnen", mi.Text);
            }
        }

        [Test]
        public void TbTest()
        {
            
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);

                var tb = window.FindFirstDescendant(cf => cf.ByAutomationId("tb"))?.AsTextBox();
                Assert.AreEqual("Öffnen", tb.Text);
            }
        }
    }
}
