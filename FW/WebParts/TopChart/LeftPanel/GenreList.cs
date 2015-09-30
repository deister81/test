using FW.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.WebParts.TopChart.LeftPanel
{
   public class GenreList
    {
        private IWebElement InputBaseElement;
        private ListBox List;

        public GenreList(IWebElement baseElement)
        {
            InputBaseElement = baseElement;
            List = new ListBox(InputBaseElement, "quicklinks");
        }

        public void NavigateToGenre(string name)
        {
            List.GetItemByText(name).Click();                        
        }
    }
}
