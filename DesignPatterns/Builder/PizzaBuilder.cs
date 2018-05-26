using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Builder {

    enum Crust {
        Regular, Thin
    }

    enum Sauce {
        Marinara, Alfredo, BBQ
    }

    enum Topping {
        Pepperoni, Mushrooms, GreenPeppers, Olives
    }

    class Pizza {
        public Crust Crust { get; set; }

        public Sauce Sauce { get; set; }

        public List<Topping> Toppings 
            = new List<Topping>();
    }

    class PizzaBuilder {
        private Pizza pizza = new Pizza();

        public PizzaBuilder SetCrust(Crust c) {
            pizza.Crust = c;
            return this;
        }

        public PizzaBuilder SetSauce(Sauce s) {
            pizza.Sauce = s;
            return this;
        }

        public PizzaBuilder AddTopping(Topping t) {
            pizza.Toppings.Add(t);
            return this;
        }

        public Pizza MakePizza() {
            return pizza;
        }
    }

    class BuilderTest {

        [TestMethod]
        public static void Run() {
            var pizzaBuilder = new PizzaBuilder();
            var pizza = pizzaBuilder
                .SetCrust(Crust.Regular)
                .SetSauce(Sauce.BBQ)
                .AddTopping(Topping.GreenPeppers)
                .AddTopping(Topping.Olives)
                .MakePizza();

            Console.WriteLine("Pizza ingredients:");
            Console.WriteLine("Crust: " + pizza.Crust);
            Console.WriteLine("Sauce: " + pizza.Sauce);
            Console.Write("Toppings: ");
            foreach (Topping t in pizza.Toppings) {
                Console.Write(t + " ");
            }
            Console.WriteLine();
        }
    }

}
