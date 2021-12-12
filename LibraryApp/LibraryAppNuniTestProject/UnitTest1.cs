using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;


namespace LibraryAppNuniTestProject
{
    public class Tests
    {
        IWebDriver webDriver;

        [SetUp]
        public void openBrowser()
        {
            webDriver = new ChromeDriver(@"C:\Users\Nandhini\.nuget\packages\selenium.webdriver.chromedriver\96.0.4664.4500\driver\win32");
        }

        [Test]
        public void Test_LoginMethod_Pass()
        {
            webDriver.Url = "https://localhost:44377/Identity/Account/Login";
            webDriver.Manage().Window.Maximize();
            IWebElement emailTexbox = webDriver.FindElement(By.XPath(".//*[@id='Input_Email']"));
            IWebElement passWord = webDriver.FindElement(By.XPath(".//*[@id='Input_Password']"));
            IWebElement loginButton = webDriver.FindElement(By.XPath(".//*[@id='account']/div[5]/button"));
            emailTexbox.SendKeys("Test3@gmail.com");
            passWord.SendKeys("Testing@123");
            loginButton.Click();
            
        }
        [Test]
        public void Test_InvalidLogin()
        {
            webDriver.Url = "https://localhost:44377/Identity/Account/Login";
            webDriver.Manage().Window.Maximize();
            IWebElement emailTexbox = webDriver.FindElement(By.XPath(".//*[@id='Input_Email']"));
            IWebElement passWord = webDriver.FindElement(By.XPath(".//*[@id='Input_Password']"));
            IWebElement loginButton = webDriver.FindElement(By.XPath(".//*[@id='account']/div[5]/button"));
            emailTexbox.SendKeys("Test3@gmail.com");
            passWord.SendKeys("Testing@13");
            loginButton.Click();

        }
        [Test]
        public void Test_AddBookButton()
        {
            Test_LoginMethod_Pass();
            IWebElement addBookButton = webDriver.FindElement(By.Id("Create"));
            addBookButton.Click();
        }
        [Test]
        public void Test_InvalidBookModelCreate()
        {
            Test_LoginMethod_Pass();
             webDriver.Manage().Window.Maximize();
            IWebElement bookName = webDriver.FindElement(By.Id("BookName"));
            IWebElement publisherName = webDriver.FindElement(By.Id("PublisherName"));
            IWebElement publishedDate = webDriver.FindElement(By.Id("PublishedDate"));
            IWebElement authorName = webDriver.FindElement(By.Id("AutherName"));
            IWebElement version = webDriver.FindElement(By.Id("Version"));
            IWebElement bookPrice = webDriver.FindElement(By.Id("BookPrice"));
            IWebElement fileName = webDriver.FindElement(By.Id("FileName"));
            IWebElement createButton = webDriver.FindElement(By.Id("Create")) ;
            bookName.SendKeys("Testbook");
            publisherName.SendKeys("TestPublisher");
            publishedDate.SendKeys("12/12/2000");
            authorName.SendKeys("TestAuthor");
            version.SendKeys("1");
            bookPrice.SendKeys("300");
            fileName.SendKeys("TestFile");
            createButton.Click();
            ///html/body/div/main/div/table/tbody/tr[1]/td[9]/div/a[1]

        }
        [Test]
        public void Test_ValidBookModelCreate()
        {
            Test_AddBookButton();
            webDriver.Manage().Window.Maximize();
            IWebElement bookName = webDriver.FindElement(By.Id("BookName"));
            IWebElement publisherName = webDriver.FindElement(By.Id("PublisherName"));
            IWebElement publishedDate = webDriver.FindElement(By.Id("PublishedDate"));
            IWebElement authorName = webDriver.FindElement(By.Id("AutherName"));
            IWebElement version = webDriver.FindElement(By.Id("Version"));
            IWebElement bookPrice = webDriver.FindElement(By.Id("BookPrice"));
            IWebElement fileName = webDriver.FindElement(By.Id("FileName"));
            IWebElement quanity = webDriver.FindElement(By.Id("Quantity"));
            IWebElement createButton = webDriver.FindElement(By.Id("Create"));
            bookName.SendKeys("Testbook");
            publisherName.SendKeys("TestPublisher");
            publishedDate.SendKeys("12/12/2000");
            authorName.SendKeys("TestAuthor");
            version.SendKeys("1");
            bookPrice.SendKeys("300");
            fileName.SendKeys("TestFile");
            quanity.SendKeys("1");
            createButton.Click();

        }

        [Test]
        public void Test_UpdateBookMethod()
        {
            Test_AddBookButton();
            webDriver.Manage().Window.Maximize();
            IWebElement bookName = webDriver.FindElement(By.Id("BookName"));
            IWebElement publisherName = webDriver.FindElement(By.Id("PublisherName"));
            IWebElement publishedDate = webDriver.FindElement(By.Id("PublishedDate"));
            IWebElement authorName = webDriver.FindElement(By.Id("AutherName"));
            IWebElement version = webDriver.FindElement(By.Id("Version"));
            IWebElement bookPrice = webDriver.FindElement(By.Id("BookPrice"));
            IWebElement fileName = webDriver.FindElement(By.Id("FileName"));
            IWebElement quanity = webDriver.FindElement(By.Id("Quantity"));
            IWebElement createButton = webDriver.FindElement(By.Id("Create"));
            bookName.SendKeys("Testbook");
            publisherName.SendKeys("TestPublisher");
            publishedDate.SendKeys("12/12/2000");
            authorName.SendKeys("TestAuthor");
            version.SendKeys("1");
            bookPrice.SendKeys("300");
            fileName.SendKeys("TestFile");
            quanity.SendKeys("1");
            createButton.Click();

        }
        //BookName PublisherName PublishedDate AutherName Version BookPrice FileName Quantity  Create  Quantity-error

        //[TearDown]
        //public void closeBrowser()
        //{
        //    webDriver.Close();
        //}
    }
}