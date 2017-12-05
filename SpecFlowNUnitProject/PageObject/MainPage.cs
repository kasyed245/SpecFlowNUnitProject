using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PracticeSpecFlowProj.PageObject;
using System.Threading;


namespace SeleniumNUnitProj.PageObject
{
   public class MainPage : BasePage //: WaitCommonClass
    {

        public MainPage(IWebDriver driver):base(driver)  { }
        [FindsBy(How = How.XPath, Using = "//div[@id='cssmenu']//span[text()='Logout']")]
        public IWebElement LogOutMenuLink;

        [FindsBy(How = How.XPath, Using = "//body/h1[contains(text(),'Execute Automation')]")]
        public IWebElement MainHeading;

        [FindsBy(How = How.XPath, Using = "//form[@id='details']//a[@href='popup.html']")]
        public IWebElement HtmlPopupLink;

        [FindsBy(How = How.Id, Using = "Initial")]
        public IWebElement InitialTxtBox;

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement FirstNameTxtBox;

        [FindsBy(How = How.Id, Using = "MiddleName")]
        public IWebElement MiddleNameTxtBox;

        [FindsBy(How = How.Name, Using = "generate")]
        public IWebElement GenerateAlertButton;
        private By generateAlertBtnBy = By.Name("generate");

        public void PressGenerateAlert() {
            WaitElementToBeVisible(generateAlertBtnBy);
         //   GenerateAlertButton.Weclick();
             GenerateAlertButton.Click();
            //IAlert alert = helper.SwitchToAlert();
            //string alertText = alert.Text;
           // Assert.IsTrue(alertText.Contains("Javascript alert"));
            //alert.Dismiss();
            //alertText = alert.Text;
            ////Assert.IsTrue(alertText.Contains("You pressed Cancel"));
            //alert.Accept();
           // Assert.IsTrue(mainPage.MainHeading().Displayed, "Main Page Not Displayed..!");
        }

        public string GetAlertText() {
            Thread.Sleep(2000);
            IAlert alert = SwitchToAlert();
            return alert.Text;
        }

        public void AcceptAlert()
        {
            Thread.Sleep(2000);
            IAlert alert = SwitchToAlert();
            alert.Accept();
        }

        public void DismissAlert()
        {
            IAlert alert = SwitchToAlert();
            alert.Dismiss();
        }

    }
}
