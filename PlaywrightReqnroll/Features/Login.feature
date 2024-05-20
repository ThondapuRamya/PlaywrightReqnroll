Feature: Login 

This feature tests the login and checkout functionalty for sausedemo application

@UI @ValidateItemPice
Scenario: Login to sausedemo application
	Given Launch the url
	When Enter valid username and password
	And Click on Login button
	Then Validate page title as inventory
	When Select any item from list of products displayed
	Then Validate price is dispalyed same as products page
	When Click on Add to cart button
	And Click on cart image
	Then Navigate to cart page and verify same price is displayed or not
	When click on checkout button
	Then Provide firstname as ramya
	And Provide lastname as thondapu
	And Provide zipcode as 502032
	When Click on continue button
	Then Validate item price is displayed same as checkout page
	And Click on Finish button