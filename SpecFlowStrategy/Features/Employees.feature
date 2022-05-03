Feature: Get all employees and display the list

@smock
Scenario: Perform all employees list
	Given I launch the application
	And I click in employees link
	And I should see the employees list

#User must be able to add a new employee
@smock
Scenario: Perform adding new employee
	Given I launch the application
	And I navigate to employees
	And I enter a new employee
		| FirstName | LastName | Email           | Age |
		| Loki      | Odinson  | loki@asgard.com | 350 |
	And I click on submit button
	And I should see a new record added
