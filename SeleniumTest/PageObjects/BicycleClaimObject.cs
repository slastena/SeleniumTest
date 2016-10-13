using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTest.PageObjects
{
    public class BicycleClaimObject
    {
        public BicycleClaimObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using ="h2")]
        public IWebElement lblTitle { get; set; }

        [FindsBy(How = How.Id, Using = "notifierBasicPersonInfoFirstnameInputText")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Name, Using = "notifierBasicPersonInfoSurnameInputText")]
        public IWebElement txtLastName { get; set; }

        public string GetTitle()
        {
            return lblTitle.Text;
        }
    }
}
