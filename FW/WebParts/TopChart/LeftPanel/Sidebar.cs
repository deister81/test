using FW.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.WebParts.TopChart.LeftPanel
{
    public class Sidebar
    {
        private IWebElement InputBaseElement;

        public GenreList Genres; 

        //placeholder for other widgets as IMDbchartsLinks....

        public Sidebar(IWebDriver driver)
        {
            InputBaseElement = driver.FindElement(By.Id("sidebar"));

            Genres = new GenreList(InputBaseElement);
        }      


    }
}
