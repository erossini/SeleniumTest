using NUnit.Framework;
using NUnitTestProject1.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NUnitTestProject1
{
    public class Tests
    {
        private IWebDriver driver;
        string hubUrl;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [SetUp]
        public void Setup()
        {
            vars = new Dictionary<string, object>();

            hubUrl = "http://localhost:4444/wd/hub";
            driver = LocalDriverFactory.CreateInstance(Enums.BrowserType.Edge, hubUrl);
            js = (IJavaScriptExecutor)driver;
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        [Parallelizable]
        public void OpenGoogleAndSearch()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
        }

        [Test]
        [Parallelizable]
        public void OpenBingAndSearch()
        {
            driver.Navigate().GoToUrl("https://www.bing.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to seee this on a remote machine");
        }

        [Test]
        [Parallelizable]
        public void SearchOnPureSourceCode()
        {
            driver.Navigate().GoToUrl("https://www.puresourcecode.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.CssSelector("#simplemodal-container a.modalCloseImg")).Click();
            driver.FindElement(By.CssSelector("#search-2 > #searchform .form-control")).Click();
            driver.FindElement(By.CssSelector("#search-2 > #searchform .form-control")).SendKeys("adminlte");
            driver.FindElement(By.CssSelector("#search-2 > #searchform .btn")).Click();
            js.ExecuteScript("window.scrollTo(0,1929)");
            js.ExecuteScript("window.scrollTo(0,2463)");
            js.ExecuteScript("window.scrollTo(0,1198)");
            js.ExecuteScript("window.scrollTo(0,1037)");
            js.ExecuteScript("window.scrollTo(0,437)");
            driver.FindElement(By.CssSelector(".d-md-flex:nth-child(1) .title > a")).Click();

            var element = driver.FindElement(By.CssSelector(".homebtn"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }
    }
}