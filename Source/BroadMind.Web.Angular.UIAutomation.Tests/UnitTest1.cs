using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace BroadMind.Web.Angular.UIAutomation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InternetExplorerCompatibility()
        {
            IWebDriver driver = new InternetExplorerDriver();
            // And now use this to visit Google
            driver.Navigate().GoToUrl("https://www.google.com");
            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("q"));
            // Enter something to search for
            query.SendKeys("Hillary clinton Georgia poll numbers");
            // Submit the form based on an element in the form
            query.Submit();
            // Check the title of the page
            Console.WriteLine(driver.Title);
        }

        [TestMethod]
        public void ChromiumCompatibility()
        {
            IWebDriver driver = new ChromeDriver();
            // And now use this to visit Google
            driver.Navigate().GoToUrl("https://www.google.com");
            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("q"));
            // Enter something to search for
            query.SendKeys("Hillary clinton chances of winning Florida");
            // Submit the form based on an element in the form
            query.Submit();
            // Check the title of the page
            Console.WriteLine(driver.Title);
        }

        [TestMethod]
        public void FireFoxCompatibility()
        {
            IWebDriver driver = new FirefoxDriver();
            // And now use this to visit Google
            driver.Navigate().GoToUrl("https://www.google.com/");
            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("q"));
            // Enter something to search for
            query.SendKeys("Hillary clinton chances of winning Pennsylvania");
            // Submit the form based on an element in the form
            query.Submit();
            // Check the title of the page
            Console.WriteLine(driver.Title);
        }
    }
}
