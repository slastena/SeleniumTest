using System;
using System.Configuration;

namespace SeleniumTest
{
    public class TestConfig
    {
        private TestConfig() { }

        public static TestConfig Instance { get; } = new TestConfig();

        public Browsers Browser { get; } = ParseBrowser();

        public string BrowserPathBase { get; } = ConfigurationManager.AppSettings["BrowserPath"];

        public string BrowserPath { get; } = AppDomain.CurrentDomain.BaseDirectory + "\\" + ConfigurationManager.AppSettings["BrowserPath"];

        public TimeSpan ElementSearchTimeout { get; } = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["ElementSearchTimeout"]));

        public TimeSpan EventTimeout { get; } = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["EventTimeout"]));

        public string StartPage { get; } = ConfigurationManager.AppSettings["StartPage"];

        private static Browsers ParseBrowser()
        {
            var browser = ConfigurationManager.AppSettings["Browser"];

            if (!string.IsNullOrEmpty(browser))
            {
                return (Browsers)Enum.Parse(typeof(Browsers), browser);
            }

            return Browsers.Chrome;
        }
    }
}
