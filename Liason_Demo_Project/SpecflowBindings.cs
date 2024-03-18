using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Liason_Demo_Project
{
    [Binding]     // [Binding tag is required in order to 'bind' the classes below to the corresponding SpecFlow steps
    public class StepDefinitions
    {
        readonly IWebDriver webDriver;
        private readonly ScenarioContext? _scenarioContext;
        private readonly HomePage homePage;

 

        public StepDefinitions(IWebDriver driver)
        {
            // using this constructor, we automatically get the driver instance that was instantiated in the Hooks class
            webDriver = driver;  
            homePage = new HomePage(webDriver);

        }


        [Given(@"I navigate to the Liason homepage")]
        public void GivenINavigateToTheHomepage()
        {
            homePage.NavigateToHomePage();
        }

        [When(@"I click the Cookies Accept button")]
        public void WhenIClickTheCookieAcceptButton()
        {
            homePage.ClickCookiesAcceptButton();

        }

        [Then(@"I am taken to the Liason Homepage")]
        public void ThenIAmTakemToTheLiasonHomepage()
        {
            homePage.VerifyHomePageURL();
        }

        [When(@"I hover over the About Us link")]
        public void WhenIHoverOverTheAboutUsLink()
        {
            homePage.HoverOverAboutUs();
           
        }

        [When(@"I click the About Us link")]
        public void WhenIClickTheAboutUsLink()
        {
           
            homePage.ClickAboutUsLink();
        }


        [When(@"I click the hamburger menu icon")]
        public void Iclickthehamburgermenuicon()
        {
            homePage.ClickHamburgerMenuIcon();

        }

        [When(@"I click the (.*) link from the hamburger menus")]
        public void WhenIClickALink(string menuName)
        {
            homePage.Click2ndLinkFromHamburgerMenus(menuName);
        }

        [Then(@"I am taken to the (.*) page")]
        public void ThenIAmTakenToTheXPage(string pageName)
        {
            homePage.VerifyNavigationToPages(pageName);
        }

        [When(@"I click the Liason Financial link")]
        public void WhenIClickTheLiasonFinancialLink()
        { 
            homePage.ClickFirstLinkFromHamburgerMenus("Liaison Financial");
        }

        [When(@"I enter (.*) into the search field")]
        public void WhenIEnterIntoTheSearchField(string searchText)
        {
            homePage.EnterTextIntoSearchField(searchText);

        }

        [When(@"I click the Search button")]
        public void WhenIClickTheSearchButton()
        {
            homePage.ClickSearchButton();
        }

        [When(@"I click the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            homePage.ClickSearchSubmitButton();
        }

   


        [Then(@"I can see search results for (.*)")]
        public void Icanseesearchresultsfor(string searchText)
        {
            homePage.VerifySearchResults(searchText);

        }

    

        [Then(@"the Cookie consent Banner is not displayed")]
        public void CookieBannerNotDisplayed()
        {
            homePage.VerifyCookieConsentBannerNotDisplayed();

        }

     

        [Then(@"I verify the (.*) HomePage Element")]
        public void ThenIVerifyXElement(string elementName)
        {
            homePage.VerifyPageElements(elementName);
        }

     
    }
}
