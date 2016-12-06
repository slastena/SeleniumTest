using System;
using OpenQA.Selenium;
using SeleniumTest.PageObjects.sections;

namespace SeleniumTest.PageObjects
{
    public class BicycleClaimPage
    {
        private static IWebDriver _driver;

        private By _sendButton = By.Id("sendClaimButton");
        private By _titleLabel = By.CssSelector("h2");

        public BicycleClaimPage(IWebDriver driver)
        {
            _driver = driver;

        }

        private IWebElement SendButton => _driver.FindElement(_sendButton);

        public IWebElement TitleLable => _driver.FindElement(_titleLabel);

        public S1_WhatHasHappened S1_WhatHasHappened => new S1_WhatHasHappened(_driver);

        public void FillInMandatoryOptions(string incidentType, string incidentDate, string incidentCountry,
            string incidentCity, string incidentAddress, string incidentDescription)
        {
            S1_WhatHasHappened.IncidentType.Select(incidentType);
            S1_WhatHasHappened.IncidentDate.SetIncidentDate(incidentDate);
            S1_WhatHasHappened.IncidentLocation.SetIncidentLocationCountry(incidentCountry);
            if (incidentCountry.Equals("Suomi"))
            {
                S1_WhatHasHappened.IncidentLocation.SetIncidentLocationPlace(incidentCity);
            }
            S1_WhatHasHappened.IncidentLocation.SetIncidentLocationAddress(incidentAddress);
            S1_WhatHasHappened.IncidentDescription.SetIncidentDescription(incidentDescription);
        }

        public bool ErrorValidation()
        {
            return (S1_WhatHasHappened.IncidentType.NoneSelected() || 
                   S1_WhatHasHappened.IncidentDate.NoneSelected() ||
                   S1_WhatHasHappened.IncidentLocation.NoneSelected() ||
                   S1_WhatHasHappened.IncidentDescription.NoneSelected());
        }

        public void Send()
        {
            SendButton.Click();
        }

        public string GetTitle()
        {
            return TitleLable.Text;
        }

        public void Abort()
        {
            throw new NotImplementedException();
        }
    }
}
