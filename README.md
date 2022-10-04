# NetArchTest.eNhancedEdition

A fluent API for .Net Standard that can enforce architectural rules in unit tests and create a *self-testing architecture*. Inspired by the [ArchUnit](https://www.archunit.org/) library for Java.

NetArchTest.eNhancedEdition is based on [NetArchTest v1.3.2](https://github.com/BenMorris/NetArchTest). If you are not familiar with NetArchTest, you should start by reading [introduction on Ben's blog](https://www.ben-morris.com/writing-archunit-style-tests-for-net-and-c-for-self-testing-architectures).

## Rationale



## Getting started

The library is available as a package on NuGet: [NetArchTest.eNhancedEdition](https://www.nuget.org/packages/NetArchTest.eNhancedEdition/).

## Examples

```csharp
// Classes in the presentation should not directly reference repositories
var result = Types.InCurrentDomain()
    .That()
    .ResideInNamespace("NetArchTest.SampleLibrary.Presentation")
    .ShouldNot()
    .HaveDependencyOnAny("NetArchTest.SampleLibrary.Data")
    .GetResult()
    .IsSuccessful;

// All the service classes should be sealed
var result = Types.InCurrentDomain()
    .That()
    .ImplementInterface(typeof(IWidgetService))
    .Should()
    .BeSealed()
    .GetResult()
    .IsSuccessful;
```



## Writing rules

The fluent API should direct you in building up a rule based on a combination of predicates, conditions and conjunctions. 

The starting point for any rule is the static `Types` class, where you load a set of types from a path, assembly or namespace.

```csharp
var types = Types.InAssembly(typeof(MyClass).Assembly);
```
Once you have selected the types you can filter them using one or more predicates. These can be chained together using `And()` or `Or()` conjunctions:
```csharp
types.That().ResideInNamespace(“MyProject.Data”);
```
Once the set of classes have been filtered you can apply a set of conditions using the `Should()` or `ShouldNot()` methods, e.g.
```csharp
types.That().ResideInNamespace(“MyProject.Data”).Should().BeSealed();
```
Finally, you obtain a result from the rule by using an executor, i.e. use `GetTypes()` to return the types that match the rule or `GetResult()` to determine whether the rule has been met. Note that the result will also return a list of types that failed to meet the conditions.
```csharp
var isValid = types.That().ResideInNamespace(“MyProject.Data”).Should().BeSealed().GetResult().IsSuccessful;
```


## Dependencies 

## Slices 

## Custom rules

You can extend the library by writing custom rules that implement the `ICustomRule` interface. These can be applied as both predicates and conditions using a `MeetsCustomRule()` method, e.g.

```csharp
var myRule = new CustomRule();

// Write your own custom rules that can be used as both predicates and conditions
var result = Types.InCurrentDomain()
    .That()
    .AreClasses()
    .Should()
    .MeetCustomRule(myRule)
    .GetResult()
    .IsSuccessful;
```