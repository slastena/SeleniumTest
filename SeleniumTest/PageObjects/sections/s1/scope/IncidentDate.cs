using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTest.PageObjects.sections.s1.scope
{
    public class IncidentDate
    {
        private static IWebElement _incidentDate;

        private static IWebDriver _driver;
        private static IWebElement _section;

        private static By _sectionLocator = By.Id("eventForm_section");
        private static By _incidentDateLocator = By.Name("bicycleStolenDateWithHeaderInput");

        public IncidentDate(IWebDriver driver)
        {
            var section = driver.FindElement(_sectionLocator);
            var scope = section.FindElements(By.TagName("ol")).ElementAt(2);
            _incidentDate = scope.FindElement(_incidentDateLocator);
        }

        public void SetIncidentDate(string date)
        {
            _incidentDate.SendKeys(date);
            _incidentDate.SendKeys(Keys.Enter);
        }

        public string GetIncidentDate()
        {
            return _incidentDate.Text;
        }
        public bool isIncidentDateSet()
        {
            var element = _driver.FindElement(_incidentDateLocator).FindElement(By.XPath("input")).GetAttribute("Class");
            return (element.Contains("ng-not-empty") && element.Contains("ng-valid-parse") && element.Contains("ng-valid-required"));
        }

        public bool NoneSelected()
        {
            var errorElement = _driver.FindElement(By.Id("bicycleStolenDateWithHeaderErrorMessage")).GetAttribute("Text");
            return (!string.IsNullOrEmpty(errorElement));
        }
    }
}
