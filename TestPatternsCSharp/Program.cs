using System;
using System.Threading;

namespace TestPatternsCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select option: ");
            Console.WriteLine("1-Singleton NonThreadSafe, 2-Singleton ThreadSafe");

            Console.WriteLine("----");
            String option = Console.ReadLine();

            Console.WriteLine("Line {0}", option);

            switch (option)
            {
                case "1":
                    TestSingleton();
                    break;
                case "2":
                    TestSingletonThreadSafe();
                    break;
            }
        }

        static void TestSingleton()
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

        static void TestSingletonThreadSafe()
        {
            // The client code.

            Console.WriteLine(
                "{0}\n{1}\n\n{2}\n",
                "If you see the same value, then singleton was reused (yay!)",
                "If you see different values, then 2 singletons were created (so baaad!!)",
                "RESULT:"
            );

            Thread process1 = new Thread(() =>
            {
                ExecuteSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                ExecuteSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        public static void ExecuteSingleton(string value)
        {
            SingletonThreadSafe singleton = SingletonThreadSafe.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}
