using Mono.Cecil;
using NetArchTest.Assemblies;
using NetArchTest.Rules;

namespace NetArchTest.Dependencies
{
    internal class TypeCheckingContext
    {      
        private readonly bool _serachForDependencyInFieldConstant;
        private readonly bool explainYourself;
        private readonly IDependencyFilter dependencyFilter;
        private TypeSpec _typeToCheck;
        private ITypeCheckingStrategy _result;


        public TypeCheckingContext(bool serachForDependencyInFieldConstant = false, bool explainYourself = false, IDependencyFilter dependencyFilter = null)
        {          
            _serachForDependencyInFieldConstant = serachForDependencyInFieldConstant;
            this.explainYourself = explainYourself;
            this.dependencyFilter = dependencyFilter;
        }


        public void PerformCheck(TypeSpec typeToCheck, ITypeCheckingStrategy checkingStrategy)
        {
            _typeToCheck = typeToCheck;
            _result = checkingStrategy;

            CheckType(_typeToCheck.Definition);
            if (explainYourself)
            {
                _typeToCheck.Explanation = _result.ExplainWhy();
            }            
        }


        /// <summary>
        /// Finds matching dependencies for a given type by walking through the type.
        /// </summary>
        private void CheckType(TypeDefinition type)
        {
            CheckBaseType(type);
            CheckCustomAttributes(type);
            CheckImplementedInterfaces(type);
            CheckGenericTypeParametersConstraints(type);
            CheckFields(type);
            if (_result.CanWeSkipFurtherSearch()) return;
            CheckProperties(type);
            if (_result.CanWeSkipFurtherSearch()) return;
            CheckEvents(type);
            if (_result.CanWeSkipFurtherSearch()) return;
            CheckMethods(type);
            if (_result.CanWeSkipFurtherSearch()) return;
            CheckNestedCompilerGeneratedTypes(type);
        }

        private void CheckBaseType(TypeDefinition typeToCheck)
        {
            if (typeToCheck.BaseType != null)
            {
                CheckTypeReference(typeToCheck.BaseType);
            }
        }
        private void CheckCustomAttributes(ICustomAttributeProvider typeToCheck)
        {
            if (typeToCheck.HasCustomAttributes)
            {
                foreach (var customAttribute in typeToCheck.CustomAttributes)
                {
                    CheckTypeReference(customAttribute.AttributeType);
                }
            }
        }    
        private void CheckImplementedInterfaces(TypeDefinition typeToCheck)
        {
            if (typeToCheck.HasInterfaces)
            {
                foreach (var @interface in typeToCheck.Interfaces)
                {
                    CheckTypeReference(@interface.InterfaceType);
                }
            }
        }
        private void CheckGenericTypeParametersConstraints(IGenericParameterProvider typeToCheck)
        {
            if (typeToCheck.HasGenericParameters)
            {
                foreach (var parameter in typeToCheck.GenericParameters)
                {
                    if (parameter.HasConstraints)
                    {
                        foreach (var constraint in parameter.Constraints)
                        {
                            CheckTypeReference(constraint.ConstraintType);
                        }
                    }
                }
            }
        }
        private void CheckFields(TypeDefinition typeToCheck)
        {
            if (typeToCheck.HasFields)
            {
                foreach (var field in typeToCheck.Fields)
                {
                    CheckCustomAttributes(field);
                    CheckTypeReference(field.FieldType);
                    if (_serachForDependencyInFieldConstant && field.HasConstant && field.FieldType.FullName == typeof(string).FullName && field.Constant != null)
                    {
                        _result.CheckType(field.Constant.ToString());
                    }
                }
            }
        }
        private void CheckProperties(TypeDefinition typeToCheck)
        {
            if (typeToCheck.HasProperties)
            {
                foreach (var property in typeToCheck.Properties)
                {
                    CheckCustomAttributes(property);
                    CheckTypeReference(property.PropertyType);
                }
            }
        }
        private void CheckEvents(TypeDefinition typeToCheck)
        {
            if (typeToCheck.HasEvents)
            {
                foreach (var @event in typeToCheck.Events)
                {
                    CheckCustomAttributes(@event);
                    CheckTypeReference(@event.EventType);

                    if (@event.HasOtherMethods) // are we sure that event can have other methods? TODO : we need unit test for this case
                    {
                        foreach (var method in @event.OtherMethods)
                        {
                            CheckMethodHeader(method);
                            CheckMethodBodyVariables(method);
                            CheckMethodBodyInstructions(method);
                        }
                    }
                }
            }
        }
        private void CheckMethods(TypeDefinition typeToCheck)
        {
            if (typeToCheck.HasMethods)
            {
                // checking method body is the most costly checking from all, 
                // therefore we want to do it as late as possible and end as fast as we can
                foreach (var method in typeToCheck.Methods)
                {
                    if (_result.CanWeSkipFurtherSearch()) return;
                    CheckMethodHeader(method);
                }

                foreach (var method in typeToCheck.Methods)
                {
                    if (_result.CanWeSkipFurtherSearch()) return;
                    CheckMethodBodyVariables(method);
                }

                foreach (var method in typeToCheck.Methods)
                {
                    if (_result.CanWeSkipFurtherSearch()) return;
                    CheckMethodBodyInstructions(method);
                }
            }
        }
        private void CheckNestedCompilerGeneratedTypes(TypeDefinition typeToCheck)
        {
            if (typeToCheck.HasNestedTypes)
            {
                foreach (var nested in typeToCheck.NestedTypes)
                {
                    if (nested.IsCompilerGenerated())
                    {
                        if (_result.CanWeSkipFurtherSearch()) return;
                        this.CheckType(nested);
                    }
                }
            }
        }
        private void CheckMethodHeader(MethodDefinition methodToCheck)
        {
            CheckCustomAttributes(methodToCheck);
            CheckGenericTypeParametersConstraints(methodToCheck);
            CheckCustomAttributes(methodToCheck.MethodReturnType);
            CheckTypeReference(methodToCheck.ReturnType);

            if (methodToCheck.HasParameters)
            {
                foreach (var parameter in methodToCheck.Parameters)
                {
                    CheckCustomAttributes(parameter);
                    CheckTypeReference(parameter.ParameterType);
                }
            }
        }
        private void CheckMethodBodyVariables(MethodDefinition methodToCheck)
        {
            if (methodToCheck.HasBody)
            {
                if (methodToCheck.Body.HasVariables)
                {
                    foreach (var variable in methodToCheck.Body.Variables)
                    {
                        CheckTypeReference(variable.VariableType);
                    }
                }
            }
        }
        private void CheckMethodBodyInstructions(MethodDefinition methodToCheck)
        {
            if (methodToCheck.HasBody)
            {
                foreach (var instruction in methodToCheck.Body.Instructions)
                {
                    switch (instruction.Operand)
                    {
                        case TypeReference reference:
                            CheckTypeReference(reference);
                            break;
                        case GenericInstanceMethod genericInstanceMethod:
                            CheckTypeReference(genericInstanceMethod.DeclaringType);
                            if (genericInstanceMethod.HasGenericArguments)
                            {
                                foreach (var argument in genericInstanceMethod.GenericArguments)
                                {
                                    CheckTypeReference(argument);
                                }
                            }
                            break;
                        case FieldReference fieldReference:
                            if (fieldReference.DeclaringType != _typeToCheck.Definition)
                            {
                                CheckTypeReference(fieldReference.DeclaringType);
                            }
                            break;
                        case MethodReference methodReference:
                            if (methodReference.DeclaringType != _typeToCheck.Definition)
                            {
                                CheckTypeReference(methodReference.DeclaringType);
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Recursively checks every array, generic or not type reference
        /// <example>
        /// for closed generic : List{Tuple{Task{int}, int}}
        /// it will check: List{Tuple{Task{int}, int}}, Tuple{Task{int}, int}, Task{int}, int, int
        /// for open generic : List{T}
        /// only List will be checked, T as a generic parameter will be skipped
        /// for arrays: int[][]
        /// it will check : int[][], int[], int
        /// </example>         
        /// </summary>      
        private void CheckTypeReference(TypeReference reference)
        {          
            if (reference.IsGenericParameter == true) return;
           
            if ((reference.IsArray) || (reference.IsPointer) || (reference.IsByReference))
            {
                var referenceAsTypeSpecification = reference as TypeSpecification;
                if (referenceAsTypeSpecification.ElementType?.IsGenericParameter == true) return;

                CheckTypeReference(referenceAsTypeSpecification.ElementType);
            }

            CheckDependency(reference);

            if (reference.IsGenericInstance == true)
            {
                var referenceAsGenericInstance = reference as GenericInstanceType;
                if (referenceAsGenericInstance.HasGenericArguments)
                {
                    foreach (var genericArgument in referenceAsGenericInstance.GenericArguments)
                    {
                        CheckTypeReference(genericArgument);
                    }
                }
            }            
        }
        private void CheckDependency(TypeReference dependency)
        {            
            if (dependencyFilter?.ShouldDependencyBeChecked(dependency) == false)
            {
                return;
            }      
            
            _result.CheckType(dependency);           
        }
    }
}