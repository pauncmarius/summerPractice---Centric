using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest.PageObjects
{
    internal class HomePage
    { 
        private IWebDriver Driver { get; }

        public HomePage(IWebDriver browser)
        {
            Driver = browser;
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(welcome));
            PageFactory.InitElements(Driver, this);
        }

        private readonly By welcome = By.Id("test");
        private IWebElement TxtWelcome => Driver.FindElement(welcome);

        public string GetWelcomeMessage()
        {
            return TxtWelcome.Text;
    }
}
}
