using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.Controls
{
    public class Table : ITable
    {
        private IWebElement TableBaseElement;
        private IWebElement BodyBaseElement;
        private ICollection<IWebElement> Rows;

        public Table(IWebElement baseElement, string name)
        {
            TableBaseElement = baseElement.FindElement(By.ClassName(name));
            BodyBaseElement = TableBaseElement.FindElement(By.TagName("tbody"));
            Rows = BodyBaseElement.FindElements(By.TagName("tr"));
        }

        public int ItemCount()
        {
            return Rows.Count;
        }

       
    }
}
