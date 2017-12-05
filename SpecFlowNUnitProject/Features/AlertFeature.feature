Feature: AlertFeature
	As a site user, I want to click on the alert of the site 
	so that I can use its functionality

@alert
Scenario: User Checking Site Alert
	Given I have navigated to the site
	And I press the generate button
	Then I should see the alert
