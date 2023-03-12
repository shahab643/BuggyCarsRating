Feature: BuggyCarsRating

# Open the Buggy Cars Rating page
Scenario: TC1   
	Given Open the browser
	When Navigate to Main page
	Then Main Page is loaded


# Login the application
Scenario: TC2   
	Given Open the browser
	When Navigate to Main page
	Then Enter Username and Password 'shahab643' 'Islamabad@123'
	Then User should login

# Verify Popular Make Vote count
Scenario: TC3   
	Given Open the browser
	When Navigate to Main page
	Then Verify the vote count for Popular Make
	
# Verify Popular Model Vote count
Scenario: TC4   
	Given Open the browser
	When Navigate to Main page
	Then Verify the vote count for Popular Model

# Verify User is not able to Vote without Login
Scenario: TC5   
	Given Open the browser
	When Navigate to Main page
	Then Verify User is not able to Vote without Login
