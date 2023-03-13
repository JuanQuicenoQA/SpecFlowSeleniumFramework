Feature: Login to the App
  As a user I want to login to the app to access the features available


  Scenario: 00) Login Failed due to incorrect UserName
    Given a user in the Login Page
    When the user enters an incorrect UserName
    And the user enters expected Password
    And click on Login Button
    Then the system throws the error "Epic sadface: Username and password do not match any user in this service" message


  Scenario: 01) Login Failed due to incorrect Password
    Given a user in the Login Page
    When the user enters expected UserName
    And the user enters an incorrect Password
    And click on Login Button
    Then the system throws the error "Epic sadface: Username and password do not match any user in this service" message


  Scenario: 02) Validate Mandatory UserName Field
    Given a user in the Login Page
    When the user doesn't enter UserName in the Username field
    And the user enters expected Password
    And click on Login Button
    Then the system throws the error "Epic sadface: Username is required" message


  Scenario: 03) Validate Mandatory Password Field
    Given a user in the Login Page
    When the user enters expected UserName
    And the user doesn't enter Password in the Password field
    And click on Login Button
    Then the system throws the error "Epic sadface: Password is required" message


  Scenario: 04) Login Successfully
    Given a user in the Login Page
    When the user enters expected UserName
    And the user enters expected Password
    And click on Login Button
    Then the system grant access by leaving the user on the Home Page in "Products" section




