using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Singleton;
using DesignPatterns.Prototype;
using DesignPatterns.Factory;
using DesignPatterns.Builder;
using DesignPatterns.Decorator;

namespace DesignPatterns {
    class Program {
        static void Main(string[] args) {
            const string dashes = "-----";

            Console.WriteLine(string.Format("{0}Singleton{0}", dashes));
            SingletonTest.Run();
            Console.WriteLine(string.Format("{0}Prototype{0}", dashes));
            PrototypeTest.Run();
            Console.WriteLine(string.Format("{0}Factory{0}", dashes));
            FactoryTest.Run();
            Console.WriteLine(string.Format("{0}Builder{0}", dashes));
            BuilderTest.Run();
            Console.WriteLine(string.Format("{0}Decorator{0}", dashes));
            DecoratorTest.Run();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
