Feature: BicycleClaimPage
	Checks for the page being loaded

Scenario: 'What has happened' section - verify section validation on filling in mandatory options
	Given 'BicycleClaimForm' page is opened
	And page title should be 'Bicycle Claim'
	And 'What has happened?' section visible
	And all mandatory options filled in
	When I click 'Send' button
	#Validation does not quite work yet
	Then no errors shown for 'What has happened?' section
