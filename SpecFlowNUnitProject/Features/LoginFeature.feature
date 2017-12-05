Feature: LoginFeature
	As a site user, I want to login to the site so that I can use its functionality

@login
Scenario: User Checking the login
	Given I have navigated to the site
	And I goto login page
	When I enter following login details
	| UserName | Password    |
	| Admin1    | Password1  |
	| Admin2   | Password2   |
	| Admin3   | Password3   |
	When I press login button
	Then I should see application main page
