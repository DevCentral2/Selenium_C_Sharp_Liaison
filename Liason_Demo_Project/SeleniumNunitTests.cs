using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Liason_Demo_Project
{
    public class Tests
    {

        string baseURL = "https://www.liaisongroup.com/";

        IWebDriver webDriver;     //member variable, so that it can be initialised in Setup() and is accessible to the Tests

        // memeber variables for the page objects
        HomePage homePage;


        [SetUp]
        public void Setup()
        {

            InitialiseDriver();
            InitialsePages();
            NavigateToHomePage();

        }

        public void InitialsePages()
        {
            homePage = new HomePage(webDriver);

        }

        public void InitialiseDriver()
        {    
            webDriver = new ChromeDriver();     
        }

        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(baseURL);
            webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();   
        }


        [Test]
        public void HomePage_VerifyHomePageURLAndMainElements()
        {
            homePage.VerifyHomePageURL();

            homePage.VerifyElementExists(homePage.LiasonCenterMastHead);
            homePage.VerifyElementExists(homePage.cookieAcceptButton);
            homePage.VerifyElementExists(homePage.searchButton);
            homePage.VerifyElementExists(homePage.searchField);
            homePage.VerifyElementExists(homePage.hamburgerMenuIcon);
        }

        [Test]
        public void HomePage_TestAboutUsPageNavigation()
        {
            homePage.HoverOverAboutUs();
            homePage.ClickAboutUsLink();
            homePage.VerifyNavigationToPages("About Us");
        }

        [Test]
        public void HomePage_VerifyCookieAcceptButton()
        {
            homePage.NavigateToHomePage();
            homePage.ClickCookiesAcceptButton();
            homePage.VerifyCookieConsentBannerNotDisplayed();

        }

        [Test]
        public void HomePage_EnterSearchText_VerifyItemSearched()
        {
            homePage.ClickSearchButton();
            homePage.EnterTextIntoSearchField("Insights");
            homePage.ClickSearchSubmitButton();
            homePage.VerifySearchResults("Insights");

        }

        [Test]
        public void HomePage_TestHamburgerMenuNavigation()
        {
            homePage.ClickHamburgerMenuIcon();
            homePage.ClickFirstLinkFromHamburgerMenus("Liaison Financial");
            homePage.Click2ndLinkFromHamburgerMenus("Our Services");
            homePage.VerifyNavigationToPages("Our Services");
        }

    
    }
}