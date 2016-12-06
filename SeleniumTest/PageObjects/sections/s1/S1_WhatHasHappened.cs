using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumTest.PageObjects.sections.s1.scope;

namespace SeleniumTest.PageObjects.sections
{
    public class S1_WhatHasHappened
    {
        private static IWebDriver _driver;
        private IWebElement _section;

        private By _sectionLocator = By.Id("eventForm_section");
        private By _S1headerLocator = By.CssSelector("#eventForm_section > header > ul > li.ecmt-grid-cell.ecmt-width-1of2.accordion-header > span");

        public IWebElement Header => _section.FindElement(_S1headerLocator);

        public IncidentType IncidentType => new IncidentType(_driver);
        public IncidentDate IncidentDate => new IncidentDate(_driver);
        public IncidentLocation IncidentLocation => new IncidentLocation(_driver);
        public IncidentDescription IncidentDescription => new IncidentDescription(_driver);

        public S1_WhatHasHappened(IWebDriver driver)
        {
            _driver = driver;
            _section = _driver.FindElement(_sectionLocator);
        }
    }
}
