namespace NetArchTest.Dependencies
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    internal static class TypeParser
    {
        static readonly Type MonoTypeParserType = Type.GetType("Mono.Cecil.TypeParser, " + typeof(Mono.Cecil.TypeReference).Assembly);
        static readonly Type MonoTypeType = Type.GetType("Mono.Cecil.TypeParser+Type, " + typeof(Mono.Cecil.TypeReference).Assembly);
        static readonly MethodInfo MonoParseTypeMethod = MonoTypeParserType.GetMethod("ParseType", BindingFlags.Instance | BindingFlags.NonPublic);
        static readonly FieldInfo MonoTypeFullnameField = MonoTypeType.GetField("type_fullname", BindingFlags.Instance | BindingFlags.Public);
        static readonly FieldInfo MonoNestedNamesField = MonoTypeType.GetField("nested_names", BindingFlags.Instance | BindingFlags.Public);
        static readonly FieldInfo MonoGenericArgumentsField = MonoTypeType.GetField("generic_arguments", BindingFlags.Instance | BindingFlags.Public);
        static readonly FieldInfo MonoSpecsField = MonoTypeType.GetField("specs", BindingFlags.Instance | BindingFlags.Public);

        public static IEnumerable<string> Parse(string fullName, bool parseNames)
        {
            if (parseNames == false)
            {
                yield return fullName;
                yield break;
            }

            var monoTypeParser = Activator.CreateInstance(MonoTypeParserType, BindingFlags.Instance | BindingFlags.NonPublic, null, args:
                [fullName], null);
            var monoType = MonoParseTypeMethod.Invoke(monoTypeParser, [false]);
            foreach (var token in WalkThroughMonoType(monoType))
            {
                yield return token;
            }
        }

        private static IEnumerable<string> WalkThroughMonoType(object monoType)
        {
            yield return MonoTypeFullnameField.GetValue(monoType) as string;

            var nested = MonoNestedNamesField.GetValue(monoType) as string[];
            if (nested != null)
            {
                foreach (var nestedName in nested)
                {
                    yield return nestedName;
                }
            }

            var generics = MonoGenericArgumentsField.GetValue(monoType) as object[];
            if (generics != null)
            {
                yield return "<";
                foreach (var generic in generics)
                {
                    foreach (var token in WalkThroughMonoType(generic))
                    {
                        yield return token;
                    }
                    yield return ",";
                }
            }

            var specs = MonoSpecsField.GetValue(monoType) as int[];
            if (specs != null)
            {
                for (int i = 0; i < specs.Length; ++i)
                {
                    if (specs[i] == -1)
                    {
                        yield return "*";
                    }
                    if (specs[i] == -2)
                    {
                        yield return "&";
                    }
                    if (specs[i] == -3)
                    {
                        yield return "[]";
                    }
                    if (specs[i] >= 2)
                    {
                        yield return "[,]";
                    }
                }
            }
        }

        public static string ParseReflectionNameToRuntimeName(string fullName)
        {
            var monoTypeParser = Activator.CreateInstance(MonoTypeParserType, BindingFlags.Instance | BindingFlags.NonPublic, null, args:
                [fullName], null);
            var monoType = MonoParseTypeMethod.Invoke(monoTypeParser, [false]);
            return string.Concat(WalkThroughMonoType2(monoType));
        }

        private static IEnumerable<string> WalkThroughMonoType2(object monoType)
        {
            yield return MonoTypeFullnameField.GetValue(monoType) as string;

            var nested = MonoNestedNamesField.GetValue(monoType) as string[];
            if (nested != null)
            {
                foreach (var nestedName in nested)
                {
                    yield return "/";
                    yield return nestedName;
                }
            }

            var generics = MonoGenericArgumentsField.GetValue(monoType) as object[];
            if (generics != null)
            {
                yield return "<";
                for (int i = 0; i < generics.Length; i++)
                {
                    object generic = generics[i];
                    foreach (var token in WalkThroughMonoType(generic))
                    {
                        yield return token;
                    }
                    if (i < generics.Length - 1)
                    {
                        yield return ",";
                    }
                }
                yield return ">";
            }

            var specs = MonoSpecsField.GetValue(monoType) as int[];
            if (specs != null)
            {
                for (int i = 0; i < specs.Length; ++i)
                {
                    if (specs[i] == -1)
                    {
                        yield return "*";
                    }
                    if (specs[i] == -2)
                    {
                        yield return "&";
                    }
                    if (specs[i] == -3)
                    {
                        yield return "[]";
                    }
                    if (specs[i] >= 2)
                    {
                        yield return "[,]";
                    }
                }
            }
        }
    }
}