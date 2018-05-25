using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/* -- Prototype --
 * 
 * The Prototype design pattern is marked by
 * the Clone() method, which allows users to clone
 * an existing prototypical object instead of 
 * directly creating a new one using "new".
*/
namespace DesignPatterns.Prototype {

    abstract class Prototype<T> {
        abstract public T Clone();
    }

    class Sheep : Prototype<Sheep> {

        private Sheep() { }

        public static Sheep Prototype { get; private set; } 
            = new Sheep();

        public string Name { get; set; } 
            = "Anonymous Sheep";

        public override Sheep Clone() {
            Sheep clone = new Sheep();
            clone.Name = Name;
            return clone;
        }
    }

    class PrototypeTest {

        [TestMethod]
        public static void Run() {

            try {
                Assert.AreEqual(
                    Sheep.Prototype.Name, 
                    Sheep.Prototype.Clone().Name
                );
            } catch (AssertFailedException e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(string.Format(
                "Sheep prototype: {0}",
                Sheep.Prototype.Name
            ));

            Sheep dolly = Sheep.Prototype.Clone();
            dolly.Name = "Dolly";

            Console.WriteLine(string.Format(
                "Cloned new sheep: {0}",
                dolly.Name
            ));

            try {
                Assert.AreNotEqual(Sheep.Prototype, dolly);
            } catch (AssertFailedException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
