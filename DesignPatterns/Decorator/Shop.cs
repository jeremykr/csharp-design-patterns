using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Decorator {
    class Shop {
        public string Name { get; set; }
        public string Address { get; protected set; }
        public string DirectoryNumber { get; set; }
        public int DateEstablished { get; protected set; }

        protected string dots = "..........";

        public virtual void ListDirectories() {
            Console.WriteLine("Directories:");
            Console.WriteLine("Front desk{0}{1}", dots, DirectoryNumber);
        }

        public void ListInfo() {
            Console.WriteLine(
                "{0}, {1}, est. {2}",
                Name, Address, DateEstablished
            );
        }

        public Shop (string name, string address, string dn) {
            Name = name;
            Address = address;
            DateEstablished = DateTime.Now.Year;
            DirectoryNumber = dn;
        }
    }

    class GroceryStore : Shop {
        /* The Shop object to be decorated */
        private Shop shop;

        public GroceryStore(Shop s, string dn) :
            base(s.Name, s.Address, dn) {
            shop = s;
            DateEstablished = s.DateEstablished;
        }

        public override void ListDirectories() {
            shop.ListDirectories();
            Console.WriteLine("Grocery{0}{1}", dots, DirectoryNumber);
        }
    }

    class LiquorStore : Shop {
        /* The Shop object to be decorated */
        private Shop shop;

        public LiquorStore(Shop s, string dn) :
            base(s.Name, s.Address, dn) {
            shop = s;
            DateEstablished = s.DateEstablished;
        }

        public override void ListDirectories() {
            shop.ListDirectories();
            Console.WriteLine("Liquor{0}{1}", dots, DirectoryNumber);
        }
    }

    class DecoratorTest {
        
        [TestMethod]
        public static void Run() {
            Shop s = new Shop("VirtualMart", "1234 West Nowhere Ave.", "555-7392");
            GroceryStore g = new GroceryStore(s, "555-7302");
            LiquorStore l = new LiquorStore(g, "555-1027");
            l.ListInfo();
            l.ListDirectories();
        }
    }
}
