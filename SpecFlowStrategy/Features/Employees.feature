Feature: Get all employees and display the list

@smock
Scenario: Perform all employees list
	Given I launch the application
	And I click in employees link
	And I should see the employees list
