using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecFlowNUnitProject.Base;

namespace SpecFlowNUnitProject.PageObject
{
    public class LoginPage : BasePage //: WaitCommonClass
    {
        //private IWebDriver driver;

        public LoginPage(IWebDriver driver):base(driver)
        {
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement UserNameTextBox;

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.XPath, Using = "//form[@id='userName']//input[@name='Login']")]
        public IWebElement LoginButton;

      

        //public LoginPage(IWebDriver driver) {
        //    this.driver = driver;
        //    PageFactory.InitElements(driver, this);
        //}

        //public IWebElement UserNameTextBox() {
        //    return WaitElementToBeVisible(driver, By.Name("UserName"));
        //}

        //public IWebElement PasswordTextBox()
        //{
        //   // return WaitElementToBeVisible(driver, By.Name("Password"));
        //    return driver.FindElement(By.Name("Password"));
        //}

        //public IWebElement LoginButton()
        //{
        //    //return WaitElementToBeVisible(driver, By.XPath("//form[@id='userName']//input[@name='Login']"));
        //    return driver.FindElement(By.XPath("//form[@id='userName']//input[@name='Login']"));
        //}


    }
}
