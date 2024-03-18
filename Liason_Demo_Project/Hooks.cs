using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Liason_Demo_Project
{
    [Binding]
    public sealed class WebDriverHooks
    {

          private static IWebDriver? _driver;

        //dependency injection container used by SpecFlow
        // this is used to 'inject' the web driver into the SpecFlow bindings class
        

        private readonly IObjectContainer objectContainer;

    
        public WebDriverHooks(IObjectContainer container)
        {
            objectContainer = container;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            // First Initialize the web driver
            WebDriverManager.InitializeWebDriver();

            //webdriver must be initialized and registered with the dependency injection container
            objectContainer.RegisterInstanceAs<IWebDriver>(WebDriverManager.GetWebDriver());

        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverManager.QuitWebDriver();
        }
    }

    public static class WebDriverManager
    {
        private static IWebDriver webDriver;

        public static void InitializeWebDriver()
        {
            // Initialize WebDriver instance
             webDriver = new ChromeDriver();

        }

        public static IWebDriver GetWebDriver()
        {
            return webDriver;
        }

        public static void QuitWebDriver()
        {
            webDriver.Quit();
        }
    }
}