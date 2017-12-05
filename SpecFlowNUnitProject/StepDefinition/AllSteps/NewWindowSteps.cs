using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowNUnitProject.StepDefinition
{
    [Binding]
    public class NewWindowSteps : BaseStep
    {
        public NewWindowSteps(IWebDriver driver):base(driver){ }

        [Given(@"I press the html popup link")]
        public void GivenIPressTheHtmlPopupLink()
        {
            mainPage.HtmlPopupLink.Click();
        }
        
        [Then(@"I should see the new window")]
        public void ThenIShouldSeeTheNewWindow()
        {
            string currentWindow = mainPage.GetCurrentWindowHandle();
            popupWindow.SwitchToLastWindow();
            Console.WriteLine("Popup Heading..! :{0}", popupWindow.MainHeadingPopup.Text);
            Assert.IsTrue(popupWindow.MainHeadingPopup.Text.Contains("Execute Automation"),
                         "Popup Main Heading Not Displayed");
            popupWindow.CloseWindow();
            mainPage.SwitchToWindow(currentWindow);


        }
    }
}
