using AutoTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutoTest
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;
       
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4200/login");
        }
        [TestMethod]
        public void TestLogin_SuccessFullyLogin()
        {
            var login = new LoginPage(driver);
            login.Login("george@yahoo.com", "abcd");
            var home = new HomePage(driver);
            var actualResults = home.GetWelcomeMessage();
            Assert.AreEqual("Profile", actualResults);

        }
        [TestMethod]
        public void TestLogin_WrongCredentialsLogin()
        {
            var login = new LoginPage(driver);
            login.Login("alex123@email.com", "invalid");
            var errorMessage = login.InvalidLoginMessage();
            Assert.AreEqual("Invalid email or password", errorMessage);
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

    }
}
