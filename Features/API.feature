Feature: API
	Verify APIs with RestSharp


@mytag
Scenario: 00) GET Method
	Given a user in the Login Page
	When sends Get Method
	Then the response code should be 200


@mytag
Scenario: 01) POST Method
	Given a user in the Login Page
	When sends Post Method
	Then the response code should be 200

	@mytag
Scenario: 02) Delete Method
	Given a user in the Login Page
	And create a pet using .Bat file
	When sends Delete Method
	Then the response code should be 200