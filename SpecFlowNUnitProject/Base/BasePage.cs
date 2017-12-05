using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace PracticeSpecFlowProj.PageObject
{
   public class BasePage
    {
        public IWebDriver driver;
        private const int WAiT_TIME = 10;
        public static BasePage Instance;

        public BasePage(IWebDriver driverInstance)
        {
            driver = driverInstance;
            PageFactory.InitElements(driver, this);
            //return pageClass;
        }

     
// ********Helper Methods***************
        public string GetCurrentWindowHandle()
        {
            return driver.CurrentWindowHandle;
        }


        public IList<string> GetCurrentWindowHandles()
        {
            return driver.WindowHandles;
        }

        public void SwitchToWindow(string windowName)
        {
            driver.SwitchTo().Window(windowName);
        }

        public void SwitchToLastWindow()
        {
            IList<string> allWindows = driver.WindowHandles;
            string newWindow = allWindows[allWindows.Count - 1];
            driver.SwitchTo().Window(newWindow);
        }

        public IAlert SwitchToAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            return wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public void AcceptAlert(IAlert alert)
        {
            alert.Accept();
        }

        public void DismissAlert(IAlert alert)
        {
            alert.Dismiss();
        }

        public string GetText(IAlert alert)
        {
            return alert.Text;
        }

        public void CloseWindow()
        {
            driver.Close();
        }
    
        //************Base Methods**********

        public IWebElement WaitElementToBeVisible(By by, double waitTime = WAiT_TIME)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public IWebElement WaitElementToBeExists(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAiT_TIME));
            return wait.Until(ExpectedConditions.ElementExists(by));
        }

        public IWebElement WaitElementToBeClickable(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAiT_TIME));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public IList<IWebElement> waitElementsToBeExist(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAiT_TIME));
            return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }


    }
}
