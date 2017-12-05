using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowNUnitProject.StepDefinition
{
    [Binding]
    public class MoveToMenuSteps : BaseStep
    {
        public MoveToMenuSteps(IWebDriver driver) : base(driver) { }

        [When(@"I move to automation menu")]
        public void WhenIMoveToAutomationMenu()
        {
            mainPage.MoveToAutomationToolMenu();
        }
        
        [Then(@"I should see the item in subMenu")]
        public void ThenIShouldSeeTheItemInSubMenu()
        {
            mainPage.SeleniumElementIsDisplayed();
        }
    }
}
