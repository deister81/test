using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Configuration;
using FW.Extensions;


namespace FW.TestBase
{
    internal class WebDriverTestBase
    {
        private IWebDriver _webDriver;

        private const string ChromeConfigName = "Chrome";
        private const string FirefoxConfigName = "Firefox";     

        private string _browser;
        private string _url;
        private string _browserLanguage;
        private int _defaultTimeout;


        internal WebDriverTestBase()
        {
            SetConfigValues();           
        }

        private void SetConfigValues()
        {
            var settings = ConfigurationManager.AppSettings;

            _url = settings["idmbUrl"];
            _browser = settings["Browser"];
            _browserLanguage = settings["BrowserLanguage"];
            _defaultTimeout = int.Parse(settings["timeout"]);
        }

        internal IWebDriver CreateWebDriver()
        {
            switch (_browser)
            {
                case ChromeConfigName:
                    return CreateWebDriver<ChromeDriver>(_url);
                case FirefoxConfigName:
                    return CreateWebDriver<FirefoxDriver>(_url);             
                default:
                    throw new InvalidOperationException("Unknown browser name.");
            }
        }

        protected IWebDriver CreateWebDriver<T>(string url) where T : IWebDriver, new()
        {
            var executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            IWebDriver webDriver;
            if (typeof(T) == typeof(ChromeDriver))
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("test-type");
                options.AddArgument(string.Format("--lang={0}", _browserLanguage));
                webDriver = new ChromeDriver(executablePath, options);

            }
            else if (typeof(T) == typeof(FirefoxDriver))
            {
                var profile = new FirefoxProfile();

                profile.SetPreference("intl.accept_languages", _browserLanguage);
                webDriver = new FirefoxDriver(profile);
            }           
            else
            {
                webDriver = new T();
            }
            try
            {
                webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(_defaultTimeout));
                
                //SetUrl(url, webDriver);
               
                _webDriver = webDriver;
                return webDriver;
            }
            catch (Exception)
            {
                webDriver.Dispose();
                throw;
            }
        }

        public void SetUrl(string url, IWebDriver webDriver)
        {
            if (url != null)
            {
                webDriver.Navigate().GoToUrl(url);
                WaitUntilPageLoad(webDriver);
                
            }
        }

        public void WaitUntilPageLoad(IWebDriver webDriver)
        {
            webDriver.WaitForReadyStateOnPage();
        }

    }
}
