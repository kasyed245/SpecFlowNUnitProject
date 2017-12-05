using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PracticeSpecFlowProj.PageObject;

namespace SeleniumNUnitProj.PageObject
{

    public class PopupWindow :BasePage //: WaitCommonClass
    {
        public PopupWindow(IWebDriver driver) : base(driver) { }
        [FindsBy(How = How.XPath, Using = "//body/p[contains(text(),'demo popup')]")]
        public IWebElement SubHeadingPopup;

        [FindsBy(How = How.XPath, Using = "//body/h1[contains(text(),'Execute Automation')]")]
        public IWebElement MainHeadingPopup;

    }
}
