using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumCore
{
    [TestClass]
    public class HomepageFeature
    {
        IWebDriver _driver;
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); // this is saying we are storing the stuff when executed

            _driver = new ChromeDriver(outPutDirectory); // this chromedriver constructor needs to know where
                                                         //the chromedriver exec lives so we created outPutDirectory to tell where it lives

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/"); // this method runs and goes to the url

            var loginButtonLocator = By.Id("login-button"); // this object is created to hold the thing we're looking for

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(
                ExpectedConditions.ElementIsVisible(loginButtonLocator)); //this a wait

            var usernameField = _driver.FindElement(By.Id("user-name")); //here we created more objects to find elements and interact with the UI
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(loginButtonLocator);

            usernameField.SendKeys("standard_user"); // here we are using that object to interact with things
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html")); //you always need to assert, this checks for things
        }
            [TestCleanup] //this cleans up the test by closing the browser afterwards 
            public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
