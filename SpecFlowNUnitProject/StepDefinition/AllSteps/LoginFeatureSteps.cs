using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SeleniumNUnitProj.PageObject;

namespace PracticeSpecFlowProj.StepDefinition
{
    [Binding]
    public class LoginFeatureSteps : BaseStep
    {
        //LoginPage loginPage;
        //MainPage mainPage;
        //private IWebDriver driver;
        //public LoginFeatureSteps(IWebDriver driver)  { this.driver = driver;
        //   loginPage = new LoginPage(driver);
        //   mainPage = new MainPage(driver);
        //}
        public LoginFeatureSteps(IWebDriver driver) : base(driver) { }
        [Given(@"I have navigated to the site")]
        public void GivenIHaveNavigatedToTheSite()
        {
            Console.WriteLine("***I have navigated to the site..!***");
            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html");
            Thread.Sleep(5000);
        }

        [Given(@"I goto login page")]
        public void GivenIGotoLoginPage()
        {
            // driver.FindElement(By.XPath("//a[@href='Login.html']/span")).Click();
            mainPage.LogOutMenuLink.Click();
            Thread.Sleep(2000);

        }

        [When(@"I enter following login details")]
        public void WhenIEnterFollowingLoginDetails(Table table)
        {
            // dynamic data = table.CreateDynamicInstance();
            IEnumerable<dynamic> data = table.CreateDynamicSet();

            IWebElement userName = loginPage.UserNameTextBox;//.SendKeys(item.UserName);
            IWebElement password = loginPage.PasswordTextBox;//.SendKeys(item.Password);
            foreach (var item in data) {
                userName.Clear(); password.Clear();
                userName.SendKeys(item.UserName);
                password.SendKeys(item.Password);
            }
            Console.WriteLine("***I enter following login details..!***");
           // Thread.Sleep(1000);
        }
        
        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            //driver.FindElement(By.Name("Login")).Submit() ;
            loginPage.LoginButton.Submit();
            Console.WriteLine("***I press login button..!***"); 
        }
        
        [Then(@"I should see application main page")]
        public void ThenIShouldSeeApplicationMainPage()
        {   
            Console.WriteLine("***I should see application main page..!***");
            Thread.Sleep(1000);
            IWebElement headingElement = mainPage.MainHeading;// driver.FindElement(By.XPath("//h1[contains(text(),'Execute Automation')]"));
            Assert.That(headingElement.Displayed);
        }
    }
}
