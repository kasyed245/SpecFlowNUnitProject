using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumNUnitProj.PageObject;
using TechTalk.SpecFlow;
using PracticeSpecFlowProj.PageObject;

namespace PracticeSpecFlowProj
{
    public class BaseStep :Steps
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        protected MainPage mainPage;
        protected PopupWindow popupWindow;


        public BaseStep(IWebDriver driver) {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
            popupWindow = new PopupWindow(driver);

        }


    }
}
