using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SpecFlowStrategy.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowStrategy.Steps
{
    [Binding]
    public sealed class Emplyees
    {
        EmployeeList _employeeList;

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            IWebDriver webDriver = new FirefoxDriver("./");
            webDriver.Navigate().GoToUrl("http://localhost:5000/");
            _employeeList = new EmployeeList(webDriver);
        }

        [Given(@"I click in employees link")]
        public void GivenIClickInEmployeesLink()
        {
            _employeeList.ClickEmployees();
        }

        [Given(@"I should see the employees list")]
        public void GivenIShouldSeeTheEmployeesList()
        {
            Assert.That(_employeeList.IsTableDisplayed(), Is.True);
        }
    }
}
