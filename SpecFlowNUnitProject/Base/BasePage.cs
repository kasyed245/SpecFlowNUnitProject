using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SpecFlowNUnitProject.Base
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

        // **************************Helper Methods***************
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
        public void moveToElement(By locator, int wait = 10)
        {
            WaitElementToBeVisible(locator, wait);
            new Actions(driver).MoveToElement(GetElement(locator)).Perform();

        }
        public IWebElement GetElement(By locator)
        {
            return driver.FindElement(locator);
        }
        //*********************Base Wait Methods***************

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

        public void HighlightElement(By locator) {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.border='4px solid blue'", GetElement(locator));
            Thread.Sleep(2000);
        }

        public bool ElementIsDisplayed(By locator, double waitTime = WAiT_TIME)
        {
            WaitElementToBeVisible(locator, waitTime);
            HighlightElement(locator);
            return GetElement(locator).Displayed;
        }
    }
}
