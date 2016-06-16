Feature: LogIn and LogOut functionality

  Scenario: User logins with VALID credentials
   Given User starts new browser session and opens home page
   When User enters user@insider.com and qwerty123
   Then Page 'AccountProfilePage' is loaded  
     And User selects 'LogOut' in My Details menu
     And Page 'HomePage' is loaded     
   		
  Scenario: ADMIN user logins with VALID credentials
   Given User starts new browser session and opens home page
   When User enters admin@insider.com and qwerty123
   Then Page 'AccountProfilePageAdmin' is loaded
     And User selects 'LogOut' in My Details menu
     And Page 'HomePage' is loaded      
 
Scenario Outline: User logins with MISSING credentials
    Given User starts new browser session and opens home page
    When User enters <login> and <password>
	Then Validation message is appeared on 'HomePage' 'Missing credentials'
  Examples: 
  | login            | password |
  | user@insider.com |          |
  |                  | 12345678 |
  |                  |          |	