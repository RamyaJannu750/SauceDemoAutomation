using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; namespace SauceDemoAutomation.Pages
{
    internal class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement TxtUsername => driver.FindElement(By.Id("user-name"));
        public IWebElement TxtPassword => driver.FindElement(By.Id("password"));
        public IWebElement BtnLogin => driver.FindElement(By.CssSelector("input.btn_action"));
        public void Login(string username, string password)
        {
            TxtUsername.SendKeys(username);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
        }
    }
}