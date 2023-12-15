Feature: Employee

A short summary of the feature

//@employee
Scenario: 1_Verify user can navigate to Employee List page using the navigation menu
	Given a user logs in to the application "Admin" "admin123"
	When user clicks PIM
	And clicks Employee List
	Then Employee List page is loaded

Scenario: 2_Verify user can add a new employee in the Add Employee page
	Given a user logs in to the application "Admin" "admin123"
	When user clicks PIM
	And clicks Employee List
	And clicks Add button
	And enters employee name "Testfirstname" "Testmiddlename" "Testlastname"
	And clicks Create Login Details toggle
	And clicks Save button
	And validates errors
	When populates the mandatory create login fields "tester" "password12345" "password12345"
	Then the errors are gone
	When the user saves the login details
	Then the employee is added to the list

Scenario: 3_Verify  employee details table can be sorted by name
	Given a user logs in to the application "Admin" "admin123"
	When user clicks PIM
	And clicks Employee List
	Then the First and Middle Name column is sorted in ascending order by default 
	When the user clicks the Descending order in the Last Name column
	Then the Last name column is sorted in descending order

Scenario: 4_Verify attachments can be added in the Personal Details page
	Given a user logs in to the application "Admin" "admin123"
	When user clicks PIM
	And clicks Employee List
	And enters employee name "Anthony Nolan"
	And clicks Search button
	And user clicks on the employee name in the search table
	Then the employee name "Anthony Nolan" is the same as the selected name
	When user clicks the Add button in the Attachments
	And clicks Browse button and attaches the file
	Then the filename is displayed in the Attachment table
	When the user deletes the file from the attachment table
	Then the file is no longer displayed in the attachment table