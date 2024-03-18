//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;

//namespace Liason_Demo_Project
//{
//    class HomePage
//    {
//        private readonly IWebDriver webDriver;
//        private readonly Functions functions;

//        // constructor, passes in the webdriver that is initialised in Setup, in order to use it in the page class

//        public HomePage(IWebDriver _webdriver)
//        {
//            webDriver = _webdriver;

//            //create an instance of the helper functions class so that we can use it in the various homepage methods
//             functions = new Functions(webDriver);
//        }

//        string baseURL = "https://www.liaisongroup.com/";


//        // Element locators:
//        string searchFieldLocator = "input[name = 's']";
//        string cookiesAcceptButtonLocator = "button[data-tid='banner-accept']";

//        // These are some of the 'core elements' found on the Homepage
//        // these are verified in the 'Verify Expected HomePage elements' test

//        public string LiasonCenterMastHead = ".relative.object-contain.w-full";
//        public string searchButton = ".inline-flex.items-center.justify-center.p-1";
//        public string searchField = "input[name = 's']";
//        public string hamburgerMenuIcon = "button.items-center.justify-center.hidden.p-1.transition";
//        public string cookieAcceptButton = "button[data-tid='banner-accept']";


//        public void NavigateToHomePage()
//        {
//            webDriver.Navigate().GoToUrl(baseURL);
//            webDriver.Manage().Window.Maximize();
//        }


//        public void HoverOverAboutUs()
//        {
//            var menuItem = webDriver.FindElement(By.CssSelector(".z-10.flex.items-center.justify-center.cursor-pointer.align.middle"));
//            HoverOver(menuItem);
//        }
//        public void ClickAboutUsLink()
//        {
//            var AboutUsLink = webDriver.FindElement(By.CssSelector(".relative.flex.items-center.justify-start.flex-1"));
//            AboutUsLink.Click();
//        }

//        public void ClickHamburgerMenuIcon()
//        {
//            var hamburgerMenuElement = webDriver.FindElement(By
//                .CssSelector("button.items-center.justify-center.hidden.p-1.transition"));
//            hamburgerMenuElement.Click();
//        }

//        public void Click2ndLinkFromHamburgerMenus(string menuName)
//        {
//            string menuNameLocator = $"//a[text()='{menuName}']";  // unique locator for this element

//            functions.WaitForElementToBeClickable(By.XPath(menuNameLocator));
//            IWebElement element = webDriver.FindElement(By.XPath(menuNameLocator));
//            element.Click();
//        }

//        public void Click1stLinkFromHamburgerMenus(string menuName)
//        {
//            string menuNameLocator = $"//div[contains(text(),'{menuName}')]";

//            functions.WaitForElementToBeClickable(By.XPath(menuNameLocator));
//            IWebElement element = webDriver.FindElement(By.XPath(menuNameLocator));
//            element.Click();
//        }


//        private void HoverOver(IWebElement menuItem)
//        {
//            Actions action = new Actions(webDriver);
//            action.MoveToElement(menuItem).Perform();
//        }

//        public void verifyElementExists(string elementCss)
//        {
//            IList<IWebElement> elements = webDriver.FindElements(By.CssSelector(elementCss));
//            Assert.That(elements.Count > 0, $"Element not found.  Expected element with Css: {elementCss}");
//        }

//        public void VerifyHomePageURL()
//        {
//            string actualURL = webDriver.Url;
//            Assert.That(actualURL, Is.EqualTo(baseURL));
//        }

//        public  void ClickCookiesAcceptButton()
//        {
//            // explicit wait for element to be clickable
//            functions.WaitForElementToBeClickable(By.CssSelector(cookiesAcceptButtonLocator));
//            IWebElement button = webDriver.FindElement(By.CssSelector(cookiesAcceptButtonLocator));
//            button.Click();
//        }

//        public  void VerifyCookieConsentBannerNotDisplayed()
//        {
//            IList<IWebElement> elements = webDriver.FindElements(By.CssSelector("div[aria-label='Cookie Consent Prompt']"));
//            Assert.That(elements.Count == 0, "Cookie Consent banner still present, but was expected to be not visible");
//        }

//        public  void ClickSearchButton()
//        {
//            IWebElement button = webDriver.FindElement(By.CssSelector(".inline-flex.items-center.justify-center.p-1"));
//            button.Click();
//        }


//        public void EnterTextIntoSearchField(string searchText)
//        {

//            functions.WaitForElementToBeClickable(By.CssSelector(searchFieldLocator));
//            IWebElement element = webDriver.FindElement(By.CssSelector("input[name = 's']"));
//            element.SendKeys(searchText);
//        }

//        public void ClickSearchSubmitButton()
//        {
//            IWebElement button = webDriver.FindElement(By.CssSelector("button[type='submit']"));
//            button.Click();
//        }

//        public void VerifySearchResutls(string searchText)
//        {
//            IWebElement element = webDriver.FindElement(By.CssSelector("h3 > .bg-sector"));
//            Assert.That(element.Text.Contains(searchText));
//        }

//        // this method is used for the specflow step "Then I verify the xx HomePage Element"
//        public void HomePage_VerifyPageElements(string elementName)
//        {
//            switch (elementName)
//            {
//                case "LiasonCenterMastHead":
//                    verifyElementExists(LiasonCenterMastHead);
//                    break;
//                case "CookieAcceptButton":
//                    verifyElementExists(cookieAcceptButton);
//                    break;
//                case "SearchButton":
//                    verifyElementExists(searchButton);
//                    break;
//                case "SearchField":
//                    verifyElementExists(searchField);
//                    break;
//                case "HamburgerMenuIcon":
//                    verifyElementExists(hamburgerMenuIcon);
//                    break;
//                default:
//                    throw new($"Unknown element name: {elementName}");

//            }
//        }

//        public void VerifyURL (string expectedURL)
//        {
//              string actualURL = webDriver.Url;
//            Assert.That(actualURL.Contains(expectedURL), $"Expected {expectedURL} but current URL is {actualURL}");
//        }

//        public void VerifyNavigationToPages(string pageName)
//        {
//            // the switch ... case allows for easily adding more links 

//            switch (pageName)
//            {
//                case "Our Services":
//                    VerifyURL("liaison-financial/our-services/");
//                    break;

//                case "About Us":
//                    VerifyURL("liaison-group/about-group/");
//                    break;

//                default:
//                    throw new Exception($"Link {pageName} was not found.");
//            }
//        }
//}

//}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace Liason_Demo_Project
{
    class HomePage
    {
        private readonly IWebDriver webDriver;
        private readonly Functions functions;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
            functions = new Functions(webDriver);
        }

        private readonly string baseURL = "https://www.liaisongroup.com/";

        private readonly string searchFieldLocator = "input[name = 's']";
        private readonly string cookiesAcceptButtonLocator = "button[data-tid='banner-accept']";

        public string LiasonCenterMastHead => ".relative.object-contain.w-full";
        public string searchButton => ".inline-flex.items-center.justify-center.p-1";
        public string searchField => "input[name = 's']";
        public string hamburgerMenuIcon => "button.items-center.justify-center.hidden.p-1.transition";
        public string cookieAcceptButton => "button[data-tid='banner-accept']";

        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(baseURL);
            webDriver.Manage().Window.Maximize();
        }

        public void HoverOverAboutUs()
        {
            var menuItem = webDriver.FindElement(By.CssSelector(".z-10.flex.items-center.justify-center.cursor-pointer.align.middle"));
            HoverOver(menuItem);
        }

        public void ClickAboutUsLink()
        {
            var aboutUsLink = webDriver.FindElement(By.CssSelector(".relative.flex.items-center.justify-start.flex-1"));
            aboutUsLink.Click();
        }

        public void ClickHamburgerMenuIcon()
        {
            var hamburgerMenuElement = webDriver.FindElement(By.CssSelector("button.items-center.justify-center.hidden.p-1.transition"));
            hamburgerMenuElement.Click();
        }


        public void Click2ndLinkFromHamburgerMenus(string menuName)
        {
            string menuNameLocator = $"//a[text()='{menuName}']";  // unique locator for this element

            functions.WaitForElementToBeClickable(By.XPath(menuNameLocator));
            IWebElement element = webDriver.FindElement(By.XPath(menuNameLocator));
            element.Click();
        }

        public void ClickFirstLinkFromHamburgerMenus(string menuName)
        {
            string menuNameLocator = $"//div[contains(text(),'{menuName}')]";

            functions.WaitForElementToBeClickable(By.XPath(menuNameLocator));
            IWebElement element = webDriver.FindElement(By.XPath(menuNameLocator));
            element.Click();
        }

        private void HoverOver(IWebElement menuItem)
        {
            Actions action = new Actions(webDriver);
            action.MoveToElement(menuItem).Perform();
        }

        public void VerifyElementExists(string elementCss)
        {
            IList<IWebElement> elements = webDriver.FindElements(By.CssSelector(elementCss));
            Assert.That(elements.Count > 0, $"Element not found.  Expected element with Css: {elementCss}");
        }

        public void VerifyHomePageURL()
        {
            string actualURL = webDriver.Url;
            Assert.That(actualURL, Is.EqualTo(baseURL));
        }

        public void ClickCookiesAcceptButton()
        {
            functions.WaitForElementToBeClickable(By.CssSelector(cookiesAcceptButtonLocator));
            IWebElement button = webDriver.FindElement(By.CssSelector(cookiesAcceptButtonLocator));
            button.Click();
        }

        public void VerifyCookieConsentBannerNotDisplayed()
        {
            IList<IWebElement> elements = webDriver.FindElements(By.CssSelector("div[aria-label='Cookie Consent Prompt']"));
            Assert.That(elements.Count == 0, "Cookie Consent banner still present, but was expected to be not visible");
        }

        public void ClickSearchButton()
        {
            IWebElement button = webDriver.FindElement(By.CssSelector(".inline-flex.items-center.justify-center.p-1"));
            button.Click();
        }

        public void EnterTextIntoSearchField(string searchText)
        {
            functions.WaitForElementToBeClickable(By.CssSelector(searchFieldLocator));
            IWebElement element = webDriver.FindElement(By.CssSelector(searchFieldLocator));
            element.SendKeys(searchText);
        }

        public void ClickSearchSubmitButton()
        {
            IWebElement button = webDriver.FindElement(By.CssSelector("button[type='submit']"));
            button.Click();
        }

        public void VerifySearchResults(string searchText)
        {
            IWebElement element = webDriver.FindElement(By.CssSelector("h3 > .bg-sector"));
            Assert.That(element.Text.Contains(searchText));
        }

        public void VerifyPageElements(string elementName)
        {
            switch (elementName)
            {
                case "LiasonCenterMastHead":
                    VerifyElementExists(LiasonCenterMastHead);
                    break;
                case "CookieAcceptButton":
                    VerifyElementExists(cookieAcceptButton);
                    break;
                case "SearchButton":
                    VerifyElementExists(searchButton);
                    break;
                case "SearchField":
                    VerifyElementExists(searchField);
                    break;
                case "HamburgerMenuIcon":
                    VerifyElementExists(hamburgerMenuIcon);
                    break;
                default:
                    throw new($"Unknown element name: {elementName}");
            }
        }

        public void VerifyURL(string expectedURL)
        {
            string actualURL = webDriver.Url;
            Assert.That(actualURL.Contains(expectedURL), $"Expected {expectedURL} but current URL is {actualURL}");
        }

        public void VerifyNavigationToPages(string pageName)
        {
            switch (pageName)
            {
                case "Our Services":
                    VerifyURL("liaison-financial/our-services/");
                    break;
                case "About Us":
                    VerifyURL("liaison-group/about-group/");
                    break;
                default:
                    throw new Exception($"Link {pageName} was not found.");
            }
        }
    }
}

