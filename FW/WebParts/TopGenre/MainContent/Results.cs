using FW.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.WebParts.TopGenre.MainContent
{
  
    public class Results
    {        
        private IWebElement InputBaseElement;
        private ITable TopGenreList;

        public Results(IWebDriver driver)
        {
            InputBaseElement = driver.FindElement(By.Id("content-2-wide"));

            TopGenreList = new Table(InputBaseElement, "results");            
        }

        public int GetMoviesCount()
        {
            return TopGenreList.ItemCount(); 
        }

    }


}
