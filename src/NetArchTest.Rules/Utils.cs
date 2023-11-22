namespace NetArchTest
{
    public class Utils
    {
        public static string fullnameof<T>() => typeof(T).FullName;
        public static string namespaceof<T>() => typeof(T).Namespace;
    }
}