using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FW.Controls;


namespace FW.WebParts.TopChart.MainContent
{
   
    public class Lister
    {        
        private IWebElement InputBaseElement;
        private IComboBox ListerSort;
        private ITable ListerList;

        public Lister(IWebDriver driver)
        {
            InputBaseElement = driver.FindElement(By.ClassName("lister"));

            ListerSort = new ComboBox(InputBaseElement, "lister-sort-by");
            ListerList = new Table(InputBaseElement, "chart");
        }

        public void SortBy(string type)
        {
            ListerSort.SelectByName(type);
        }

        public int GetMoviesCount()
        {
            return ListerList.ItemCount();
        }
      
    }
}
