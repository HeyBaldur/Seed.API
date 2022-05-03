using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SpecFlowStrategy.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowStrategy.Steps
{
    [Binding]
    public sealed class AddEmployee
    {
        private EmployeeList? _employeeList;

        [Given(@"I navigate to employees")]
        public void GivenINavigateToEmployees()
        {
            IWebDriver webDriver = new FirefoxDriver("./");
            webDriver.Navigate().GoToUrl("http://localhost:5000/");
            _employeeList = new EmployeeList(webDriver);
        }

        [Given(@"I enter a new employee")]
        public void GivenIEnterANewEmployee(Table table)
        {
            _employeeList?.ClickEmployees();

            dynamic data = table.CreateDynamicInstance();

            _employeeList?.Add((string)data.FirstName, (string)data.LastName, (string)data.Email, (int)data.Age);
        }

        [Given(@"I click on submit button")]
        public void GivenIClickOnSubmitButton()
        {
            _employeeList?.ClickSubmit();
        }

        [Given(@"I should see a new record added")]
        public void GivenIShouldSeeANewRecordAdded()
        {
            Assert.That(_employeeList.IsRowDisplayed, Is.True);
        }
    }
}
