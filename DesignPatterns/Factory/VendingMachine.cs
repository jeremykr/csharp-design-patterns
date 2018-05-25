using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DesignPatterns.Factory {

    abstract class VendingItem {
        public string Name { get; set; }
        public float Price { get; set; }
    }

    class SnackItem : VendingItem { }

    class BeverageItem : VendingItem { }

    abstract class VendingMachine {

        protected List<VendingItem> Inventory
            = new List<VendingItem>();

        private float balance = 0F;

        public void DisplayBalance() {
            Console.WriteLine(string.Format(
                "Current balance: ${0:0.00}",
                balance
            ));
        }

        public virtual void DisplayInventory() {
            for (int i = 0; i < Inventory.Count; i++) {
                var item = Inventory[i];

                Console.WriteLine(string.Format(
                    "{0} {1} ..... ${2:0.00}",
                    i, item.Name, item.Price
                ));
            }
        }

        public void AddMoney(float amount) {
            balance += amount;
            Console.WriteLine(string.Format(
                "You have added ${0:0.00}",
                amount
            ));
        }

        public VendingItem MakeSelection(int choice) {
            if (choice >= Inventory.Count) {
                Console.WriteLine(string.Format(
                    "{0} is not a valid choice!\n" +
                    "Please make a selection between {1} and {2}.",
                    choice, 0, Inventory.Count
                ));
            }
            else if (Inventory[choice].Price > balance) {
                Console.WriteLine(
                    "You do not have enough money to make that selection."
                );
            }
            else {
                balance -= Inventory[choice].Price;
                Console.WriteLine("Selection made!");
                GiveChange();
                return DispenseItem(choice);
            }
            return null;
        }

        public void GiveChange() {
            Console.WriteLine(string.Format(
                "Your change is ${0:0.00}",
                balance
            ));
        }

        abstract public void AddItem(string name, float price);
        abstract protected VendingItem DispenseItem(int i);
    }

    class SnackVendingMachine : VendingMachine {

        public override void AddItem(string name, float price) {
            Inventory.Add(new SnackItem {
                Name = name,
                Price = price
            });
        }

        public override void DisplayInventory() {
            Console.WriteLine("Snack selection:");
            base.DisplayInventory();
        }

        protected override VendingItem DispenseItem(int i) {
            var item = Inventory[i];
            Inventory.RemoveAt(i);
            Console.WriteLine("Here's your snack!");
            return item;
        }
    }

    class DrinkVendingMachine : VendingMachine {

        public override void AddItem(string name, float price) {
            Inventory.Add(new BeverageItem {
                Name = name,
                Price = price
            });
        }

        public override void DisplayInventory() {
            Console.WriteLine("Beverage selection:");
            base.DisplayInventory();
        }

        protected override VendingItem DispenseItem(int i) {
            var item = Inventory[i];
            Inventory.RemoveAt(i);
            Console.WriteLine("Pouring your drink now!");
            return item;
        }
    }

    class FactoryTest {

        [TestMethod]
        public static void Run() {
            VendingMachine snackMachine = new SnackVendingMachine();
            VendingMachine drinkMachine = new DrinkVendingMachine();

            snackMachine.AddItem("Chocolate bar", 1.5F);
            snackMachine.AddItem("Bag of chips", 2F);

            drinkMachine.AddItem("Sports drink", 2.25F);
            drinkMachine.AddItem("Cola", 2F);

            snackMachine.DisplayInventory();
            snackMachine.AddMoney(3F);
            snackMachine.DisplayBalance();
            VendingItem snack = snackMachine.MakeSelection(1);

            drinkMachine.DisplayInventory();
            drinkMachine.AddMoney(2F);
            snackMachine.DisplayBalance();
            drinkMachine.MakeSelection(0);
            drinkMachine.AddMoney(0.25F);
            VendingItem drink = drinkMachine.MakeSelection(0);
        }
    }
}
