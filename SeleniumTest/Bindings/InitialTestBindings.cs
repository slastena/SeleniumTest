using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumTest.Bindings
{
    [Binding]
    public sealed class InitialTestBindings
    {
        [Given("I have opened (.*)")]
        public void NavigateToUrl(string url)
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();

            driver.Navigate().GoToUrl(new Uri(url));
        }

        [Then("search page should be visible")]
        public void SearchPageIsVisible()
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();

            var element = driver.FindElement(By.Id("lst-ib"));
            Assert.IsNotNull(element);
        }
    }
}
