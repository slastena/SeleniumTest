using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest.PageObjects;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumTest.Bindings
{
    [Binding]
    public sealed class S1_WhatHasHappenedBindings
    {
        [Given(@"all mandatory options filled in")]
        public void GivenAllMandatoryOptionsFilledIn()
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();
            var page = new BicycleClaimPage(driver);
            page.FillInMandatoryOptions("Bicycle has got broken", "27.11.2016", "St.Lucia", "", "In the middle of nowhere", "Seventy-seven benevolent elephants");
        }

        [Then(@"no errors shown for '(.*)' section")]
        public bool ThenNoErrorsShownForSection(string section)
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>();
            var page = new BicycleClaimPage(driver);
            var element = page.S1_WhatHasHappened.Header;
            return page.ErrorValidation();
        }

    }
}
