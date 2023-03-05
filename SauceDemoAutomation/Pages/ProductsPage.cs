using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; namespace SauceDemoAutomation.Pages
{
    internal class ProductsPage
    {
        private readonly IWebDriver driver;
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement BtnAddToCart(string productName) => driver.FindElement(By.XPath($"//div[text()='{productName}']/ancestor::div[@class='inventory_item']//button"));
        public IWebElement BtnShoppingCart => driver.FindElement(By.CssSelector("a.shopping_cart_link"));
        public IWebElement productsTitle => driver.FindElement(By.XPath("//*[text()='Products']"));

        public void AddToCart(string productName)
        {
            BtnAddToCart(productName).Click();
        }
        public void GoToCart()
        {
            BtnShoppingCart.Click();
        }

        public IWebElement Elements => driver.FindElement(By.XPath($"//div[@class='inventory_list']"));
        /*adding multiple*/
        public void AddMultipleToCart()
        {
            object count = driver.FindElements(By.XPath($"//div[@class='inventory_item']")).Count;
            var item_count = count;
            var add_items = 3; //adding 3 for testing
            string item_string;
            Random r = new Random();

            // find all links inside 
           
            List<int> listNumbers = new List<int>();
            int number;

            for (int i = 0; i < add_items; i++)
            {
                do
                {
                    number = r.Next(0, (int)item_count);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
                item_string = "item_" + number + "_title_link";
                var item_name = Elements.FindElement(By.XPath($"//a[@id='{item_string}']")).Text;
                //Console.WriteLine(Elements.FindElement(By.XPath($"//a[@id='{item}']")).Text);
                BtnAddToCart(item_name).Click();
                //Thread.Sleep(2000);
            }
        }
    }
}