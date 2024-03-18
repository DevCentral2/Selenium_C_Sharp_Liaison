Feature: Liason_demo

As a user, I would like to verify basic functionality of the Liason Homepage

Background: 
Given I navigate to the Liason homepage
When I click the Cookies Accept button


@Smoketest
# Verify existence of core elements on the home page
Scenario:  Verify Expected HomePage elements

	Then I am taken to the Liason Homepage
	And I verify the LiasonCenterMastHead HomePage Element
	And I verify the SearchButton HomePage Element
	And I verify the SearchField HomePage Element
	And I verify the HamburgerMenuIcon HomePage Element

@Smoketest	
Scenario:  Test Cookies Accept Button  
	#This assumes we have already clicked the Cookies Accept button in the Background steps
	Then I am taken to the Liason Homepage
	And the Cookie consent Banner is not displayed

@Smoketest
Scenario:  Test Navigating to About Us Page
	When I hover over the About Us link
	And I click the About Us link
	Then I am taken to the About Us page

@Smoketest
Scenario:  Test hamburger menu navigation

	When I click the hamburger menu icon
	And I click the Liason Financial link
	And I click the Our Services link from the hamburger menus
	Then I am taken to the Our Services page

@Smoketest
Scenario Outline:  Test Search Button Seach

	When I click the Search button
	And I enter <SearchItem> into the search field
	And I click the Submit button
	Then I can see search results for <SearchResult>

Examples: 
	 | SearchItem | SearchResult |
	 | Careers    | Careers      |
	 | Insights    | Insights    |

 

