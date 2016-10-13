using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumTest.PageObjects;
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

        [Then("page title should be '(.*)'")]
        public void VerifyPageTitle(string title)
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();
            var page = new BicycleClaimObject(driver);
            Assert.AreEqual(title.ToUpper(), page.GetTitle());
        }
    }
}
