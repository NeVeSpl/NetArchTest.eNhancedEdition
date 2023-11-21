
## Types
- [FromFile](#TypesFromFile)
- [FromPath](#TypesFromPath)
- [InAssemblies](#TypesInAssemblies)
- [InAssembly](#TypesInAssembly)
- [InCurrentDomain](#TypesInCurrentDomain)

* [GetTypes](#TypesGetTypes)
* [Should](#TypesShould)
* [ShouldNot](#TypesShouldNot)
* [Slice](#TypesSlice)
* [That](#TypesThat)

## Predicate

* [AreAbstract](#PredicateAreAbstract)
* [AreClasses](#PredicateAreClasses)
* [AreDelegates](#PredicateAreDelegates)
* [AreEnums](#PredicateAreEnums)
* [AreGeneric](#PredicateAreGeneric)
* [AreImmutable](#PredicateAreImmutable)
* [AreInterfaces](#PredicateAreInterfaces)
* [AreInternal](#PredicateAreInternal)
* [AreMutable](#PredicateAreMutable)
* [AreNested](#PredicateAreNested)
* [AreNotAbstract](#PredicateAreNotAbstract)
* [AreNotClasses](#PredicateAreNotClasses)
* [AreNotDelegates](#PredicateAreNotDelegates)
* [AreNotEnums](#PredicateAreNotEnums)
* [AreNotGeneric](#PredicateAreNotGeneric)
* [AreNotInterfaces](#PredicateAreNotInterfaces)
* [AreNotInternal](#PredicateAreNotInternal)
* [AreNotNested](#PredicateAreNotNested)
* [AreNotPrivate](#PredicateAreNotPrivate)
* [AreNotPrivateProtected](#PredicateAreNotPrivateProtected)
* [AreNotProtected](#PredicateAreNotProtected)
* [AreNotProtectedInternal](#PredicateAreNotProtectedInternal)
* [AreNotPublic](#PredicateAreNotPublic)
* [AreNotSealed](#PredicateAreNotSealed)
* [AreNotStatic](#PredicateAreNotStatic)
* [AreNotStructures](#PredicateAreNotStructures)
* [ArePrivate](#PredicateArePrivate)
* [ArePrivateProtected](#PredicateArePrivateProtected)
* [AreProtected](#PredicateAreProtected)
* [AreProtectedInternal](#PredicateAreProtectedInternal)
* [ArePublic](#PredicateArePublic)
* [AreSealed](#PredicateAreSealed)
* [AreStatic](#PredicateAreStatic)
* [AreStructures](#PredicateAreStructures)
* [DoNotHaveCustomAttribute](#PredicateDoNotHaveCustomAttribute)
* [DoNotHaveCustomAttributeOrInherit](#PredicateDoNotHaveCustomAttributeOrInherit)
* [DoNotHaveDependencyOnAll](#PredicateDoNotHaveDependencyOnAll)
* [DoNotHaveDependencyOnAny](#PredicateDoNotHaveDependencyOnAny)
* [DoNotHaveName](#PredicateDoNotHaveName)
* [DoNotHaveNameEndingWith](#PredicateDoNotHaveNameEndingWith)
* [DoNotHaveNameMatching](#PredicateDoNotHaveNameMatching)
* [DoNotHaveNameStartingWith](#PredicateDoNotHaveNameStartingWith)
* [DoNotImplementInterface](#PredicateDoNotImplementInterface)
* [DoNotInherit](#PredicateDoNotInherit)
* [DoNotResideInNamespace](#PredicateDoNotResideInNamespace)
* [DoNotResideInNamespaceContaining](#PredicateDoNotResideInNamespaceContaining)
* [DoNotResideInNamespaceEndingWith](#PredicateDoNotResideInNamespaceEndingWith)
* [DoNotResideInNamespaceMatching](#PredicateDoNotResideInNamespaceMatching)
* [HaveCustomAttribute](#PredicateHaveCustomAttribute)
* [HaveCustomAttributeOrInherit](#PredicateHaveCustomAttributeOrInherit)
* [HaveDependencyOnAll](#PredicateHaveDependencyOnAll)
* [HaveDependencyOnAny](#PredicateHaveDependencyOnAny)
* [HaveDependencyOtherThan](#PredicateHaveDependencyOtherThan)
* [HaveName](#PredicateHaveName)
* [HaveNameEndingWith](#PredicateHaveNameEndingWith)
* [HaveNameMatching](#PredicateHaveNameMatching)
* [HaveNameStartingWith](#PredicateHaveNameStartingWith)
* [HaveSomeNonNullableMembers](#PredicateHaveSomeNonNullableMembers)
* [ImplementInterface](#PredicateImplementInterface)
* [Inherit](#PredicateInherit)
* [MeetCustomRule](#PredicateMeetCustomRule)
* [OnlyHaveDependencyOn](#PredicateOnlyHaveDependencyOn)
* [OnlyHaveNullableMembers](#PredicateOnlyHaveNullableMembers)
* [ResideInNamespace](#PredicateResideInNamespace)
* [ResideInNamespaceContaining](#PredicateResideInNamespaceContaining)
* [ResideInNamespaceEndingWith](#PredicateResideInNamespaceEndingWith)
* [ResideInNamespaceMatching](#PredicateResideInNamespaceMatching)

## PredicateList

* [And](#PredicateListAnd)
* [GetTypes](#PredicateListGetTypes)
* [Or](#PredicateListOr)
* [Should](#PredicateListShould)
* [ShouldNot](#PredicateListShouldNot)
* [Slice](#PredicateListSlice)

## Condition

* [BeAbstract](#ConditionBeAbstract)
* [BeClasses](#ConditionBeClasses)
* [BeDelegates](#ConditionBeDelegates)
* [BeEnums](#ConditionBeEnums)
* [BeGeneric](#ConditionBeGeneric)
* [BeImmutable](#ConditionBeImmutable)
* [BeInterfaces](#ConditionBeInterfaces)
* [BeInternal](#ConditionBeInternal)
* [BeMutable](#ConditionBeMutable)
* [BeNested](#ConditionBeNested)
* [BePrivate](#ConditionBePrivate)
* [BePrivateProtected](#ConditionBePrivateProtected)
* [BeProtected](#ConditionBeProtected)
* [BeProtectedInternal](#ConditionBeProtectedInternal)
* [BePublic](#ConditionBePublic)
* [BeSealed](#ConditionBeSealed)
* [BeStatic](#ConditionBeStatic)
* [BeStructures](#ConditionBeStructures)
* [HaveCustomAttribute](#ConditionHaveCustomAttribute)
* [HaveCustomAttributeOrInherit](#ConditionHaveCustomAttributeOrInherit)
* [HaveDependencyOnAll](#ConditionHaveDependencyOnAll)
* [HaveDependencyOnAny](#ConditionHaveDependencyOnAny)
* [HaveDependencyOtherThan](#ConditionHaveDependencyOtherThan)
* [HaveName](#ConditionHaveName)
* [HaveNameEndingWith](#ConditionHaveNameEndingWith)
* [HaveNameMatching](#ConditionHaveNameMatching)
* [HaveNameStartingWith](#ConditionHaveNameStartingWith)
* [HaveSomeNonNullableMembers](#ConditionHaveSomeNonNullableMembers)
* [ImplementInterface](#ConditionImplementInterface)
* [Inherit](#ConditionInherit)
* [MeetCustomRule](#ConditionMeetCustomRule)
* [NotBeAbstract](#ConditionNotBeAbstract)
* [NotBeClasses](#ConditionNotBeClasses)
* [NotBeDelegates](#ConditionNotBeDelegates)
* [NotBeEnums](#ConditionNotBeEnums)
* [NotBeGeneric](#ConditionNotBeGeneric)
* [NotBeInterfaces](#ConditionNotBeInterfaces)
* [NotBeInternal](#ConditionNotBeInternal)
* [NotBeNested](#ConditionNotBeNested)
* [NotBePrivate](#ConditionNotBePrivate)
* [NotBePrivateProtected](#ConditionNotBePrivateProtected)
* [NotBeProtected](#ConditionNotBeProtected)
* [NotBeProtectedInternal](#ConditionNotBeProtectedInternal)
* [NotBePublic](#ConditionNotBePublic)
* [NotBeSealed](#ConditionNotBeSealed)
* [NotBeStatic](#ConditionNotBeStatic)
* [NotBeStructures](#ConditionNotBeStructures)
* [NotHaveCustomAttribute](#ConditionNotHaveCustomAttribute)
* [NotHaveCustomAttributeOrInherit](#ConditionNotHaveCustomAttributeOrInherit)
* [NotHaveDependencyOnAll](#ConditionNotHaveDependencyOnAll)
* [NotHaveDependencyOnAny](#ConditionNotHaveDependencyOnAny)
* [NotHaveName](#ConditionNotHaveName)
* [NotHaveNameEndingWith](#ConditionNotHaveNameEndingWith)
* [NotHaveNameMatching](#ConditionNotHaveNameMatching)
* [NotHaveNameStartingWith](#ConditionNotHaveNameStartingWith)
* [NotImplementInterface](#ConditionNotImplementInterface)
* [NotInherit](#ConditionNotInherit)
* [NotResideInNamespace](#ConditionNotResideInNamespace)
* [NotResideInNamespaceContaining](#ConditionNotResideInNamespaceContaining)
* [NotResideInNamespaceEndingWith](#ConditionNotResideInNamespaceEndingWith)
* [NotResideInNamespaceMatching](#ConditionNotResideInNamespaceMatching)
* [OnlyHaveDependencyOn](#ConditionOnlyHaveDependencyOn)
* [OnlyHaveNullableMembers](#ConditionOnlyHaveNullableMembers)
* [ResideInNamespace](#ConditionResideInNamespace)
* [ResideInNamespaceContaining](#ConditionResideInNamespaceContaining)
* [ResideInNamespaceEndingWith](#ConditionResideInNamespaceEndingWith)
* [ResideInNamespaceMatching](#ConditionResideInNamespaceMatching)

## ConditionList

* [And](#ConditionListAnd)
* [GetResult](#ConditionListGetResult)
* [GetTypes](#ConditionListGetTypes)
* [Or](#ConditionListOr)

## TestResult

* [FailingTypes](#TestResultFailingTypes)
* [IsSuccessful](#TestResultIsSuccessful)

## IType

* [Explanation](#ITypeExplanation)
* [FullName](#ITypeFullName)
* [Name](#ITypeName)
* [ReflectionType](#ITypeReflectionType)

## Options

* [Comparer](#OptionsComparer)

## Types
### Types.FromFile
```csharp
Types Types.FromFile(string fileName)
```
Creates a list of all the types in a particular module file.
### Types.FromPath
```csharp
Types Types.FromPath(string path, IEnumerable<string> searchDirectories = null)
```
Creates a list of all the types found on a particular path.
### Types.GetTypes
```csharp
IEnumerable<IType> Types.GetTypes(Options options = null)
```
Returns the list of <see cref="T:System.Type"/> objects describing the types in this list.
### Types.InAssemblies
```csharp
Types Types.InAssemblies(IEnumerable<Assembly> assemblies, IEnumerable<string> searchDirectories = null)
```
Creates a list of types based on a list of assemblies.
### Types.InAssembly
```csharp
Types Types.InAssembly(Assembly assembly, IEnumerable<string> searchDirectories = null)
```
Creates a list of types based on a particular assembly.
### Types.InCurrentDomain
```csharp
Types Types.InCurrentDomain()
```
Creates a list of types based on all the assemblies in the current AppDomain
### Types.Should
```csharp
Condition Types.Should()
```
Applies a set of conditions to the list of types.
### Types.ShouldNot
```csharp
Condition Types.ShouldNot()
```
Applies a negative set of conditions to the list of types.
### Types.Slice
```csharp
SlicePredicate Types.Slice()
```
Allows dividing types into groups, also called slices.
### Types.That
```csharp
Predicate Types.That()
```
Allows a list of types to be applied to one or more filters.

## Predicate
### Predicate.AreAbstract
```csharp
PredicateList Predicate.AreAbstract()
```
Selects types that are marked as abstract.
### Predicate.AreClasses
```csharp
PredicateList Predicate.AreClasses()
```
Selects types that are classes.
### Predicate.AreDelegates
```csharp
PredicateList Predicate.AreDelegates()
```
Selects types that are delegates.
### Predicate.AreEnums
```csharp
PredicateList Predicate.AreEnums()
```
Selects types that are enums.
### Predicate.AreGeneric
```csharp
PredicateList Predicate.AreGeneric()
```
Selects types that have generic parameters.
### Predicate.AreImmutable
```csharp
PredicateList Predicate.AreImmutable()
```
Selects types that are immutable.
### Predicate.AreInterfaces
```csharp
PredicateList Predicate.AreInterfaces()
```
Selects types that are interfaces.
### Predicate.AreInternal
```csharp
PredicateList Predicate.AreInternal()
```
Selects types that are declared as internal.
### Predicate.AreMutable
```csharp
PredicateList Predicate.AreMutable()
```
Selects types that are mutable.
### Predicate.AreNested
```csharp
PredicateList Predicate.AreNested()
```
Selects types that are nested.
### Predicate.AreNotAbstract
```csharp
PredicateList Predicate.AreNotAbstract()
```
Selects types that are not marked as abstract.
### Predicate.AreNotClasses
```csharp
PredicateList Predicate.AreNotClasses()
```
Selects types that are not classes.
### Predicate.AreNotDelegates
```csharp
PredicateList Predicate.AreNotDelegates()
```
Selects types that are not delegates.
### Predicate.AreNotEnums
```csharp
PredicateList Predicate.AreNotEnums()
```
Selects types that are not enums.
### Predicate.AreNotGeneric
```csharp
PredicateList Predicate.AreNotGeneric()
```
Selects types that do not have generic parameters.
### Predicate.AreNotInterfaces
```csharp
PredicateList Predicate.AreNotInterfaces()
```
Selects types that are not interfaces.
### Predicate.AreNotInternal
```csharp
PredicateList Predicate.AreNotInternal()
```
Selects types that are not declared as internal.
### Predicate.AreNotNested
```csharp
PredicateList Predicate.AreNotNested()
```
Selects types that are not nested.
### Predicate.AreNotPrivate
```csharp
PredicateList Predicate.AreNotPrivate()
```
Selects types that are not declared as private.
### Predicate.AreNotPrivateProtected
```csharp
PredicateList Predicate.AreNotPrivateProtected()
```
Selects types that are not declared as private protected.
### Predicate.AreNotProtected
```csharp
PredicateList Predicate.AreNotProtected()
```
Selects types that are not declared as protected.
### Predicate.AreNotProtectedInternal
```csharp
PredicateList Predicate.AreNotProtectedInternal()
```
Selects types that are not declared as protected internal.
### Predicate.AreNotPublic
```csharp
PredicateList Predicate.AreNotPublic()
```
Selects types that do not have public scope.
### Predicate.AreNotSealed
```csharp
PredicateList Predicate.AreNotSealed()
```
Selects types according that are not marked as sealed.
### Predicate.AreNotStatic
```csharp
PredicateList Predicate.AreNotStatic()
```
Selects types that are not static.
### Predicate.AreNotStructures
```csharp
PredicateList Predicate.AreNotStructures()
```
Selects types that are not structures.
### Predicate.ArePrivate
```csharp
PredicateList Predicate.ArePrivate()
```
Selects types that are declared as private.
### Predicate.ArePrivateProtected
```csharp
PredicateList Predicate.ArePrivateProtected()
```
Selects types that are declared as private protected.
### Predicate.AreProtected
```csharp
PredicateList Predicate.AreProtected()
```
Selects types that are declared as protected.
### Predicate.AreProtectedInternal
```csharp
PredicateList Predicate.AreProtectedInternal()
```
Selects types that are declared as protected internal.
### Predicate.ArePublic
```csharp
PredicateList Predicate.ArePublic()
```
Selects types that have public scope.
### Predicate.AreSealed
```csharp
PredicateList Predicate.AreSealed()
```
Selects types according that are marked as sealed.
### Predicate.AreStatic
```csharp
PredicateList Predicate.AreStatic()
```
Selects types that are static.
### Predicate.AreStructures
```csharp
PredicateList Predicate.AreStructures()
```
Selects types that are structures.
### Predicate.DoNotHaveCustomAttribute
```csharp
PredicateList Predicate.DoNotHaveCustomAttribute(Type attribute)
```
Selects types that are not decorated with a specific custom attribute.
### Predicate.DoNotHaveCustomAttributeOrInherit
```csharp
PredicateList Predicate.DoNotHaveCustomAttributeOrInherit(Type attribute)
```
Selects types that are not decorated with a specific custom attribute or derived one.
### Predicate.DoNotHaveDependencyOnAll
```csharp
PredicateList Predicate.DoNotHaveDependencyOnAll(params string[] dependencies)
```
Selects types that do not have a dependency on all of the supplied types.
### Predicate.DoNotHaveDependencyOnAny
```csharp
PredicateList Predicate.DoNotHaveDependencyOnAny(params string[] dependencies)
```
Selects types that do not have a dependency on any of the supplied types.
### Predicate.DoNotHaveName
```csharp
PredicateList Predicate.DoNotHaveName(params string[] name)
```
Selects types that do not have a particular name.
### Predicate.DoNotHaveNameEndingWith
```csharp
PredicateList Predicate.DoNotHaveNameEndingWith(string end)
```
Selects types whose names do not end with the specified text.
### Predicate.DoNotHaveNameMatching
```csharp
PredicateList Predicate.DoNotHaveNameMatching(string pattern)
```
Selects types according to a regular expression that does not match their name.
### Predicate.DoNotHaveNameStartingWith
```csharp
PredicateList Predicate.DoNotHaveNameStartingWith(params string[] start)
```
Selects types whose names do not start with the specified text.
### Predicate.DoNotImplementInterface
```csharp
PredicateList Predicate.DoNotImplementInterface(Type interfaceType)
```
Selects types that do not implement a particular interface.
### Predicate.DoNotInherit
```csharp
PredicateList Predicate.DoNotInherit(Type type)
```
Selects types that do not inherit a particular type.
### Predicate.DoNotResideInNamespace
```csharp
PredicateList Predicate.DoNotResideInNamespace(string name)
```
Selects types that do not reside in a particular namespace.
### Predicate.DoNotResideInNamespaceContaining
```csharp
PredicateList Predicate.DoNotResideInNamespaceContaining(string name)
```
Selects types whose namespaces contain a particular name part.
### Predicate.DoNotResideInNamespaceEndingWith
```csharp
PredicateList Predicate.DoNotResideInNamespaceEndingWith(string name)
```
Selects types whose namespaces end with a particular name part.
### Predicate.DoNotResideInNamespaceMatching
```csharp
PredicateList Predicate.DoNotResideInNamespaceMatching(string pattern)
```
Selects types whose namespaces do not match a regular expression.
### Predicate.HaveCustomAttribute
```csharp
PredicateList Predicate.HaveCustomAttribute(Type attribute)
```
Selects types that are decorated with a specific custom attribute.
### Predicate.HaveCustomAttributeOrInherit
```csharp
PredicateList Predicate.HaveCustomAttributeOrInherit(Type attribute)
```
Selects types that are decorated with a specific custom attribute or derived one.
### Predicate.HaveDependencyOnAll
```csharp
PredicateList Predicate.HaveDependencyOnAll(params string[] dependencies)
```
Selects types that have a dependency on all of the supplied types.
### Predicate.HaveDependencyOnAny
```csharp
PredicateList Predicate.HaveDependencyOnAny(params string[] dependencies)
```
Selects types that have a dependency on any of the supplied types.
### Predicate.HaveDependencyOtherThan
```csharp
PredicateList Predicate.HaveDependencyOtherThan(params string[] dependencies)
```
Selects types that have a dependency other than any of the supplied dependencies.
### Predicate.HaveName
```csharp
PredicateList Predicate.HaveName(params string[] name)
```
Selects types that have a specific name.
### Predicate.HaveNameEndingWith
```csharp
PredicateList Predicate.HaveNameEndingWith(string end)
```
Selects types whose names end with the specified text.
### Predicate.HaveNameMatching
```csharp
PredicateList Predicate.HaveNameMatching(string pattern)
```
Selects types according to a regular expression matching their name.
### Predicate.HaveNameStartingWith
```csharp
PredicateList Predicate.HaveNameStartingWith(params string[] start)
```
Selects types whose names start with the specified text.
### Predicate.HaveSomeNonNullableMembers
```csharp
PredicateList Predicate.HaveSomeNonNullableMembers()
```
Selects types that have some non-nullable members.
### Predicate.ImplementInterface
```csharp
PredicateList Predicate.ImplementInterface(Type interfaceType)
```
Selects types that implement a particular interface.
### Predicate.Inherit
```csharp
PredicateList Predicate.Inherit(Type type)
```
Selects types that inherit a particular type.
### Predicate.MeetCustomRule
```csharp
PredicateList Predicate.MeetCustomRule(ICustomRule rule)
```
Selects types that meet a custom rule.
### Predicate.OnlyHaveDependencyOn
```csharp
PredicateList Predicate.OnlyHaveDependencyOn(params string[] dependencies)
```
Selects types that have a dependency on any of the supplied types and cannot have any other dependency.
### Predicate.OnlyHaveNullableMembers
```csharp
PredicateList Predicate.OnlyHaveNullableMembers()
```
Selects types that have only nullable members.
### Predicate.ResideInNamespace
```csharp
PredicateList Predicate.ResideInNamespace(string name)
```
Selects types that reside in a particular namespace.
### Predicate.ResideInNamespaceContaining
```csharp
PredicateList Predicate.ResideInNamespaceContaining(string name)
```
Selects types whose namespaces contain a particular name part.
### Predicate.ResideInNamespaceEndingWith
```csharp
PredicateList Predicate.ResideInNamespaceEndingWith(string name)
```
Selects types whose namespaces end with a particular name part.
### Predicate.ResideInNamespaceMatching
```csharp
PredicateList Predicate.ResideInNamespaceMatching(string pattern)
```
Selects types whose namespaces match a regular expression.

## PredicateList
### PredicateList.And
```csharp
Predicate PredicateList.And()
```
Specifies that any subsequent predicates should be treated as "and" conditions.
### PredicateList.GetTypes
```csharp
IEnumerable<IType> PredicateList.GetTypes(Options options = null)
```
Returns the types returned by these predicates.
### PredicateList.Or
```csharp
Predicate PredicateList.Or()
```
Specifies that any subsequent predicates should be treated as part of an "or" condition.
### PredicateList.Should
```csharp
Condition PredicateList.Should()
```
Links a predicate defining a set of classes to a condition that tests them.
### PredicateList.ShouldNot
```csharp
Condition PredicateList.ShouldNot()
```
Links a predicate defining a set of classes to a condition that tests them.
### PredicateList.Slice
```csharp
SlicePredicate PredicateList.Slice()
```
Allows dividing types into groups, also called slices.

## Condition
### Condition.BeAbstract
```csharp
ConditionList Condition.BeAbstract()
```
Selects types that are marked as abstract.
### Condition.BeClasses
```csharp
ConditionList Condition.BeClasses()
```
Selects types that are classes.
### Condition.BeDelegates
```csharp
ConditionList Condition.BeDelegates()
```
Selects types that are delegates.
### Condition.BeEnums
```csharp
ConditionList Condition.BeEnums()
```
Selects types that are enums.
### Condition.BeGeneric
```csharp
ConditionList Condition.BeGeneric()
```
Selects types that have generic parameters.
### Condition.BeImmutable
```csharp
ConditionList Condition.BeImmutable()
```
Selects types that are immutable.
### Condition.BeInterfaces
```csharp
ConditionList Condition.BeInterfaces()
```
Selects types that are interfaces.
### Condition.BeInternal
```csharp
ConditionList Condition.BeInternal()
```
Selects types that are internal.
### Condition.BeMutable
```csharp
ConditionList Condition.BeMutable()
```
Selects types that are mutable.
### Condition.BeNested
```csharp
ConditionList Condition.BeNested()
```
Selects types that are nested.
### Condition.BePrivate
```csharp
ConditionList Condition.BePrivate()
```
Selects types that are private.
### Condition.BePrivateProtected
```csharp
ConditionList Condition.BePrivateProtected()
```
Selects types that are private protected.
### Condition.BeProtected
```csharp
ConditionList Condition.BeProtected()
```
Selects types that are protected.
### Condition.BeProtectedInternal
```csharp
ConditionList Condition.BeProtectedInternal()
```
Selects types that are protected internal.
### Condition.BePublic
```csharp
ConditionList Condition.BePublic()
```
Selects types that are have public scope.
### Condition.BeSealed
```csharp
ConditionList Condition.BeSealed()
```
Selects types according that are marked as sealed.
### Condition.BeStatic
```csharp
ConditionList Condition.BeStatic()
```
Selects types that are static.
### Condition.BeStructures
```csharp
ConditionList Condition.BeStructures()
```
Selects types that are structures.
### Condition.HaveCustomAttribute
```csharp
ConditionList Condition.HaveCustomAttribute(Type attribute)
```
Selects types are decorated with a specific custom attribut.
### Condition.HaveCustomAttributeOrInherit
```csharp
ConditionList Condition.HaveCustomAttributeOrInherit(Type attribute)
```
Selects types that are decorated with a specific custom attribute or derived one.
### Condition.HaveDependencyOnAll
```csharp
ConditionList Condition.HaveDependencyOnAll(params string[] dependencies)
```
Selects types that have a dependency on all of the particular types.
### Condition.HaveDependencyOnAny
```csharp
ConditionList Condition.HaveDependencyOnAny(params string[] dependencies)
```
Selects types that have a dependency on any of the supplied types.
### Condition.HaveDependencyOtherThan
```csharp
ConditionList Condition.HaveDependencyOtherThan(params string[] dependencies)
```
Selects types that have a dependency other than any of the given dependencies.
### Condition.HaveName
```csharp
ConditionList Condition.HaveName(string name)
```
Selects types that have a specific name.
### Condition.HaveNameEndingWith
```csharp
ConditionList Condition.HaveNameEndingWith(string end)
```
Selects types whose names do not end with the specified text.
### Condition.HaveNameMatching
```csharp
ConditionList Condition.HaveNameMatching(string pattern)
```
Selects types according to a regular expression matching their name.
### Condition.HaveNameStartingWith
```csharp
ConditionList Condition.HaveNameStartingWith(string start)
```
Selects types whose names start with the specified text.
### Condition.HaveSomeNonNullableMembers
```csharp
ConditionList Condition.HaveSomeNonNullableMembers()
```
Selects types according to whether they have nullable members.
### Condition.ImplementInterface
```csharp
ConditionList Condition.ImplementInterface(Type interfaceType)
```
Selects types that implement a particular interface.
### Condition.Inherit
```csharp
ConditionList Condition.Inherit(Type type)
```
Selects types that inherit a particular type.
### Condition.MeetCustomRule
```csharp
ConditionList Condition.MeetCustomRule(ICustomRule rule)
```
Selects types that meet a custom rule.
### Condition.NotBeAbstract
```csharp
ConditionList Condition.NotBeAbstract()
```
Selects types that are not marked as abstract.
### Condition.NotBeClasses
```csharp
ConditionList Condition.NotBeClasses()
```
Selects types that are not classes.
### Condition.NotBeDelegates
```csharp
ConditionList Condition.NotBeDelegates()
```
Selects types that are not delegates.
### Condition.NotBeEnums
```csharp
ConditionList Condition.NotBeEnums()
```
Selects types that are not enums.
### Condition.NotBeGeneric
```csharp
ConditionList Condition.NotBeGeneric()
```
Selects types that do not have generic parameters.
### Condition.NotBeInterfaces
```csharp
ConditionList Condition.NotBeInterfaces()
```
Selects types that are not interfaces.
### Condition.NotBeInternal
```csharp
ConditionList Condition.NotBeInternal()
```
Selects types that are not internal.
### Condition.NotBeNested
```csharp
ConditionList Condition.NotBeNested()
```
Selects types that are not nested.
### Condition.NotBePrivate
```csharp
ConditionList Condition.NotBePrivate()
```
Selects types that are not private.
### Condition.NotBePrivateProtected
```csharp
ConditionList Condition.NotBePrivateProtected()
```
Selects types that are not private protected.
### Condition.NotBeProtected
```csharp
ConditionList Condition.NotBeProtected()
```
Selects types that are not protected.
### Condition.NotBeProtectedInternal
```csharp
ConditionList Condition.NotBeProtectedInternal()
```
Selects types that are not protected internal.
### Condition.NotBePublic
```csharp
ConditionList Condition.NotBePublic()
```
Selects types that do not have public scope.
### Condition.NotBeSealed
```csharp
ConditionList Condition.NotBeSealed()
```
Selects types according that are not marked as sealed.
### Condition.NotBeStatic
```csharp
ConditionList Condition.NotBeStatic()
```
Selects types that are not static.
### Condition.NotBeStructures
```csharp
ConditionList Condition.NotBeStructures()
```
Selects types that are not structures.
### Condition.NotHaveCustomAttribute
```csharp
ConditionList Condition.NotHaveCustomAttribute(Type attribute)
```
Selects types that are not decorated with a specific custom attribute.
### Condition.NotHaveCustomAttributeOrInherit
```csharp
ConditionList Condition.NotHaveCustomAttributeOrInherit(Type attribute)
```
Selects types are not decorated with a specific custom attribute or derived one.
### Condition.NotHaveDependencyOnAll
```csharp
ConditionList Condition.NotHaveDependencyOnAll(params string[] dependencies)
```
Selects types that do not have a dependency on all of the particular types.
### Condition.NotHaveDependencyOnAny
```csharp
ConditionList Condition.NotHaveDependencyOnAny(params string[] dependencies)
```
Selects types that do not have a dependency on any of the particular types.
### Condition.NotHaveName
```csharp
ConditionList Condition.NotHaveName(string name)
```
Selects types that do not have a particular name.
### Condition.NotHaveNameEndingWith
```csharp
ConditionList Condition.NotHaveNameEndingWith(string end)
```
Selects types whose names do not end with the specified text.
### Condition.NotHaveNameMatching
```csharp
ConditionList Condition.NotHaveNameMatching(string pattern)
```
Selects types according to a regular expression that does not match their name.
### Condition.NotHaveNameStartingWith
```csharp
ConditionList Condition.NotHaveNameStartingWith(string start)
```
Selects types whose names do not start with the specified text.
### Condition.NotImplementInterface
```csharp
ConditionList Condition.NotImplementInterface(Type interfaceType)
```
Selects types that do not implement a particular interface.
### Condition.NotInherit
```csharp
ConditionList Condition.NotInherit(Type type)
```
Selects types that do not inherit a particular type.
### Condition.NotResideInNamespace
```csharp
ConditionList Condition.NotResideInNamespace(string name)
```
Selects types that do not reside in a particular namespace.
### Condition.NotResideInNamespaceContaining
```csharp
ConditionList Condition.NotResideInNamespaceContaining(string name)
```
Selects types whose namespaces contain a particular name part.
### Condition.NotResideInNamespaceEndingWith
```csharp
ConditionList Condition.NotResideInNamespaceEndingWith(string name)
```
Selects types whose namespaces end with a particular name part.
### Condition.NotResideInNamespaceMatching
```csharp
ConditionList Condition.NotResideInNamespaceMatching(string pattern)
```
Selects types that do not reside in a namespace matching a regular expression.
### Condition.OnlyHaveDependencyOn
```csharp
ConditionList Condition.OnlyHaveDependencyOn(params string[] dependencies)
```
Selects types that have a dependency on any of the supplied types and cannot have any other dependency.
### Condition.OnlyHaveNullableMembers
```csharp
ConditionList Condition.OnlyHaveNullableMembers()
```
Selects types according to whether they have nullable members.
### Condition.ResideInNamespace
```csharp
ConditionList Condition.ResideInNamespace(string name)
```
Selects types that reside in a particular namespace.
### Condition.ResideInNamespaceContaining
```csharp
ConditionList Condition.ResideInNamespaceContaining(string name)
```
Selects types whose namespaces contain a particular name part.
### Condition.ResideInNamespaceEndingWith
```csharp
ConditionList Condition.ResideInNamespaceEndingWith(string name)
```
Selects types whose namespaces end with a particular name part.
### Condition.ResideInNamespaceMatching
```csharp
ConditionList Condition.ResideInNamespaceMatching(string pattern)
```
Selects types that reside in a namespace matching a regular expression.

## ConditionList
### ConditionList.And
```csharp
Condition ConditionList.And()
```
Specifies that any subsequent condition should be treated as an "and" condition.
### ConditionList.GetResult
```csharp
TestResult ConditionList.GetResult(Options options = null)
```
Returns an indication of whether all the selected types satisfy the conditions.
### ConditionList.GetTypes
```csharp
IEnumerable<IType> ConditionList.GetTypes(Options options = null)
```
Returns the list of types that satisfy the conditions.
### ConditionList.Or
```csharp
Condition ConditionList.Or()
```
Specifies that any subsequent conditions should be treated as part of an "or" condition.

## TestResult
### TestResult.FailingTypes
```csharp
FailingTypes
```
Gets a list of the types that failed the test.
### TestResult.IsSuccessful
```csharp
IsSuccessful
```
Gets a flag indicating the success or failure of the test.

## IType
### IType.Explanation
```csharp
Explanation
```
It contains explanation why this Type has failed dependecy search.
### IType.FullName
```csharp
FullName
```
FullName of the type
### IType.Name
```csharp
Name
```
Name of the type
### IType.ReflectionType
```csharp
ReflectionType
```
System.Type

## Options
### Options.Comparer
```csharp
Comparer
```



 


    
