namespace NetArchTest.UnitTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NetArchTest.Rules.Extensions;
    using NetArchTest.Functions;
    using NetArchTest.TestStructure.Abstract;
    using NetArchTest.TestStructure.NameMatching.Namespace2.Namespace3;
    using Xunit;
    using NetArchTest.Rules;

    public class FunctionSequenceTests
    {
        [Fact(DisplayName = "Setting the Selected flag to false will return the types that fail the sequence.")]
        public void Execute_SelectedFalse_ReturnsFailedTypes()
        {
            // Arrange
            var sequence = new FunctionSequence();
            sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, true));

            var types = Types
            .InAssembly(Assembly.GetAssembly(typeof(AbstractClass)))
            .That()
            .ResideInNamespace("NetArchTest.TestStructure.Abstract")
            .GetTypeSpecifications();

            // Act
            var resultSelected = sequence.Execute(types).Select(t => t.Definition.ToType());
            var resultNotSelected = sequence.ExecuteExtended(types, selected: false).Select(t => t.Definition.ToType());

            // Assert
            // The default behaviour is to return the types that were selected
            Assert.Single(resultSelected);
            Assert.Contains<Type>(typeof(AbstractClass), resultSelected);

            // Setting the flag to false will return the types that were NOT selected
            Assert.Single(resultNotSelected);
            Assert.Contains<Type>(typeof(ConcreteClass), resultNotSelected);
        }

        [Fact(DisplayName = "Setting the Selected flag to false will return the types that fail the sequence in OR based statements (Issue #38).")]
        public void Execute_SelectedFalseOrStatements_ReturnsFailedTypes()
        {
            // Arrange
            // Set up a sequence that has an OR condition in it
            var sequence = new FunctionSequence();
            sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, "ClassA", true));
            sequence.CreateGroup();
            sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, "ClassB1", true));

            var types = Types
            .InAssembly(Assembly.GetAssembly(typeof(ClassB2)))
            .That()
            .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
            .And()
            .DoNotResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace3")
            .GetTypeSpecifications();

            // Act
            var resultSelected = sequence.Execute(types).Select(t => t.Definition.ToType());
            var resultNotSelected = sequence.ExecuteExtended(types, selected: false).Select(t => t.Definition.ToType());

            // Assert
            // The default behaviour is to return the types that were selected - i.e. everything except ClassB2
            Assert.Equal(4, resultSelected.Count());
            Assert.DoesNotContain<Type>(typeof(ClassB2), resultSelected);

            // Setting the flag to false will return the types that were NOT selected, i.e. just ClassB2
            Assert.Single(resultNotSelected);
            Assert.Contains<Type>(typeof(ClassB2), resultNotSelected);
        }
    }
}
