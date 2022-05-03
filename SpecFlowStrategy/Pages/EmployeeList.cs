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
        public IWebElement TxtFirstName => WebDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-employees/div/form/div[1]/div[1]/input"));
        public IWebElement TxtLastName => WebDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-employees/div/form/div[1]/div[2]/input"));
        public IWebElement TxtEmailAddress => WebDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-employees/div/form/div[2]/div[1]/input"));
        public IWebElement TxtAge => WebDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-employees/div/form/div[2]/div[2]/input"));
        public IWebElement BtnSubmit => WebDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-employees/div/form/div[3]/div/button"));
        public IWebElement LblNumerical => WebDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-employees/table/tbody/tr[5]/th"));
        
        // Events
        public void ClickEmployees() => LinkEmployees.Click();
        public void ClickSubmit() => BtnSubmit.Click();

        // Results
        public bool IsTableDisplayed() => EmployeeTable.Displayed;
        public bool IsRowDisplayed() => LblNumerical.Displayed;

        // Methods
        public void Add(string firstName, string lastName, string email, int age)
        {
            TxtFirstName.SendKeys(firstName);
            TxtLastName.SendKeys(lastName);
            TxtEmailAddress.SendKeys(email);
            TxtAge.SendKeys(age.ToString());
        }
    }
}
