using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LibraryAppAutomatedUITests
{
    [TestClass]
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _webDriver;
        public AutomatedUITests() => _webDriver = new ChromeDriver(@"C:\\Users\\Nandhini\\.nuget\\packages\\selenium.webdriver.chromedriver\\96.0.4664.4500\\driver\\win32");
        public void Dispose()
        {
            _webDriver.Quit();
            _webDriver.Dispose();

        }
     
        [TestMethod]
        public void Create_WrongModelData_ReturnsErrorMessage()
        {
            _webDriver.Navigate()
                .GoToUrl("https://localhost:44377/Book/Create");

            _webDriver.FindElement(By.Id("BookName"))
                .SendKeys("Book1");


            _webDriver.FindElement(By.Id("PublisherName"))
                .SendKeys("Test Publisher");

            

            _webDriver.FindElement(By.Id("PublishedDate"))
                .SendKeys("12/12/2000");

            _webDriver.FindElement(By.Id("AutherName"))
                .SendKeys("Test Author");


            _webDriver.FindElement(By.Id("Version"))
                .SendKeys("1");

            _webDriver.FindElement(By.Id("Quantity"))
                .SendKeys("1");

            _webDriver.FindElement(By.Id("Create"))
                .Click();

            var errorMessage = _webDriver.FindElement(By.Id("BookPrice-error")).Text;

            Assert.AreEqual("Book Price Required", errorMessage);
        }

    }
}
