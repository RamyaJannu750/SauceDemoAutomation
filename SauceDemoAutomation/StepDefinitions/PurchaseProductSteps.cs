using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Gherkin.CucumberMessages.Types;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Internal;
using Gherkin.Ast;
using SauceDemoAutomation.Pages;
using System.Reflection.Emit;namespace MyProject.StepDefinitions
{
    [Binding]
    public class PurchaseProductSteps
    {
        private IWebDriver? driver;
        private LoginPage? loginPage;
        private ProductsPage productsPage;
        private CheckoutPage checkoutPage;
        private List<string> selectedProductNames;
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver("C:\\Users\\Ryzen\\source\\repos\\SauceDemoAutomation\\SauceDemoAutomation\\Drivers");
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            checkoutPage = new CheckoutPage(driver);
            driver.Manage().Window.Maximize();
        }
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
        [Given(@"I am on the SauceDemo login page")]
        public void GivenIAmOnTheSauceDemoLoginPage()
        {
            driver.Navigate().GoToUrl("http://www.saucedemo.com/");
        }
        [When(@"I log in with valid credentials")]
        public void WhenILogInWithValidCredentials()
        {
            loginPage.Login("standard_user", "secret_sauce");
        }
        [Then(@"I should be redirected to the SauceDemo products page")]
        public void ThenIShouldBeRedirectedToTheSauceDemoProductsPage()
        {
            // Verify that the products page is loaded
            Assert.AreEqual("Products", productsPage.productsTitle.Text);
        }
        [When(@"I add a product to my cart")]
        public void WhenIAddAProductToMyCart()
        {
            // Find and click on a product
            IWebElement product = driver.FindElement(By.CssSelector("div.inventory_item:nth-child(1)"));
            product.Click();
            // Find and click on the add to cart button
            IWebElement addToCartButton = driver.FindElement(By.CssSelector("button.btn_inventory"));
            addToCartButton.Click();
        }
        [Then(@"product should be added to the cart successfully")]
        public void Thenproductshouldbeaddedtothecartsuccessfully()
        {
            checkoutPage.cartIconBtn(); string expectedTitle = "Sauce Labs Backpack";
            Assert.AreEqual(expectedTitle, driver.FindElement(By.XPath("//*[@id=\"item_4_title_link\"]/div")).Text);
        }
        [When(@"I go to the cart page")]
        public void WhenIGoToTheCartPage()
        {
            // Find and click on the cart icon
            checkoutPage.cartIconBtn();
        }
        [When(@"I click on the checkout button")]
        public void WhenIClickOnTheCheckoutButton()
        {
            // Find and click on the checkout button
            checkoutPage.Checkout();
        }
        [Then(@"I should be on the SauceDemo checkout information page")]
        public void ThenIShouldBeOnTheSauceDemoCheckoutInformationPage()
        {
            // Verify that the checkout information page is loaded
            Assert.AreEqual("Checkout: Your Information", checkoutPage.checkoutTitle.Text);
        }
        [When(@"I enter my personal and payment information")]
        public void WhenIEnterMyPersonalAndPaymentInformation()
        {
            //continueButton Find and enter the first name, last name, and zip code
            checkoutPage.FillCheckoutInfo("John", "Peter", "12345");
        }
        [When(@"I click on the continue button")]
        public void WhenIClickOnTheContinueButton()
        {
            // Find and click on the continue button
            checkoutPage.ContinueBtn();
        }
        [Then(@"I should be on the SauceDemo checkout overview page")]
        public void ThenIShouldBeOnTheSauceDemoCheckoutOverviewPage()
        {
            // Verify that the checkout information page is loaded
            Assert.AreEqual("Checkout: Overview", checkoutPage.checkoutoverview.Text);
        }
        [Then(@"I should see the product I added to my cart")]
        public void ThenIShouldSeeTheProductIAddedToMyCart()
        {
            Assert.AreEqual("Sauce Labs Backpack", checkoutPage.addedproducts.Text);
        }
        [When(@"I click on the finish button")]
        public void WhenIClickOnTheFinishButton()
        {
            checkoutPage.FinishCheckout();
            // Find and click on the finish button checkoutPage.FinishCheckout();
        }

        [Then(@"I should be on the SauceDemo checkout complete page")]
        public void ThenIShouldBeOnTheSauceDemoCheckoutCompletePage()
        {
            Assert.AreEqual("Checkout: Complete!", checkoutPage.checkoutcomplete.Text);
        }

        [When(@"I add multiple products to my cart")]
        public void WhenIAddMultipleProductsToMyCart()
        {
            productsPage.AddMultipleToCart(); /*code to add multiple items*/
        }
    }
}
