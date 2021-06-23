using System;

namespace MSBuild.Obfuscar.Core.Test
{
    public class Program
    {
        public static string message1 = "You can read this!";
        private static string message2 = "and you can read this!";
        static void Main(string[] args)
        {
            Console.WriteLine(message1);
            Console.WriteLine(message2);
            Console.ReadKey();
        }
    }
}
