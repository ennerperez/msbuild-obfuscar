using System;

namespace MSBuild.Obfuscar.Example
{
    public class Program
    {
        public static string message1 = "You can read this!";
        private static string message2 = "And you can read this!";

        private static void Main(string[] args)
        {
            var message3 = "But you can read this?";
            Console.WriteLine(message1);
            Console.WriteLine(message2);
            Console.WriteLine(message3);
            Console.ReadKey();
        }
    }
}
