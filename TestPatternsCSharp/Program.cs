using System;

namespace TestPatternsCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Singleton Pattern!");

            static void Main(string[] args)
            {
                // The client code.
                SingletonNonThreadSafe s1 = SingletonNonThreadSafe.GetInstance();
                SingletonNonThreadSafe s2 = SingletonNonThreadSafe.GetInstance();

                if (s1 == s2)
                {
                    Console.WriteLine("Singleton works, both variables contain the same instance.");
                }
                else
                {
                    Console.WriteLine("Singleton failed, variables contain different instances.");
                }
            }
        }
    }
}
