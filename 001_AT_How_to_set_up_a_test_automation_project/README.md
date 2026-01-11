# Read me or not

As a enspiring test automation engineer, you might want to set up a test automation project using Playwright with C# and NUnit. This guide will help you get started with the basics of setting up a test automation project, including best practices and pitfalls to avoid.
In this project we will use the Page Object Model (POM) design pattern to organize our test code and make it more maintainable. In the first pages"UITestingPlayground" and "SauceDemo" we will write down the locators as xpaths, but in the next projects we will try to use better locators. 
This is just to get you started quickly and show you the difference between bad and good practices. Writing locators is a skill that you will develop over time with practice and experience.

Note: this project is created to give an example of how an automated test project would look like and is not intended for production use.

Learning how to write solid locators according to the Playwright philosophy is an important skill for any test automation engineer. Playwright encourages the use of robust and reliable locators that can withstand changes in the web application. Here are some tips to help you write better locators:

- Prefer using data-testids or other unique attributes specifically added for testing purposes.
- Avoid using brittle locators such as absolute XPaths or CSS selectors that rely on the exact structure of the DOM.
- Use text-based locators when appropriate, as they are often more resilient to changes in the UI.
- Leverage Playwright's built-in locator strategies, such as `getByRole`, `getByLabel`, and `getByPlaceholder`, to create more meaningful and stable locators.
- Regularly review and update your locators as the application evolves to ensure they remain effective.

So make clear what the difference is between xpaths and better locators we have used both ways in this project to show the difference.

We used xpaths for: <- NOT THE CORRECT WAY

- UITestingPlayground
- SauceDemo

We used better locators for: <- THE CORRECT WAY

- AutomationExercise


### How to set up a test automation project

Step 1 : Create an empty solution in Visual Studio
Step 2 : Add a new project to the solution
Step 3 : Install the following:


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

Step 11 : Setup CI/CD pipeline (optional) with GitHub Actionns
			- Make sure to setup Chromiun browser in test.runsettings file so you avoid this error: " NS_ERROR_FILE_NO_DEVICE_SPACE":
					-	Console.WriteLine do not automatically get printed when the test is run in the pipeline, so you can use a logger instead.
						There is a flag "-verbosity detailed" that you van add to print the console output in the pipeline logs, but that can cause an error in the pipeline.

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

## Best Practices

- https://blog.nashtechglobal.com/building-maintainable-ui-tests-with-page-object-model-in-playwright/?utm_source=chatgpt.com
- https://dev.to/cathalmacdonnacha/playwright-e2e-testing-tips-and-best-practices-2g07?utm_source=chatgpt.com
