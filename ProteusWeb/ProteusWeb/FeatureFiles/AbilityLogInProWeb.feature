@LoginProWeb
Feature: Ability to log into Pro Web
		
Background: 
Given I am a Proteus User
And I have the role: Pro Web Campaigns
And I go to the Proteus Home URL in my browser 

@LoginProWeb
Scenario: 01 Entering Pro Web
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
And There is a box called Campaigns
And Log Out button exist
And LogOut ProteusWeb from Home Page
#And  No other boxes (i.e admin, client reporting, reporting - as this access is controlled by other roles in Metalab)

@LoginProWeb
Scenario: 02 Entering Pro Web with incorrect details
When Login with the incorrect details (username and password)	 
Then An error message displayed advising to try again

@LoginProWeb
Scenario: 03 Campaigns page loaded
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then The Campaigns page loads successfully
And LogOut ProteusWeb from Home Page
	 
@LoginProWeb
Scenario: 04 Campaigns page loaded with different options
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then Log out, Back to Home, Flights icon shown on Campaign page
And LogOut ProteusWeb from Home Page
