Feature: NewWindowFeature
	As a site user, I want to click on the new window of the site 
	so that I can use its functionality

@newWindow
Scenario: User Checking Site New Window Popup
	Given I have navigated to the site
	And I press the html popup link
	Then I should see the new window
