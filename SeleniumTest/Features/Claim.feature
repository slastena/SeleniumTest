Feature: Claim
	Verufy Bicycle claim screen controls

@claim
Scenario: Verify Bicycle Claim header
	Given I have opened https://finclaimstest-atest.azurewebsites.net/en/bicycle
	Then page title should be 'Bicycle Claim'

