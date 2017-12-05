Feature: MoveToMenu
	As a site user, I want to move to menu items of the site 
	so that I can use its functionality

@moveTo
Scenario: Move To Menu Validation
	Given I have navigated to the site
	When I move to automation menu
	Then I should see the item in subMenu

