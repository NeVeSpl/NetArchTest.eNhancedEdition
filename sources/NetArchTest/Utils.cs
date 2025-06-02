namespace NetArchTest
{
    public static class Utils
    {
        public static string fullnameof<T>() => typeof(T).FullName;
        public static string namespaceof<T>() => typeof(T).Namespace;
    }
}