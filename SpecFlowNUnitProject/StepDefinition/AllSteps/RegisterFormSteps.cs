using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;


namespace SpecFlowNUnitProject.StepDefinition
{
    [Binding]
    public class RegisterFormSteps :BaseStep
    {
        public RegisterFormSteps(IWebDriver driver) : base(driver) { }

        [When(@"I enter intial (.*), FirstName (.*) and LastName (.*)")]
        public void WhenIEnterIntialKFirstNameHelloAndLastNameWorld(string initial,string fName, string lName)
        {
            Console.WriteLine("**I enter initial, firtName, LastName ***");
            mainPage.InitialTxtBox.SendKeys(initial);
            mainPage.FirstNameTxtBox.SendKeys(fName);
            mainPage.MiddleNameTxtBox.SendKeys(lName);
            Thread.Sleep(1000);
           // Assert.IsTrue(fName.Contains("Hello"));
            Given("I goto login page");
            Thread.Sleep(2000);
            When("I press login button");
        }

              [When(@"I press register button")]
        public void WhenIPressRegisterButton()
        {
            Thread.Sleep(1000);
            string fNameTxt = mainPage.FirstNameTxtBox.GetAttribute("value");
            Console.WriteLine("FirstName :" + fNameTxt);
          //  Assert.IsTrue(fNameTxt.Contains("Jack"));
            Console.WriteLine("** I press Register button ***");
        }
    }
}
