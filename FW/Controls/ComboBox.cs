using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.Controls
{
    public class ComboBox : IComboBox
    {
        protected readonly IWebElement InputBaseElement;
        private SelectElement select;

        public ComboBox(IWebElement baseElement, string name)
        {
            InputBaseElement = baseElement.FindElement(By.ClassName(name));
            select = new SelectElement(InputBaseElement);

        }

        public void SelectByName(string name)
        {
            select.SelectByText(name);
        }

    }
}
