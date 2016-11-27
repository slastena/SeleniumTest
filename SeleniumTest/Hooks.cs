using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace SeleniumTest
{
    [Binding]
    public sealed class Hooks
    {
        private static IWebDriver _currentDriver;

        /// <summary>
        /// Executed code when all tests are completed.
        /// </summary>
        [AfterTestRun]
        public static void WhenTestRunCompleted()
        {
            if (_currentDriver != null)
            {
                CloseBrowserWindow(_currentDriver);
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _currentDriver = _currentDriver ?? (_currentDriver = CreateDriver());

            WriteToLog("Started scenario - " + ScenarioContext.Current.ScenarioInfo.Title);
            WriteToLog("Using driver with hash: " + _currentDriver.GetHashCode());

            ScenarioContext.Current.Set(_currentDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                WriteToLog("Ending scenario - " + ScenarioContext.Current.ScenarioInfo.Title);

                var driver = ScenarioContext.Current.Get<IWebDriver>();
                if (_currentDriver != null)
                {
                    CloseBrowserWindow(_currentDriver);
                }

                WriteToLog("Ended scenario - " + ScenarioContext.Current.ScenarioInfo.Title);
            }
            catch (Exception ex)
            {
                WriteToLog("Error on closing browser - " + ex.Message);
                WriteToLog("Error on closing browser - " + ex.StackTrace);
            }
        }

        private static IWebDriver CreateDriver()
        {
            var browserPath = TestConfig.Instance.BrowserPath;

            var browser = TestConfig.Instance.Browser;

            return BuildWebDriver(browser, browserPath);
        }

        private static IWebDriver BuildWebDriver(Browsers browser, string browserPath)
        {
            IWebDriver driver;

            switch (browser)
            {
                case Browsers.Chrome:
                    driver = new ChromeDriver(browserPath);
                    break;
                case Browsers.FireFox:
                    driver = new FirefoxDriver();
                    break;
                case Browsers.InternetExplorer:
                    driver = new InternetExplorerDriver(browserPath);
                    break;
                case Browsers.PhantomJs:
                    driver = new PhantomJSDriver(browserPath);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return driver;
        }

        private static void CloseBrowserWindow(IWebDriver driver)
        {
            try
            {
                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                WriteExceptionToLog("Exception occurred while closing browser", ex);
            }
        }

        private static void WriteToLog(string textToLog)
        {
            Debug.WriteLine(textToLog);
        }

        private static void WriteExceptionToLog(string exceptionText, Exception ex)
        {
            WriteToLog($"{exceptionText}: {ex.Message}");
            WriteToLog($"Stack trace: {ex.StackTrace}");
        }
    }
}
