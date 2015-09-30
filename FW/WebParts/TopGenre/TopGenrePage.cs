using FW.Controls;
using FW.WebParts.TopGenre.MainContent;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.WebParts.TopGenre
{
    public class TopGenrePage
    {
        private IWebDriver _driver;

        public Results TopList;
        //placeholder for rest of stuff: ....

        public TopGenrePage(IWebDriver driver)
        {
            _driver = driver;
            TopList = new Results(_driver);
        }

    }
}
