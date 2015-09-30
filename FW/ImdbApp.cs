using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FW.WebParts;
using FW.TestBase;
using FW.Constants;
using FW.WebParts.TopChart;
using FW.WebParts.TopGenre;

namespace FW
{
    public class ImdbApp : IDisposable
    {
        private IWebDriver _driver;
        private WebDriverTestBase _webDriverTestBase;

        public ImdbApp()           
        {
            _webDriverTestBase = new WebDriverTestBase();
            Initialize();
        }

        private void Initialize()
        {
            _driver = _webDriverTestBase.CreateWebDriver();
        }

        public void Dispose()
        {
            try
            {
                _driver.Close();               
            }
            catch { }

            try
            {
                _driver.Quit();
            }
            catch { }
           
        }

        public TopMoviesPage getTopMoviesPage()
        {
            _webDriverTestBase.SetUrl(WebUrls._Top250MoviesUrl, _driver);
            return new TopMoviesPage(_driver);
        }

        public TopGenrePage getTopGenrePage()
        {
            _webDriverTestBase.WaitUntilPageLoad(_driver);
            return new TopGenrePage(_driver);
        }     

    }
}
