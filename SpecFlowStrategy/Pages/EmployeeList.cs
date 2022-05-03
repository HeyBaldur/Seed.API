using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowStrategy.Pages
{
    public class EmployeeList
    {
        public IWebDriver WebDriver { get; }
        public EmployeeList(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        // UI Elements
        public IWebElement LinkEmployees => WebDriver.FindElement(By.XPath("/html/body/app-root/body/app-nav-menu/header/nav/div/div/ul/li[4]/a"));
        public IWebElement EmployeeTable => WebDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-employees/table"));

        // Events
        public void ClickEmployees() => LinkEmployees.Click();

        // Results
        public bool IsTableDisplayed() => EmployeeTable.Displayed;
    }
}
