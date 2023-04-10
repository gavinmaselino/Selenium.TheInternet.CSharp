# Selenium UI Framework #

This is an automation UI framework built in using the C# bindings of Selenium.

The tests in the project are executed against https://the-internet.herokuapp.com/ 

## Prerequisites ##

* Visual Studio 2022 or later, or JetBrains Rider
* .NET Core 6 or higher

## Getting Started ##
To get started with the framework, follow these steps:

* Clone or download the repository to your local machine.
* Open the solution file Selenium.TheInternet.CSharp.sln in Visual Studio or Rider.
* Build the solution to restore the NuGet packages.
* To run the tests do this either with the unit test runner in Visual Studio / Rider or by running the command ```dotnet test``` from the root folder. 
* The browser configuration can be set within the IDE or via the appsettings.json file in the ```bin``` folder if running from the command line.

## Project Structure ##
The project structure is designed to be simple, scalable, and modular. Here is a brief overview of the project structure:

* Selenium.TheInternet.CSharp : This is the main project that contains all the test cases, contexts and extension classes.

* Context: This folder contains all of the page contexts used in the tests. 

* Tests: This folder contains all the test cases that are executed against the relevant website pages. 

