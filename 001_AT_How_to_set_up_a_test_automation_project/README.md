# Read me or not

As a enspiring test automation engineer, you might want to set up a test automation project using Playwright with C# and NUnit. This guide will help you get started with the basics of setting up a test automation project, including best practices and pitfalls to avoid.

## Conents

- How to set up a test automation project
- Pitfalls
- Best practices

### How to set up a test automation project

Step 1 : Create an empty solution in Visual Studio
Step 2 : Add a new project to the solution
Step 3 : Install the following:

	- NUnit3TestAdapter
	- Microsoft.NET.Test.Sdk
	- Microsoft.Playwright
	- Microsoft.Playwright.NUnit

Step 4 : Create a folder structure like this:

	- ProjectName
		- UITests
		- PageObjectModels
			- BasePage.cs
			- WebsiteNameXPages
				- HomePage.cs
				- LoginPage.cs
			- WebsiteNameYPages
				- HomePage.cs
				- LoginPage.cs
		- TestFixtures
			- WebsiteNameXTests
				HomePageTests.cs
				LoginPageTests.cs
			- WebsiteNameYTests
				HomePageTests.cs
				LoginPageTests.cs
		- Setup.cs
		- test.runsettings
		- README.md

Step 5 : In the Setup.cs file, set up the Playwright browser and context initialization and teardown methods.
Step 6 : In the BasePage.cs file, create a base page class that contains common methods and properties for all page objects.
Step 7 : In the PageObjectModels folder, create page object classes for each page of the websites you want to test.
Step 8 : In the TestFixtures folder, create test classes for each set of related tests, using NUnit attributes to define test methods.
Step 9 : Configure the test.runsettings file to specify any necessary settings for your tests.
Step 10 : Write your test cases using the page object models to interact with the web pages and start testing.

## Practice websites

For practice, you can use the following websites:

- http://www.uitestingplayground.com/
- https://www.saucedemo.com/
- https://automationexercise.com/
- https://the-internet.herokuapp.com/
- https://demoqa.com/
- https://parabank.parasoft.com/parabank/index.htm

For fun you can also try:

- https://www.youtube.com/
- https://www.bol.com
- https://www.wikipedia.org/
- https://www.amazon.com/



