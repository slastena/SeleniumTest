using System.Configuration;
using OpenQA.Selenium;
using SeleniumTest.PageObjects;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SeleniumTest.Bindings
{
    [Binding]
    public sealed class BicycleClaimPageBindings
    {

        //private IWebDriver driver => ScenarioContext.Current.Get<IWebDriver>();

        [Given(@"'(.*)' page is opened")]
        public void GivenBicycleClaimPageIsOpened(string url)
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings[url]);
        }

        [Given(@"page title should be '(.*)'")]
        public void GivenPageTitleShouldBe(string title)
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();
            var page = new BicycleClaimPage(driver);
            Assert.AreEqual(title.ToUpper(), page.GetTitle());
        }


        [Given(@"'(.*)' section visible")]
        public void GivenSectionVisible(string sectionName)
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();
            var page = new BicycleClaimPage(driver);
            var element = page.S1_WhatHasHappened.Header;
            Assert.AreEqual(sectionName.ToLower().Trim(), element.Text.ToLower().Trim());
        }

        [When(@"I click '(Send|Abort)' button")]
        public void WhenIClickButton(string buttonName)
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();
            var page = new BicycleClaimPage(driver);
            switch (buttonName)
            {
                case "Send":
                     page.Send();
                    break;
                default: page.Abort();
                    break;
            }
        }
 
    }
}
