using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.Controls
{
    
  
    public class ListBox : IListBox
    {
        private IWebElement InputBaseElement;
        private ICollection<IWebElement> Rows;

        public ListBox(IWebElement baseElement, string name)
        {
            InputBaseElement = baseElement.FindElement(By.ClassName(name));
            Rows = InputBaseElement.FindElements(By.XPath("//ul//li[contains(@class, 'subnav_item_main')]//a"));
        }

        public int ItemCount()
        {
            return Rows.Count;
        }

        public IWebElement GetItemByText(string text)
        {
            return Rows.First(i => i.Text.Equals(text));            
        }
    }
}
