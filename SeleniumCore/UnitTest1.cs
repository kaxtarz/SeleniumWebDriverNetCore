using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace SeleniumCore
{
    [TestClass]
    public class HomepageFeature
    {
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");

        }
    }
}
