@Chrome

Feature: OpenBrowser
	

Scenario: Open Browser
	Given I am on Home Page
	When Click on "File Upload" Link	
	And Choose "TestUpload.jpg" file to upload
	And Click on "Upload" button
	Then I should see "File Uploaded!"
	And I should see "TestUpload.jpg"