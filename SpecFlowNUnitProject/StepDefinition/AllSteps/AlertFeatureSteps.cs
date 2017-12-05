using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace PracticeSpecFlowProj.StepDefinition
{
    [Binding]
    public class AlertFeatureSteps : BaseStep
    {
        public AlertFeatureSteps(IWebDriver driver) : base(driver) { }

        [Given(@"I press the generate button")]
        public void GivenIPressTheGenerateButton()
        {
            mainPage.PressGenerateAlert();
        }
        
        [Then(@"I should see the alert")]
        public void ThenIShouldSeeTheAlert()
        {
            string text = mainPage.GetAlertText();
            Console.WriteLine("Text :"+text);
            mainPage.DismissAlert();
            text = mainPage.GetAlertText();
            Console.WriteLine("Text :" + text);
            mainPage.AcceptAlert();

        }
    }
}
