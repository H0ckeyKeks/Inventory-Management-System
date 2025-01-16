using System.Transactions;

namespace Inventory_Management_System
{
    internal class Program
    {
               
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Inventory Management System!\n");
            int answer = 0;

            while (answer != 6)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1 - Add items to the inventory");
                Console.WriteLine("2 - Update item quantities (increase/decrease)");
                Console.WriteLine("3 - Display items");
                Console.WriteLine("4 - Find an item by its ID");
                Console.WriteLine("5 - Calculate the total value of all items in the inventory");
                Console.WriteLine("6 - Exit\n");
                Console.ResetColor();

                Console.WriteLine("Please enter a number of what you want to do: ");

                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    switch (answer)
                    {
                        case 1:
                            Inventory.AddItems();
                            break;

                        case 2:
                            Inventory.UpdateQuantity();
                            break;

                        case 3:
                            Inventory.DisplayItems();
                            break;

                        case 4:
                            Inventory.FindItem();
                            break;

                        case 5:
                            Inventory.CalculateTotal();
                            break;

                        case 6:
                            break;
                    }
                }
            }
        }
    }
}
