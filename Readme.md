BddStyle.NUnit
=============
[![Build status](https://ci.appveyor.com/api/projects/status/e75x6xqx7180oxtc?svg=true)](https://ci.appveyor.com/project/kbabiy/bddstyle-nunit)
[![NuGet Version](https://img.shields.io/nuget/v/BddStyle.NUnit.svg?style=flat)](https://www.nuget.org/packages/BddStyle.NUnit/)

Provides set of base classes to structure NUnit-based Unit Tests in the form of BDD tests (Given-When-Then, GWT)

This projects gives an approach to solving a few common tasks with UT structuring:

- Common structure convention
- Dealing with overwhelming tests scope
- Descriptive naming
- Errors easy and fast localization
- Reusing common setup
- Following UT best practices, such as one assertion per test

Few links:

- [BDD in Wikipedia](https://en.wikipedia.org/wiki/Behavior-driven_development)
- [GWT explained on MartinFowler's blog](http://martinfowler.com/bliki/GivenWhenThen.html)


## Installing

- Install Nuget package to your unit test project

```
Install-Package BddStyle.NUnit
```

- (optional) For your convenience import [Resharper templates](BddStyle.NUnit/snippets/TestFramework_ResharperTemplates.DotSettings) to generate tests faster
	- ReSharper => Tools => Templates Explorer => Import button

## Concepts and conventions

- Tests are structured like: **Given —< When —< Then**
	- Note that it is one-to-many ( —< ) relationship between the components
- It can be read as: Given [initial context], When [event occurs], Then [ensure some outcomes] 
	- **Given** section describes the state of the world before you begin the test case in this scenario. 
	Can be thought of as the pre-conditions to the test
		- is represented by a folder in the solution structure
		- usually (optionally) contains Context class, which is a place to write the test setup
		- examples: given\_tested\_class; given\_particular\_environment\_state

	- **When** section is the case that you are specifying
		- is represented by a class located in the Given specified folder
		- usually this class is inherited from the Context class (optionally, otherwise inherited from ContextBase class - see below for details) 
		therefore inheriting setup of the parent Given
		- example: when\_sut\_method1\_is\_called.cs

	- **Then** section describes the changes you expect due to the specified behavior
		- is represented by a method in the When class marked with NUnit.Framework.*Test*Attribute
		- contains check of one expectation from the testcase execution results
		- examples: then\_expected\_result\_is\_returned(); then\_exception\_is\_thrown();

## Example

### Example test project structure

#### Solution structure

How example solution looks like:

![solution.gif](BddStyle.NUnit/docs/solution.gif "How example solution looks like")

#### Tests structure

How example tests logical structure looks like:

![tests.gif](BddStyle.NUnit/docs/tests.gif "How example tests logical structure looks like")

#### Error localization

Troubleshooting and error localization:

![troubleshooting.gif](BddStyle.NUnit/docs/troubleshooting.gif "Troubleshooting and error localization")

### Code

[Example source codes](BddStyle.NUnit.Test/given_phone_created)

## Classes, inheritance model

Example of the proposed inheritance model is: **ContextBase** -> given\_description.Context.cs -> *and\_specified\_given.Context* -> when\_class.cs

- ContextBase - an entity provided by this library being the root entity and providing methods to override
	- Members
		- Arrange - is called before each testcase execution to set up the preconditions. 
		Is usually overriden in the Context (being the contents of the Given setup)
		- Act - contains the testcase actions to perform. 
		Is usually overriden in the When class
		- Cleanup - is called after each testcase execution to cleanup the test consequences. 
		Is usually overriden in the Context when such a cleanup is needed
		- SuppressAct - is a virtual property to allow disabling automatic Act execution (presuming it is going to be manually called in the test body). 
		It is a solution to improve data-driven tests (aka TestCase in NUnit) implementation
	- Marked with TestKind.Unit by default

- As it can see from the example, nested Given is supported within the approach by creating nested folder (and Context class) 
with the methods overriden to specify the setup

- StaticContextBase is an alternative to ContextBase to be used with integration tests only. The differences with ContextBase are
	- Arrange and Cleanup are called before and after !all! When class tests are run
	- Marked with TestKind.Integration by default
	- Reasoning for using this entity is in the integration testing to save time for heavy setup/teardown

- TestKindAttribute inherits from NUnit.Framework.CategoryAttribute and redefines AllowMultiple to false. This attribute usage allows
	- Limiting possible category values to set of Kinds enumeration options (Unit, Integration)
	- Receiving real test kind override behavior (with default being Unit) and nice support in any of the test runners

## BddStyle.NUnit.Utilities

This has some useful utilities, such as AppConfig that allows changing app.config file for the scope of the given test

- Note: this is generally a bad practice to leave a dependency, such as file or app.config, in the tested class in the scope of Unit Test.
Given utility can be applied as a quick fix or for integration testing, but this will introduce various issues
when running your tests on different setups (such as alongside each other)

## Snippets

- **tfc**: create Context
- **tfu**: create When class
- **tft**: create Then method (test in the When class)

## Additional useful packages and tooling to consider for improving your UT experience

- [Fluent Assertions](http://www.fluentassertions.com/) - lib for rich and declarative UT assertions
- [Moq](https://github.com/Moq/moq4/wiki/Quickstart) - convenient mocking framework
- [NCrunch](http://www.ncrunch.net/) - continuous testing solution for VisualStudio

## Credits

- **Konstantin Babiy** - main contributor and current  owner
- **Kirill Medvedev** - originally introduced the idea and started the project
