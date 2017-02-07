namespace ConsoleTester.Testers
{
    using Entity;
    using System;
    using System.Reflection;

    public class PropValueTester
    {
        static void Main(string[] args)
        {
            try
            {
                var obj = new Person { Id = 101, PeresonName = "Sairam" };
                var propName = "pereson_Name".Replace("_", "").ToString();
                var propValue = GetPropValue(obj, propName);
                Console.WriteLine(propValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            return src
                .GetType()
                .GetProperty(propName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance)
                .GetValue(src, null);
        }
    }
}
