using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    internal class Inventory
    {
        // Creating a list to store the items in
        private static List<Item> inventory = new List<Item>();

        
        // Adding a new item to the inventory
        public static void AddItems()
        {
            // Getting the ID of the item that will be added
            Console.WriteLine("Please enter the ID of the item you want to add to the inventory: ");
            int id = int.Parse(Console.ReadLine());

            // Getting the name of the item that will be added
            Console.WriteLine("Please enter the name of the item: ");
            string name = Console.ReadLine();

            // Getting the quantity of the item
            Console.WriteLine("Please enter the quantity of the item: ");
            int quantity = int.Parse(Console.ReadLine());

            // Getting the price of the item
            Console.WriteLine("Please enter the price of the item: ");
            double price = double.Parse(Console.ReadLine());

            // Storing user input in a list
            inventory.Add(new Item(id, name, quantity, price));
        }

        // Getting the ID of the item to work with it
        public static Item GetId(int id) 
        {
            Item objReturn = null;

            foreach (Item item in inventory) 
            {
                if (item.Id == id)
                {
                    objReturn = item;
                }
            }

            return objReturn;
        }

        // Updating the quantity
        public static void UpdateQuantity()
        {
            Console.WriteLine("Do you want to add or substract items? (+/-):");
            string answer = Console.ReadLine();

            // Getting the ID of the item that you want to add
            Console.WriteLine("Please enter the ID of the item you want to add: ");
            int id = int.Parse(Console.ReadLine());

            Item obj = GetId(id);

            // Getting the amount that is going to be added
            Console.WriteLine("Please enter how many items you want to add/substract: ");
            int addItems = Int32.Parse(Console.ReadLine());

            // Showing current quantity
            Console.WriteLine($"old quantity: {obj.Quantity}");

            // Getting the current quantity of the item
            if (obj != null)
            {
                if (answer == "+")
                {
                    // Calculating the new quantity
                    obj.Quantity += addItems;
                }
                else if (answer == "-")
                {
                    obj.Quantity -= addItems;
                }

                Console.WriteLine($"\nNew Quantity: {obj.Quantity}\n");
            }

        }

        public static void FindItem()
        {
            // Getting the ID of the item that you want to add          
            Console.WriteLine("Please enter the ID of the item you want to find: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nID       Name       Quantity       Price\n");

            foreach (Item item in inventory)
            {
                if (item.Id == id)
                {
                    Console.WriteLine($"{item.Id}       {item.Name}       {item.Quantity}               {item.Price}");
                }
            }
        }


        public static void DisplayItems()
        {
            Console.WriteLine("\nID       Name       Quantity       Price\n");

            foreach (Item item in inventory)
            {
                Console.WriteLine($"{item.Id}       {item.Name}       {item.Quantity}               {item.Price}");
            }
        }

        public static void CalculateTotal()
        {
            double total = 0;

            foreach (Item item in inventory)
            {
                total += item.Price * item.Quantity;
            }

            Console.WriteLine($"\nThe total of all items in the inventory is {total}\n");
        }
    }
}
