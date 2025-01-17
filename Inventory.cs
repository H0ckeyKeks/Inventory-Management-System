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
            int id = int.Parse(SafeNullInput("Please enter the ID of the item you want to add to the inventory: "));

            // Getting the name of the item that will be added
            string name = SafeNullInput("Please enter the name of the item: ");

            // Getting the quantity of the item
            int quantity = int.Parse(SafeNullInput("Please enter the quantity of the item: "));

            // Getting the price of the item
            double price = double.Parse(SafeNullInput("Please enter the price of the item: "));

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
            string answer = SafeNullInput("Do you want to add or substract items? (+/-): ");

            // Getting the ID of the item that you want to add
            int id = int.Parse(SafeNullInput("Please enter the ID of the item you want to add: "));

            Item obj = GetId(id);

            // Getting the amount that is going to be added
            int addItems = int.Parse(SafeNullInput("Please enter how many items you want to add/substract: "));

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
            int id = int.Parse(SafeNullInput("Please enter the ID of the item you want to add to the inventory: "));

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

        // Helper method to make sure that the input is never null or empty
        private static string SafeNullInput(string userInput)
        {
            string input;
            do
            {
                Console.Write(userInput);
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input can never be empty. Please try again.");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }
    }
}
