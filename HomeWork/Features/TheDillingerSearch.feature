Feature: TheDillingerSearch
I want to find info about The Dilinger Escape Plan in google

@possitive
Scenario: I got to The Dilinger Escape Plan Wiki page
	Given I have entered google
	When I type "The Dillinger Escape Plan" in the google search
	And I submit my search word
	And I click on the Wikipedia suggestion
	Then I should be able to see theirs wiki page

@negative
Scenario Outline: I typed the band's name wrong
Given I have entered google
When I type "<word>" in the google search
And I submit my search word
Then I should see that i have a typo
Examples: 
| word                     |
| The Dillinger escap plan |
| The Dillinger escape pla |

