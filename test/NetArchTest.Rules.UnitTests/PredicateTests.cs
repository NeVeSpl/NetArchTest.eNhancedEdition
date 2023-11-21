using System;
using System.Linq;
using System.Reflection;
using NetArchTest.CrossAssemblyTest.A;
using NetArchTest.CrossAssemblyTest.B;
using NetArchTest.Rules;
using NetArchTest.TestStructure.CustomAttributes;
using NetArchTest.TestStructure.Dependencies.Examples;
using NetArchTest.TestStructure.Dependencies.Implementation;
using NetArchTest.TestStructure.Inheritance;
using NetArchTest.TestStructure.Interfaces;
using NetArchTest.TestStructure.Mutability;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.TestStructure.NameMatching.Namespace2;
using NetArchTest.TestStructure.NameMatching.Namespace2.Namespace3;
using NetArchTest.TestStructure.NameMatching.Namespace3.A;
using NetArchTest.TestStructure.NameMatching.Namespace3.B;
using NetArchTest.TestStructure.NamespaceMatching.Namespace1;
using NetArchTest.TestStructure.NamespaceMatching.NamespaceA;
using NetArchTest.TestStructure.Nullable;
using NetArchTest.UnitTests.TestDoubles;
using Xunit;

namespace NetArchTest.UnitTests
{
    public partial class PredicateTests
    {
        [Fact(DisplayName = "Types can be selected by name name.")]
        public void HaveName_MatchFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .HaveName("ClassA1").GetReflectionTypes();

            Assert.Single(result); // Only one type found
            Assert.Equal<Type>(typeof(ClassA1), result.First()); // The correct type found
        }

        [Fact(DisplayName = "Types can be selected if they do not have a specific name.")]
        public void DoNotHaveName_MatchFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .DoNotHaveName("ClassA1").GetReflectionTypes();

            Assert.Equal(8, result.Count()); // Eight types found
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected by the start of their name.")]
        public void HaveNameStarting_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .HaveNameStartingWith("SomeT").GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
        }

        [Fact(DisplayName = "Types can be selected by the start of their name using a StringComparison.")]
        public void HaveNameStarting_UsingExplicitStringComparison_MatchesFound_ClassesSelected()
        {
	        var result = Types
		        .InAssembly(Assembly.GetAssembly(typeof(SomeThing)))
		        .That()
		        .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
		        .And()
		        .HaveNameStartingWith("SomeT", StringComparison.Ordinal).GetReflectionTypes();

	        Assert.Single(result); // One type found
	        Assert.Contains<Type>(typeof(SomeThing), result);
	        Assert.DoesNotContain<Type>(typeof(SomethingElse), result);
        }

        [Fact(DisplayName = "Types can be selected if their name does not have a specific start.")]
        public void DoNotHaveNameStarting_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .DoNotHaveNameStartingWith("ClassA").GetReflectionTypes();

            Assert.Equal(6, result.Count()); // Six types found
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected if their name does not have a specific start using a StringComparison.")]
        public void DoNotHaveNameStarting_UsingExplicitStringComparison_MatchesFound_ClassesSelected()
        {
	        var result = Types
		        .InAssembly(Assembly.GetAssembly(typeof(SomeThing)))
		        .That()
		        .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace3")
		        .And()
		        .DoNotHaveNameStartingWith("SomeT", StringComparison.Ordinal).GetReflectionTypes();

	        Assert.Equal(3, result.Count()); // Three types found
	        Assert.DoesNotContain<Type>(typeof(SomeThing), result);
	        Assert.Contains<Type>(typeof(SomethingElse), result);
	        Assert.Contains<Type>(typeof(SomeEntity), result);
	        Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected by the end of their name.")]
        public void HaveNameEnding_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .HaveNameEndingWith("Entity").GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected by the end of their name using a StringComparison.")]
        public void HaveNameEnding_UsingExplicitStringComparison_MatchesFound_ClassesSelected()
        {
	        var result = Types
		        .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
		        .That()
		        .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
		        .And()
		        .HaveNameEndingWith("Entity", StringComparison.Ordinal).GetReflectionTypes();

	        Assert.Single(result); // One type found
	        Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.DoesNotContain<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected if their name does not have a specific end.")]
        public void DoNotHaveNameEnding_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .DoNotHaveNameEndingWith("A1").GetReflectionTypes();

            Assert.Equal(8, result.Count()); // three types found
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected by a regular expression.")]
        public void HaveNameMatching_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .HaveNameMatching(@"Class\w1").GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not conform to a regular expression.")]
        public void DoNotHaveNameMatching_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .DoNotHaveNameMatching(@"Class\w1").GetReflectionTypes();

            Assert.Equal(7, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }


        [Fact(DisplayName = "Types can be selected by a the presence of a custom attribute.")]
        public void HaveCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .HaveCustomAttribute(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Single(result); // One type found
            Assert.Contains<Type>(typeof(AttributePresent), result);
        }

        [Fact(DisplayName = "Types can be selected by the absence of a custom attribute.")]
        public void DoNotHaveCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .DoNotHaveCustomAttribute(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(4, result.Count()); // Four types found
            Assert.Contains<Type>(typeof(NoAttributes), result);
            Assert.Contains<Type>(typeof(ClassCustomAttribute), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
            Assert.Contains<Type>(typeof(InheritClassCustomAttribute), result);
        }

        [Fact(DisplayName = "Types can be selected by the presence of an inherited custom attribute.")]
        public void HaveInheritCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .HaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(AttributePresent), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
        }

        [Fact(DisplayName = "Types can be selected by the absence of an inherited custom attribute.")]
        public void DoNotHaveInheritCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .DoNotHaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(3, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(NoAttributes), result);
            Assert.Contains<Type>(typeof(ClassCustomAttribute), result);          
            Assert.Contains<Type>(typeof(InheritClassCustomAttribute), result);
        }

        [Fact(DisplayName = "Types can be selected if they inherit from a type.")]
        public void Inherit_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .Inherit(typeof(BaseClass)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(DerivedClass), result);
            Assert.Contains<Type>(typeof(DerivedDerivedClass), result);
        }

        [Fact(DisplayName = "Types can be selected if they inherit from a type from a different assembly")]
        public void Inherit_MatchesFound_ClassesSelected_AcrossAssemblies()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(DerivedClassFromB)))
                .That()
                .Inherit(typeof(BaseClassFromA))
                .GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains(typeof(DerivedClassFromB), result);
            Assert.Contains(typeof(AnotherDerivedClassFromB), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not inherit from a type.")]
        public void DoNotInherit_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .DoNotInherit(typeof(BaseClass)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(BaseClass), result);
            Assert.Contains<Type>(typeof(NotDerivedClass), result);
        }

        [Fact(DisplayName = "Types can be selected if they implement an interface.")]
        public void ImplementInterface_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .ImplementInterface(typeof(IExample)).GetReflectionTypes();

            Assert.Single(result); // One type found
            Assert.Contains<Type>(typeof(ImplementsExampleInterface), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not implement an interface.")]
        public void DoNotImplementInterface_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .DoNotImplementInterface(typeof(IExample)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(IExample), result);
            Assert.Contains<Type>(typeof(DoesNotImplementInterface), result);
        }

      

        [Fact(DisplayName = "Types can be selected for being immutable.")]
        public void AreImmutable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .AreImmutable().GetReflectionTypes();

            Assert.Equal(4, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(ImmutableClass1), result);
            Assert.Contains<Type>(typeof(ImmutableClass2), result);
            Assert.Contains<Type>(typeof(ImmutableClass3), result);
            Assert.Contains<Type>(typeof(ImmutableRecord1), result);
        }

        [Fact(DisplayName = "Types can be selected for being mutable.")]
        public void AreMutable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .AreMutable().GetReflectionTypes();

            Assert.Equal(3, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(PartiallyMutableClass1), result);
            Assert.Contains<Type>(typeof(PartiallyMutableClass2), result);
            Assert.Contains<Type>(typeof(MutableClass), result);
        }

        [Fact(DisplayName = "Types can be selected for having only nullable memebers.")]
        public void AreNullable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested() // ignore nested helper types
                .And()
                .AreClasses()
                .And()
                .OnlyHaveNullableMembers().GetReflectionTypes();

            Assert.Single(result); // One result
            Assert.Contains<Type>(typeof(NullableClass), result);
        }

        [Fact(DisplayName = "Types can be selected for having non-nullable memebers.")]
        public void AreNonNullable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested() // ignore nested helper types
                .And()
                .ArePublic()
                .And()
                .HaveSomeNonNullableMembers().GetReflectionTypes();

            Assert.Equal(4, result.Count()); // Four types found
            Assert.Contains<Type>(typeof(NonNullableClass1), result);
            Assert.Contains<Type>(typeof(NonNullableClass2), result);
            Assert.Contains<Type>(typeof(NonNullableClass3), result);
            Assert.Contains<Type>(typeof(NonNullableClass4), result);
        }



        [Fact(DisplayName = "Types can be selected if they reside in a namespace.")]
        public void ResideInNamespace_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(3, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not reside in a namespace.")]
        public void DoNotResideInNamespace_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And()
                .DoNotResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace2")
                .GetReflectionTypes();

            Assert.Equal(7, result.Count()); // Seven types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected if they reside in a namespace that matches a regular expression.")]
        public void ResideInNamespaceMatching_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespaceMatching(@"NetArchTest.TestStructure.NamespaceMatching.Namespace\d")
                .GetReflectionTypes();

            Assert.Single(result); // One type found
            Assert.Contains<Type>(typeof(Match1), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not reside in a namespace that matches a regular expression.")]
        public void DoNotResideInNamespaceMatching_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NamespaceMatching")
                .And()
                .DoNotResideInNamespaceMatching(@"NetArchTest.TestStructure.NamespaceMatching.Namespace\d")
                .GetReflectionTypes();

            Assert.Single(result); // One type found
            Assert.Contains<Type>(typeof(MatchA), result);
        }

        [Fact(DisplayName = "Types can be selected if they reside in a namespace that starts with a name part.")]
        public void ResideInNamespaceStartingWith_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching")
                .GetReflectionTypes();

            Assert.Equal(9, result.Count()); // Nine types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not reside in a namespace that start with name part.")]
        public void DoNotResideInNamespaceStartingWith_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching")
                .And()
                .DoNotResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching.Namespace2")
                .GetReflectionTypes();

            Assert.Equal(7, result.Count()); // Seven types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected if they reside in a namespace that ends with a name part.")]
        public void ResideInNamespaceEndingWith_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespaceEndingWith(".NameMatching.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(3, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(ClassA1), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not reside in a namespace that end with name part.")]
        public void DoNotResideInNamespaceEndingWith_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching")
                .GetReflectionTypes();

            Assert.Equal(9, result.Count()); // Nine types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected if they reside in a namespace that contains a name part.")]
        public void ResideInNamespaceContaining_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespaceContaining(".NameMatching.")
                .GetReflectionTypes();

            Assert.Equal(9, result.Count()); // Nine types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        

        [Fact(DisplayName = "Types can be selected if they do not reside in a namespace that contains name part.")]
        public void DoNotResideInNamespaceContaining_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching")
                .And()
                .DoNotResideInNamespaceContaining("Namespace2")
                .GetReflectionTypes();

            Assert.Equal(7, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Selecting by namespace will return types in nested namespaces.")]
        public void ResideInNamespace_Nested_AllClassReturned()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .GetReflectionTypes();

            // Should return all the types that are in three nested namespaces
            Assert.Equal(9, result.Count()); // Nine types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "Types can be selected if they have a dependency on a specific item.")]
        public void HaveDepencency_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And()
                .HaveDependencyOnAny(typeof(ExampleDependency).FullName)
                .GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Equal<Type>(typeof(HasDependencies), result.First());
            Assert.Equal<Type>(typeof(HasDependency), result.Last());
        }

        [Fact(DisplayName = "Types can be selected if they have a dependency on any item in a list.")]
        public void HaveDepencencyOnAny_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And()
                .HaveDependencyOnAny(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetReflectionTypes();

            Assert.Equal(3, result.Count()); // Three types found - i.e. the classes with dependencies on at least one of the items
            Assert.Equal<Type>(typeof(HasAnotherDependency), result.First());
            Assert.Equal<Type>(typeof(HasDependencies), result.Skip(1).First());
            Assert.Equal<Type>(typeof(HasDependency), result.Last());
        }

        [Fact(DisplayName = "Types can be selected if they have a dependency on all the items in a list.")]
        public void HaveDepencencyOnAll_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And()
                .HaveDependencyOnAll(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetReflectionTypes();

            Assert.Single(result); // Only one type found - i.e. the class with dependencies on both items
            Assert.Equal<Type>(typeof(HasDependencies), result.First()); // The correct type found
        }

        [Fact(DisplayName = "Types can be selected if they only have a dependency on any item in a list.")]
        public void OnlyHaveDependenciesOn_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And()
                .OnlyHaveDependencyOn(new[] { typeof(ExampleDependency).FullName, "System" })
                .GetReflectionTypes();

            Assert.Equal(2, result.Count());          
            Assert.Equal<Type>(typeof(HasDependency), result.First());
            Assert.Equal<Type>(typeof(NoDependency), result.Skip(1).First());
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on another type.")]
        public void DoNotHaveDepencency_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And()
                .DoNotHaveDependencyOnAny(typeof(ExampleDependency).FullName)
                .GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Equal<Type>(typeof(HasAnotherDependency), result.First());
            Assert.Equal<Type>(typeof(NoDependency), result.Last());
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on any item in a list.")]
        public void DoNotHaveDependencyOnAny_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And()
                .DoNotHaveDependencyOnAny(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetReflectionTypes();

            Assert.Single(result); // Only one type found
            Assert.Equal<Type>(typeof(NoDependency), result.First()); // The correct type found - i.e. it's the only type with no matching dependencies at all
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on all the items in a list.")]
        public void DoNotHaveDependencyOnAll_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And()
                .DoNotHaveDependencyOnAll(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetReflectionTypes();

            Assert.Equal(3, result.Count()); // Three types found - i.e. the classes with dependencies on at least one of the items
            Assert.Equal<Type>(typeof(HasAnotherDependency), result.First());
            Assert.Equal<Type>(typeof(HasDependency), result.Skip(1).First());
            Assert.Equal<Type>(typeof(NoDependency), result.Last());
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on any item in a list.")]
        public void HaveDependenciesOtherThan_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And()
                .HaveDependencyOtherThan(new[] { typeof(ExampleDependency).FullName, "System" })
                .GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal<Type>(typeof(HasAnotherDependency), result.First());
            Assert.Equal<Type>(typeof(HasDependencies), result.Skip(1).First());
        }

        [Fact(DisplayName = "Types can be selected according to a custom rule.")]
        public void MeetCustomRule_MatchesFound_ClassSelected()
        {
            // Create a custom rule that selects "ClassA1"
            var rule = new CustomRuleTestDouble(t => t.Name.Equals("ClassA1", StringComparison.InvariantCultureIgnoreCase));

            // Use the custom rule
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .MeetCustomRule(rule)
                .GetReflectionTypes();

            // ClassA1 has been returned
            Assert.Single(result);
            Assert.Equal<Type>(typeof(ClassA1), result.First());

            // The custom rule was executed at least once
            Assert.True(rule.TestMethodCalled);
        }
    }
}
