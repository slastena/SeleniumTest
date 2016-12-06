using System;
using System.Linq;
using OpenQA.Selenium;

namespace SeleniumTest.PageObjects.sections.s1.scope
{
    public class IncidentDescription
    {
        private static IWebElement _incidentDescription;

        private static IWebDriver _driver;
        private static IWebElement _section;

        private By _sectionLocator = By.Id("eventForm_section");
        private By _incidentDescriptionLocator = By.Id("bicycleEventDescriptionTextAreaWithHeaderInput");

        public IncidentDescription(IWebDriver driver)
        {
            var section = driver.FindElement(_sectionLocator);
            var scope = section.FindElements(By.TagName("ol")).ElementAt(6);
            _incidentDescription = scope.FindElement(_incidentDescriptionLocator);
        }

        public void SetIncidentDescription(string descriptionText)
        {
            _incidentDescription.SendKeys(descriptionText);
        }

        public bool isIncidentDescriptionSet()
        {
            var element = _driver.FindElement(_incidentDescriptionLocator).FindElement(By.XPath("bicycleEventDescriptionTextAreaWithHeaderInput")).GetAttribute("Class");
            return (element.Contains("ng-not-empty") && element.Contains("ng-valid") && element.Contains("ng-valid-required"));
        }

        public string GetIncidentDescription()
        {
            return _incidentDescription.Text;
        }

        public bool NoneSelected()
        {
            var errorElement = _driver.FindElement(By.Id("bicycleEventDescriptionTextAreaWithHeaderErrorMessage")).GetAttribute("Text");
            return (!string.IsNullOrEmpty(errorElement));
        }
    }
}
