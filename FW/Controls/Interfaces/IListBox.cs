using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.Controls
{
    public interface IListBox
    {
        int ItemCount();
        IWebElement GetItemByText(string text);
    }
}
