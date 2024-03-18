using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace Liason_Demo_Project
{


    class Functions
    {
        private IWebDriver webDriver;
        public Functions(IWebDriver driver)
        {
            webDriver = driver;
        }

        static int maxWaitTimeInSeconds = 15;
        private TimeSpan maxWaitTime = TimeSpan.FromSeconds(maxWaitTimeInSeconds); // Maxi wait time for explicit wait


        // Helper method for explicit wait
        public IWebElement WaitForElementToBeClickable(By locator)
        {
            try
            {
                // Set an explicit wait with the specified wait time
                WebDriverWait wait = new WebDriverWait(webDriver, maxWaitTime);

                // Wait for element to be clickable 
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                // Handle timeout exception if the element is not clickable within the specified time
                throw new Exception("Element is not interactable within the specified time: " + ex.Message);

            }
        }

        public IWebElement WaitForElementToBeVisible(By locator)
        {
            try
            {
                // Set an explicit wait with the specified wait time
                WebDriverWait wait = new WebDriverWait(webDriver, maxWaitTime);

                // Wait for element to be clickable 
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                // Handle timeout exception if the element is not clickable within the specified time
                throw new Exception("Element is not visible within the specified time: " + ex.Message);

            }
        }
    }
}
