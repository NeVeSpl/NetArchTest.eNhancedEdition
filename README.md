[![net-workflow](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/actions/workflows/net-workflow.yml/badge.svg?branch=main)](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/actions/workflows/net-workflow.yml)
[![Nuget](https://img.shields.io/nuget/v/NetArchTest.eNhancedEdition?color=%23004880&label=NetArchTest.eNhancedEdition%20nuget)](https://www.nuget.org/packages/NetArchTest.eNhancedEdition)

# NetArchTest.eNhancedEdition

A fluent API for .Net Standard that can enforce architectural rules in unit tests and create a *self-testing architecture*. Inspired by the [ArchUnit](https://www.archunit.org/) library for Java.

NetArchTest.eNhancedEdition is based on [NetArchTest v1.3.2](https://github.com/BenMorris/NetArchTest). If you are not familiar with NetArchTest, you should start by reading [introduction on Ben's blog](https://www.ben-morris.com/writing-archunit-style-tests-for-net-and-c-for-self-testing-architectures).

### Rationale

NetArchTest is a well-established mature library, but to push things forward, a few breaking changes had to be made, and that is how  **eNhancedEdition** was born. eNhancedEdition uses almost identical Fluent API as a base library, but it is not 100% backwards compatible, and it will never be. 

What **eNhancedEdition** has to offer, that is not available in the NetArchTest v1.3.2:
 - fixed all known bugs present in v1.3.2 :
     - BenMorris/NetArchTest#98,
     - BenMorris/NetArchTest#101,
     - BenMorris/NetArchTest#120,
     - NeVeSpl/NetArchTest.eNhancedEdition#3
 - corrected design mistakes:
     - BenMorris/NetArchTest#119 - fixed nulls for Success result
     - BenMorris/NetArchTest#130 - for generic type, number of type parameters (e.g. `1) is no longer considered as a part of its name
 - added new features:
     - [Slices](#slices)
     - BenMorris/NetArchTest#67 - added rules: AreOfType, AreNotOfType
     - BenMorris/NetArchTest#97 - added rules: HaveSourceFileNameMatchingName, HaveSourceFilePathMatchingNamespace
     - BenMorris/NetArchTest#100 - added rules: AreImmutable, AreImmutableExternally, AreStateless
     - BenMorris/NetArchTest#104 - added rule: HaveMatchingTypeWithName
     - BenMorris/NetArchTest#105 - dependency search functions: HaveDependencyOnAny/OnlyHaveDependencyOn explain why a type fails test through [IType.Explanation](documentation/api.md#itypeexplanation) 
     - BenMorris/NetArchTest#126 - added rules for structs, enums and delegates
     - BenMorris/NetArchTest#131 - added rules for all access modifiers: public, internal, private, protected, private protected, protected internal
     - BenMorris/NetArchTest#133 - added rules: AreInheritedByAnyType, AreNotInheritedByAnyType
     - added rules: AreUsedByAny, AreNotUsedByAny
  - at the end, you get more information which should make reasoning about tests easier:
 

![revit-database-scripting-update-query](https://raw.githubusercontent.com/NeVeSpl/NetArchTest.eNhancedEdition/main/documentation/result.printscreen.png)



## Index

* [Getting started](#getting-started)
    * [Examples](#examples)
    * [Writing rules](#writing-rules)
* [Rules for dependency analysis](#rules-for-dependency-analysis)
* [Rules for assessing design and architectural principles](#rules-for-assessing-design-and-architectural-principles)
* [Slices](#slices)
* [Custom rules](#custom-rules)
* [Options](#options)
* [Limitations](#limitations)
* API
   * [Types](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/blob/main/documentation/api.md#types)
   * [Predicate](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/blob/main/documentation/api.md#predicate)
   * [PredicateList](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/blob/main/documentation/api.md#predicateList)
   * [Condition](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/blob/main/documentation/api.md#condition)
   * [ConditionList](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/blob/main/documentation/api.md#conditionList)
   * [TestResult](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/blob/main/documentation/api.md#testResult)
   * [IType](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/blob/main/documentation/api.md#itype)
   * [Options](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition/blob/main/documentation/api.md#options)



## Getting started

The library is available as a package on NuGet: [NetArchTest.eNhancedEdition](https://www.nuget.org/packages/NetArchTest.eNhancedEdition/).

### Examples

```csharp
[TestClass]
public class SampleApp_ModuleAlpha_Tests
{
    static readonly Assembly AssemblyUnderTest = typeof(TestUtils).Assembly;

    [TestMethod]
    public void PersistenceIsNotAccessibleFromOutsideOfModuleExceptOfDbContext()
    {
        var result = Types.InAssembly(AssemblyUnderTest)
                          .That()
                          .ResideInNamespace("SampleApp.ModuleAlpha.Persistence")
                          .And()
                          .DoNotHaveNameEndingWith("DbContext")
                          .Should()
                          .NotBePublic()
                          .GetResult();

        Assert.IsTrue(result.IsSuccessful);
    }

    [TestMethod]
    public void DomainIsIndependent()
    {
        var result = Types.InAssembly(AssemblyUnderTest)
                          .That()
                          .ResideInNamespace("SampleApp.ModuleAlpha.Domain")
                          .ShouldNot()
                          .HaveDependencyOtherThan(
                            "System",
                            "SampleApp.ModuleAlpha.Domain",
                            "SampleApp.SharedKernel.Domain",
                            "SampleApp.BuildingBlocks.Domain"
                          )
                          .GetResult();

        Assert.IsTrue(result.IsSuccessful, "Domain has lost its independence!");
    }

}

[TestClass]
public class SampleApp_ModuleOmega_Tests
{
    static readonly Assembly AssemblyUnderTest = typeof(TestUtils).Assembly;

    [TestMethod]
    public void RequestHandlersShouldBeSealed()
    {            
        var result = Types.InAssembly(AssemblyUnderTest)
                          .That()
                          .ImplementInterface(typeof(IRequestHandler<,>))
                          .Should()
                          .BeSealed()
                          .GetResult();

        Assert.IsTrue(result.IsSuccessful);
    }
}
```



### Writing rules

The fluent API should direct you in building up a rule, based on a combination of [predicates](documentation/api.md#predicate), [conditions](documentation/api.md#condition) and conjunctions. 

The starting point for any rule is one of the static methods on [`Types`](documentation/api.md#types) class, where you load a set of types from an assembly, domain or path.

```csharp
var types = Types.InAssembly(typeof(MyClass).Assembly);
```
Once you have loaded the types, you can filter them using one or more predicates. These can be chained together using `And()` or `Or()` conjunctions:
```csharp
types.That().ResideInNamespace("MyProject.Data");
```
Once the set of  types has been filtered, you can apply a set of conditions using the `Should()` or `ShouldNot()` methods, e.g.
```csharp
types.That().ResideInNamespace("MyProject.Data").Should().BeSealed();
```
Finally, you obtain a result from the rule by using an executor, i.e. use `GetTypes()` to return the types that match the rule or `GetResult()` to determine whether the rule has been met.

Note that `GetResult()` returns [`TestResult`](documentation/api.md#testresult) which contains a few lists of types:
- `LoadedTypes` - all types loaded by [`Types`](documentation/api.md#types)
- `SelectedTypesForTesting` - types that passed [predicates](documentation/api.md#predicate)
- `FailingTypes`- types that failed to meet the [conditions](documentation/api.md#condition)

```csharp
var result = types.That().ResideInNamespace("MyProject.Data").Should().BeSealed().GetResult();
var isValid = result.IsSuccessful;
var types = result.FailingTypes;
```

> **Tip**
Loading types is time-consuming, since `Type` class is immutable, its instance can be shared between tests.

## Rules for dependency analysis

Dependency matrix:

| type\has dependency on | D1 | D2 | D3 |
|---|----|----|----|
| a |    |    |    |
| b |    |    | x  |
| c |    | x  |    |
| d |    | x  | x  |
| e | x  |    |    |
| f | x  |    | x  |
| g | x  | x  |    |
| h | x  | x  | x  |


#### Dependency search:

|   | Rule   | number<br> of required<br> dependencies <br>from the list  | type can have<br>a dependency<br>that is not<br>on the list  |  passing types |  failing types |
|---|---|---|---|---|---|
| 1 | [HaveDependencyOnAny(D1, D2)](documentation/api.md#conditionhavedependencyonany) | at least 1  | yes  |  c, d, e, f, g, h, |  a, b |
| 2 | [HaveDependencyOnAll(D1, D2)](documentation/api.md#conditionhavedependencyonall)  | all  |  yes |  g, h | a, b, c, d, e, f  |
| 3 | [OnlyHaveDependencyOn(D1, D2)](documentation/api.md#conditiononlyhavedependencyon) | >=0  |  no | a, c, e, g  |  b, d, f, h  |
| 1N | [NotHaveDependencyOnAny(D1, D2)](documentation/api.md#conditionnothavedependencyonany) | none  | yes   |  a, b |   c, d, e, f, g, h, |
| 2N | [NotHaveDependencyOnAll(D1, D2)](documentation/api.md#conditionnothavedependencyonall)  | not all  |  yes | a, b, c, d, e, f |  g, h   |
| 3N | [HaveDependencyOtherThan(D1, D2)](documentation/api.md#conditionhavedependencyotherthan)  |  >=0 |  yes |  b, d, f, h, |  a, c, e, g  |

An explanation of why a type fails the dependency search test is available on the failing type: [IType.Explanation](documentation/api.md#itypeexplanation)


#### Reverse dependency search

|   | Predicate   | number<br> of required<br> dependencies <br>from the list  | type can use<br>a type<br>that is not<br>on the list  |  passing types |  failing types |
|---|---|---|---|---|---|
| R1 | [AreUsedByAny(c, d)](documentation/api.md#predicateareusedbyany) | at least 1  | yes  |  D2, D3 |  D1 |
| R1N | [AreNotUsedByAny(c, d)](documentation/api.md#predicatearenotusedbyany)  | none  |  yes |  D1 |  D2, D3  |


## Rules for assessing design and architectural principles

#### BeImmutable

A Type is considered as immutable when all its state (instance and static, fields, properties and events) cannot be changed after creation. Shallow immutability.

#### BeImmutableExternally

A Type is considered as externally immutable when its state (instance and static, fields, properties and events) with a public access modifier cannot be changed from the outside of the type. Shallow immutability.

#### BeStateless

A Type is considered as stateless when it does not have an instance state (fields, properties and events).

#### BeStaticless

A Type is considered as stateless when it does not have a static state.

#### HaveParameterlessConstructor

A type should have a parameterless instance constructor. 

#### DoNotHavePublicConstructor

A type should not have any instance public constructors. 

#### HaveSourceFileNameMatchingName

#### HaveSourceFilePathMatchingNamespace

#### HaveMatchingTypeWithName



## Slices 

```csharp
var result = Types.InAssembly(typeof(ExampleDependency).Assembly)
                  .Slice()
                  .ByNamespacePrefix("MyApp.Features")
                  .Should()
                  .NotHaveDependenciesBetweenSlices()
                  .GetResult();

```

There is only one way, at least for now, to divide types into slices `ByNamespacePrefix(string prefix)` and it works as follows:

1) Select types which namespace starts with a given prefix, rest of the types are ignored.
2) Slices are defined by the first part of the namespace that comes right after the prefix:
`namespacePrefix.(sliceName).restOfNamespace`
3) Types with the same `sliceName` part will be placed in the same slice. If `sliceName` is empty for a given type, the type will also be ignored (`BaseFeature` class from the following image)

![Slices](https://raw.githubusercontent.com/NeVeSpl/NetArchTest.eNhancedEdition/main/documentation/slices/slices.png)

When our types are divided into slices, we can apply the condition: `NotHaveDependenciesBetweenSlices()`. As the name suggests it detects if any dependency exists between slices. Dependency from slice to type that is not part of any other slice is allowed.

passing | failing
--|---
![Slices](https://raw.githubusercontent.com/NeVeSpl/NetArchTest.eNhancedEdition/main/documentation/slices/slices.ok.png)|![Slices](https://raw.githubusercontent.com/NeVeSpl/NetArchTest.eNhancedEdition/main/documentation/slices/slices.not.png)


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


## Options

User [Options](documentation/api.md#options-1) allows to configure how NetArchTest engine works.

```csharp
var result = Types.InCurrentDomain()
    .That()
    .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace3")
    .Should()
    .HaveNameStartingWith("Some")
    .GetResult(Options.Default with { Comparer = StringComparison.Ordinal});

Assert.True(result.IsSuccessful);
```

Available options:
- [Comparer](documentation/api.md#optionscomparer) - allows to specify how strings will be compared (right now it only affects: Predicate.HaveName, Predicate.HaveNameStartingWith, Predicate.HaveNameEndingWith)


## Limitations

NetArchTest is built on top of [jbevain/cecil](https://github.com/jbevain/cecil) thus it works on CIL level. Unfortunately, not every feature of C# language is represented in CIL, thus some things will never be available in NetArchTest, e.g.:
- BenMorris/NetArchTest#81 - NetArchTest ignores a nameof expression 

