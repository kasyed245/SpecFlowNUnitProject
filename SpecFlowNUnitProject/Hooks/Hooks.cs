using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace PracticeSpecFlowProj
{

    [Binding]
    public sealed class Hooks
    {
        private IWebDriver driver;
        private readonly IObjectContainer objectContainer;
        private static string browserName;
        public static ExtentReports extentReports;
        public static ExtentTest extentTest;
         private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;

        public Hooks(IObjectContainer objectContainer,ScenarioContext scenCont, FeatureContext fContext)
        {
            this.objectContainer = objectContainer;
            scenarioContext = scenCont;
            featureContext = fContext;
            browserName = TestContext.Parameters.Get("browserName");
            Console.WriteLine("::: In the Hooks Container :::" +browserName);
            // ChooseDriver(browserName);
        }

        [BeforeTestRun]
        public static void SettingUpTestRun()
        {
            Console.WriteLine("++=====Before Test Run..!====++ >");// + browserName);
            var testDir = TestContext.CurrentContext.TestDirectory;
            Console.WriteLine("Test Dir :" + testDir);
            
            //browserName = TestContext.Parameters.Get("browserName");
            string pathToCurrentDir = TestContext.CurrentContext.TestDirectory;
            string projPath = pathToCurrentDir.Substring(0,pathToCurrentDir.LastIndexOf("bin",StringComparison.Ordinal));
            //string projPath = "D:\\Work\\ProjectCSharp\\PracticeSpecFlowProjSol\\PracticeSpecFlowProj\\";
            ////  string projPath = new Uri(actualPath).LocalPath;
            string fileName = "SpecFlowProj_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".html";
            string reportPath = projPath + "Reports\\"+ fileName;
            Console.WriteLine("Report Path :" + reportPath);
            extentReports = new ExtentReports(reportPath, true);
            extentReports.AddSystemInfo("User Name", "KSyed").AddSystemInfo("Environment", "QA")
                          .AddSystemInfo("Browser Name ",browserName);
            extentReports.LoadConfig(projPath + "extent-config.xml");
            Console.WriteLine("++=====End of Before Test Run..!====++ > BrowserName :");// + browserName);
        }
        [BeforeFeature]
        public static void beforeFeatureRun()
        {
            //var testDir = TestContext.CurrentContext.TestDirectory;
            //Console.WriteLine("Test Dir :" + testDir);
            Console.WriteLine("++=====Before Feature Run..!====++ > ");
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
           
            browserName = TestContext.Parameters.Get("browserName");
            Console.WriteLine("Feature Info :" + featureContext.FeatureInfo.Title);
            Console.WriteLine("Scenario Info :" + scenarioContext.ScenarioInfo.Title);
             extentTest = extentReports.StartTest(scenarioContext.ScenarioInfo.Title, "Feature :" + featureContext.FeatureInfo.Title);
            Console.WriteLine("=====Before Scenario..!==== > BrowserName :"+browserName);
             ChooseDriver(browserName="Chrome");
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {   Console.WriteLine("=====After Scenario..!====");
            
            if (scenarioContext.TestError != null)
            {
                Console.WriteLine("Scenario.TestError.Message :: > :{0}", scenarioContext.TestError.Message);
                var takesScreenshot = driver as ITakesScreenshot;
                string scenarioTitleNoWhiteSpace = Regex.Replace(scenarioContext.ScenarioInfo.Title, @"\s+","");
                string screenshotFileName = string.Format("{0}_{1}_{2}.png", featureContext.FeatureInfo.Title,
                scenarioTitleNoWhiteSpace, DateTime.Now.ToString("dd_MM_yyy_HHmms"));
                string pathToCurrentDir = TestContext.CurrentContext.TestDirectory;
                string projPath = pathToCurrentDir.Substring(0, pathToCurrentDir.LastIndexOf("bin", StringComparison.Ordinal));
                string scrShotDir = projPath + @"\Screenshots";
               // string scrShotDir = "D:\\Work\\ProjectCSharpDuplicate\\PracticeSpecFlowProj\\PracticeSpecFlowProj\\Screenshots\\";
                if (!Directory.Exists(scrShotDir))
                {
                    Directory.CreateDirectory(projPath+ @"/Screenshots");
                }
                // string screenshotFilePath = TestFolders.GetOutputFilePath(screenshotFileName);
                string fullPathWithFile = Path.Combine(scrShotDir, screenshotFileName);
                Console.WriteLine("Screenshot FullPathWithFile :" + fullPathWithFile);
                Screenshot screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile(fullPathWithFile, ScreenshotImageFormat.Png);
                Console.WriteLine("~~~Screenshot: {0} : ", new Uri(fullPathWithFile));
                extentTest.Log(LogStatus.Fail, scenarioContext.TestError);
                extentTest.Log(LogStatus.Fail,  "Snapshot Below: " + extentTest.AddScreenCapture(fullPathWithFile));
            }
            else
            {
                extentTest.Log(LogStatus.Pass, "Test Passed..!");
            }
          
            driver.Quit();
            driver.Dispose();
        }

        [AfterTestRun]
        public static void AfterTestRun() {

            extentReports.Flush();
          //  extentReports.Close();
         
        }

        [AfterStep]
        public void LogStepResult()
        {
            //This method is here to fix the bug in SpecFlow
            //the bug is when using parallel execution the test output log is not written to the tests
            //see https://github.com/techtalk/SpecFlow/issues/737
            //object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(LevelOfParallelismAttribute), false);
            //LevelOfParallelismAttribute attribute = null;
            //if (attributes.Length > 0)
            //{
            //attribute = attributes[0] as LevelOfParallelismAttribute;
            //var levelOfParallelism = (int)attribute.Properties.Get(attribute.Properties.Keys.Count);

            //if (levelOfParallelism > 1)
            //{
            string stepText = scenarioContext.StepContext.StepInfo.Text;
            Console.WriteLine(stepText);
            var stepTable = scenarioContext.StepContext.StepInfo.Table;
            if (stepTable != null && stepTable.ToString() != "") Console.WriteLine(stepTable);
            var error = scenarioContext.TestError;
            Console.WriteLine(error != null ? "-> error: " + error.Message : "-> done.");
            //}
            //            }


        }
        private void ChooseDriver(string browser) {
            Console.WriteLine("+++++In ChooseDriver++++ >> BrowserName :" + browser);
            if (browser.ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else {
                driver = new FirefoxDriver();
            }
        }
      
    }
}
