using FW.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW.WebParts.TopChart.MainContent;
using FW.WebParts.TopChart.LeftPanel;


namespace FW.WebParts.TopChart
{
    public class TopMoviesPage
    {
        private IWebDriver _driver;

        public Lister TopList;
        public Sidebar LeftPanel;
        //placeholder for rest of stuff: ....

        public TopMoviesPage(IWebDriver driver)
        {
            _driver = driver;
            TopList = new Lister(_driver);
            LeftPanel = new Sidebar(_driver);

        }
     
    }
}
