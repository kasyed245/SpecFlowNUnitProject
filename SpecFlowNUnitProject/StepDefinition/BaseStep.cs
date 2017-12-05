using OpenQA.Selenium;
using SeleniumNUnitProj.PageObject;
using SpecFlowNUnitProject.PageObject;
using TechTalk.SpecFlow;

namespace SpecFlowNUnitProject.StepDefinition
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
