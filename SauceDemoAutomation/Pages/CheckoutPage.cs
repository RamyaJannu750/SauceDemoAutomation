using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;namespace SauceDemoAutomation.Pages
{
    internal class CheckoutPage
    {
        private readonly IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement TxtFirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement TxtLastName => driver.FindElement(By.Id("last-name"));
        public IWebElement TxtZipCode => driver.FindElement(By.Id("postal-code"));
        public IWebElement BtnContinue => driver.FindElement(By.CssSelector("input.btn_primary.cart_button"));
        public IWebElement BtnFinish => driver.FindElement(By.Id("finish"));
        public IWebElement cartIcon => driver.FindElement(By.CssSelector("a.shopping_cart_link"));
        public IWebElement addedproducts => driver.FindElement(By.XPath("//*[text()='Sauce Labs Backpack']"));
        public IWebElement checkoutoverview => driver.FindElement(By.ClassName("title"));
        public IWebElement checkoutTitle => driver.FindElement(By.ClassName("title"));
        public IWebElement checkoutButton => driver.FindElement(By.Id("checkout"));
        public IWebElement checkoutcomplete => driver.FindElement(By.ClassName("title"));
        public void FillCheckoutInfo(string firstName, string lastName, string zipCode)
        {
            TxtFirstName.SendKeys(firstName);
            TxtLastName.SendKeys(lastName);
            TxtZipCode.SendKeys(zipCode);
        }
        public void ContinueBtn()
        {
            BtnContinue.Click();
           // Thread.Sleep(2000);
        }
        public void FinishCheckout()
        {
            BtnFinish.Click();
           // Thread.Sleep(2000);
        }
        public void cartIconBtn()
        {
            cartIcon.Click();
          //  Thread.Sleep(2000);
        }
        public void Checkout()
        {
            checkoutButton.Click();
           // Thread.Sleep(2000);
        }
    }
}