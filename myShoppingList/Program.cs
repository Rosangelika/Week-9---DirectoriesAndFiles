using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Koolistuff\...\Nädal 8 -failid";
            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();
            string userDirectory = @$"\\{newDirectory}";
            Console.WriteLine("Enter file name:");
            string userFileName = Console.ReadLine();
            string userFile = @$"\\{userFileName}.txt";

            if (Directory.Exists($"{rootDirectory}\\{userDirectory}") && File.Exists($"{rootDirectory}\\{userDirectory}\\{userFile}"))
            {
                Console.WriteLine($"Directory and File exist. Add item to the wish list in the existing file.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{userDirectory}");
                File.Create($"{rootDirectory}\\{userDirectory}\\{userFile}").Close();
            }

            string fileLocation = @$"C:\Koolistuff\...\Nädal 8 -failid\\{userDirectory}";

            string[] arrayFromFile = File.ReadAllLines($"{fileLocation}{userFile}");
            List<string> myShoppingList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add a goods? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter your goods:");
                    string userGoods = Console.ReadLine();
                    myShoppingList.Add(userGoods);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Take care!");
                }
            }

            Console.Clear();

            foreach (string goods in myShoppingList)
            {
                Console.WriteLine($"Your goods: {goods}");
            }

            File.WriteAllLines($"{fileLocation}{userFile}", myShoppingList);
        }

    }
}
