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
    public class LoginPage
    {
        private IWebDriver Driver { get; }
        private WebDriverWait wait;
        public LoginPage(IWebDriver browser)
        {
            
            Driver = browser;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(email));
            PageFactory.InitElements(Driver, this);
           
        }

        private readonly By email = By.Id("email");
        private IWebElement TxtUsername => Driver.FindElement(email);

        private readonly By password = By.Id("password");
        private IWebElement TxtPassword => Driver.FindElement(password);

        private readonly By login = By.Id("login-button");
        private IWebElement BtnLogin => Driver.FindElement(login);
        
        private readonly By error = By.XPath("//div[@class='alert alert-notice']");
        private IWebElement TxtError => Driver.FindElement(error);
       
        public void Login(string email, string password)
        {
            TxtUsername.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
        }
        public string InvalidLoginMessage()
        {
            wait.Until(e=>e.FindElement(error).Text.Length!=0);
            return TxtError.Text;
        }
       
    }
}
