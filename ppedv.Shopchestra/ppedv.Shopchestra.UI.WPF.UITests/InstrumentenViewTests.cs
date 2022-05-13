using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace ppedv.Shopchestra.UI.WPF.UITests
{
    public class Tests
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string WpfAppId = @"C:\Users\Fred\source\repos\Arch2022-2\ppedv.Shopchestra\ppedv.Shopchestra.UI.WPF\bin\Debug\net6.0-windows\ppedv.Shopchestra.UI.WPF.exe";

        protected static WindowsDriver<WindowsElement> session;


        [SetUp]
        public void Setup()
        {
            if (session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);

            }
        }

        //[Test]
        //public void Test1()
        //{
        //    var grid = session.FindElementByAccessibilityId("datagrid");

        //    Assert.AreNotEqual(0, grid.GetProperty("Count"));
        //}     
        
        [Test]
        public void Test2()
        {
            //var item = session.FindElementByAccessibilityId("openMenuItem");
            var item = session.FindElementByAccessibilityId("tb");

            Assert.AreEqual("Öffnen", item.GetProperty("Header").ToString());
        }
    }
}