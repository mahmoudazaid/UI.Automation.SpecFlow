@Chrome

Feature: DownloadFile
	

Scenario: Open Browser
	Given I am on Home Page
	When Click on "File Download" Link	
	And Click on "some-file.txt" Link
	Then Check "some-file.txt" downloaded successfuly
	And Delete "some-file.txt" file