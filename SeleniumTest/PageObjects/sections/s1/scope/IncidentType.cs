using System;
using OpenQA.Selenium;

namespace SeleniumTest.PageObjects.sections.s1.scope
{
    public class IncidentType
    {
        private static IWebDriver _driver;
        private static IWebElement _section;

        private static By _sectionLocator = By.Id("eventForm_section");
        private static By _bicycleStolenRbLocator = By.Id("eventTypeRadioStolenButton");
        private static By _bicycleVandalizedRbLocator = By.Id("eventTypeRadioVandalizedButton");
        private static By _bicycleBrokenRbLocator = By.Id("eventTypeRadioBrokenButton");
        private static By _bicycleDamagedRbLocator = By.Id("eventTypeRadioDamagedButton");

        public IncidentType(IWebDriver driver)
        {
            _driver = driver;
            _section = _driver.FindElement(_sectionLocator);
        }

        public void Select(string button)
        {
            _section.FindElement(GetLocator(button)).Click();
        }

        public bool isSelected(string button)
        {
            var element = _driver.FindElement(GetLocator(button)).FindElement(By.XPath("input")).GetAttribute("class");
            return element.Contains("ng-valid-parse");
        }

        public bool NoneSelected()
        {
            var errorElement = _driver.FindElement(By.Id("eventTypeRadioErrorMessage")).GetAttribute("Text");
            return (!string.IsNullOrEmpty(errorElement));
        }
        
        private By GetLocator(string button)
        {
            switch (button)
            {
                case "Bicycle or parts of it have been stolen": return _bicycleStolenRbLocator;
                case "Bicycle has been vandalized": return _bicycleVandalizedRbLocator;
                case "Bicycle has got broken": return _bicycleBrokenRbLocator;
                case "Bicycle has been damaged in a collision with a motor vehicle": return _bicycleDamagedRbLocator;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
