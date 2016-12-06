using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTest.PageObjects.sections.s1.scope
{
    public class IncidentLocation
    {
        private static IWebElement _incidentLocationCountry;
        private static IWebElement _incidentLocationPlace;
        private static IWebElement _incidentLocationAddress;
        private static IWebElement _scope;

        private static IWebDriver _driver;
        private static IWebElement _section;

        private static By _sectionLocator = By.Id("eventForm_section");
        private static By _incidentLocationCountryLocator = By.Name("eventCountryDropDownSelect");
        private static By _incidentLocationPlaceLocator = By.Name("eventCityDropDownSelect");
        private static By _incidentLocationAddressLocator = By.Name("bicycleStolenStreetTextInput");


        public IncidentLocation(IWebDriver driver)
        {
            var section = driver.FindElement(_sectionLocator);
            _scope = section.FindElements(By.TagName("ol")).ElementAt(4);
            _incidentLocationCountry = _scope.FindElement(_incidentLocationCountryLocator);
            try
            {
                _incidentLocationPlace = _scope.FindElement(_incidentLocationPlaceLocator);
            }
            catch (Exception)
            {

                Console.Out.WriteLine("City selection is not necessary");
            }
            
            _incidentLocationAddress = _scope.FindElement(_incidentLocationAddressLocator);
        }

        private IWebElement IncidentLocationCountry => _scope.FindElement(_incidentLocationCountryLocator);

        private IWebElement IncidentLocationPlace => _scope.FindElement(_incidentLocationPlaceLocator);

        private IWebElement IncidentLocationAddress => _scope.FindElement(_incidentLocationAddressLocator);

        public void SetIncidentLocationCountry(string country)
        {
            IncidentLocationCountry.SendKeys(country);
        }

        public bool isIncidentLocationCountrySet()
        {
            var element = _driver.FindElement(_incidentLocationCountryLocator).FindElement(By.XPath("eventCountryDropDownSelect")).GetAttribute("Class");
            return (element.Contains("ng-not-empty") && element.Contains("ng-valid") && element.Contains("ng-valid-required"));
        }

        public void SetIncidentLocationPlace(string place)
        {
            IncidentLocationPlace.SendKeys(place);
        }

        public bool isIncidentLocationPlaceSet()
        {
            var element = _driver.FindElement(_incidentLocationPlaceLocator).FindElement(By.XPath("eventCityDropDownSelect")).GetAttribute("Class");
            return (element.Contains("ng-not-empty") && element.Contains("ng-valid") && element.Contains("ng-valid-required"));
        }

        public void SetIncidentLocationAddress(string address)
        {
            IncidentLocationAddress.SendKeys(address);
        }

        public bool isIncidentLocationAddress()
        {
            var element = _driver.FindElement(_incidentLocationAddressLocator).FindElement(By.XPath("bicycleStolenStreetTextInput")).GetAttribute("Class");
            return (element.Contains("ng-not-empty") && element.Contains("ng-valid") && element.Contains("ng-valid-required"));
        }

        public string GetIncidentLocationCountry()
        {
            return IncidentLocationCountry.Text;
        }

        public string GetIncidentLocationPlace()
        {
            return IncidentLocationPlace.Text;
        }

        public string GetIncidentLocationAddress()
        {
            return IncidentLocationAddress.Text;
        }

        public bool NoneSelected()
        {
            var errorElementCity = _driver.FindElement(By.Id("eventCityDropDownErrorMessage")).GetAttribute("Text");
            var errorElementAddress = _driver.FindElement(By.Id("bicycleStolenStreetTextErrorMessage")).GetAttribute("Text");
            return (!string.IsNullOrEmpty(errorElementCity)|| !string.IsNullOrEmpty(errorElementAddress));
        }
    }
}
