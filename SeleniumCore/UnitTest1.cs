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
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            _driver = new ChromeDriver(outPutDirectory); // this chromedriver constructor needs to know where
                                                         //the chromedriver exec lives so we created outPutDirectory to tell where it lives

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginButtonLocator = By.Id("login-button");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(
                ExpectedConditions.ElementIsVisible(loginButtonLocator));

            var usernameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(loginButtonLocator);

            usernameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }
            [TestCleanup] //this cleans up the test by closing the browser afterwards 
            public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
