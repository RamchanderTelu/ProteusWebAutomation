Feature: Ability to search for Flights
 
 Background: 
Given I am a Proteus User
And I have the role: Pro Web Campaigns
And I go to the Proteus Home URL in my browser 

@SearchOnProWeb
Scenario: 01 View Flights - initial load 
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then The Campaigns page loads successfully
And All Flights loads which I have access to
And LogOut ProteusWeb from Campaigns page

@SearchOnProWeb
Scenario: 02 Ability to Search fights by Flight Name or Booking Code
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then All Flights loads which I have access to
And I can search by Flight Name or Booking Code
And LogOut ProteusWeb from Campaigns page

@SearchOnProWeb
Scenario: 03 Ability to Filter fights by Advertiser or Agency
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then All Flights loads which I have access to
And Filter dropdown fields exist
And LogOut ProteusWeb from Campaigns page


@SearchOnProWeb
Scenario: 04 Ability to use search and filter combinations
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then All Flights loads which I have access to
#And  I am able to use all search and filter combinations:
  # Search only (Flight Name OR Booking Code)
  # Advertiser only
  # Agency only
  # Search and Advertiser
  # Search and Agency
  # Advertiser and Agency
  # Search, Advertiser and Agency
  And LogOut ProteusWeb from Campaigns page

@SearchOnProWeb
Scenario: 05 Apply button is enabled after entering/selecting search and filters
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then All Flights loads which I have access to
When I search/filter for a particular result
Then Apply button is enabled
And LogOut ProteusWeb from Campaigns page

@SearchOnProWeb
Scenario: 06 Clear Filters button is enabled after entering/selecting search and filters
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then All Flights loads which I have access to
When I search/filter for a particular result
Then Clear Filters button is enabled
And LogOut ProteusWeb from Campaigns page

@SearchOnProWeb
Scenario: 07 Flights matching Search/Filter Combination loaded as results 
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then All Flights loads which I have access to
When I search/filter for a particular result
And Click on Apply button 
Then All Flights matching search/filter combination load as results 
Then LogOut ProteusWeb from Campaigns page


@SearchOnProWeb
Scenario: 08 Pagination shown when more than 20 flights dispalyed
When Login with the correct details (username and password)	 
Then The main homepage loads successfully
When I click on Campaigns from home page
Then All Flights loads which I have access to
When I search/filter for a particular result
And Click on Apply button 
Then All Flights matching search/filter combination load as results 
#And Pagination shown when more than 20 flights dispalyed
Then LogOut ProteusWeb from Campaigns page