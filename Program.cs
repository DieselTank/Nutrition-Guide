using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nutrition_Guide
{
    class Program
    {
        static void Main(string[] args)
        {
            IntroText();
        }

        static void IntroText()
        {
            Console.Write("--Nutrition Tracker--");
            UAnswer();
        }
        static void UAnswer()
        {
            Console.WriteLine("Do you want to search previous entries or add an new entry? (search/add): ");
            string uAnwr = Console.ReadLine();
            if (uAnwr == "search")
            {
                Search();
            }
            else if (uAnwr == "add")
            {
                Add();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, didn't catch that!");
                UAnswer();
            }
        }
        static void Search()
        {
            Console.Clear();
            //Console.WriteLine("List of all items: ");
            //Console.WriteLine();
            //Console.WriteLine("search");
            string path = @"C:\Users\dnshe\Documents\Nutrition.txt";
            StreamReader sr = new StreamReader(path);
            Console.WriteLine("What is the name of the item you want to search? ");
            string itemName = Console.ReadLine();
            Console.Clear();
            //int i = 0;
            List<string> itemNames = new List<string>();
            if (itemName == "all")
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    itemNames.Add(line);
                }
            }
            else
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    if (line.Contains(itemName))
                    {
                        //Console.WriteLine(line);
                        //i++;
                        itemNames.Add(line);
                    }
                }
            }
            Console.WriteLine(itemNames.Count + " item(s) found!");
            Console.WriteLine();
            foreach(object o in itemNames)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();
            Console.WriteLine("(Press any key to continue)");
            Console.ReadKey();
            Console.Clear();
            IntroText();
        }
        static void Add()
        {
            //Console.WriteLine("add");
            string path = @"C:\Users\dnshe\Documents\Nutrition.txt";
            StreamWriter sw;
            string answer = "y";
            int i = 0;
            while (answer == "y")
            {
                Console.Clear();
                Console.WriteLine("What is the name of the item you want to add? ");
                string itemName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("How many carbs are in " + itemName + "? ");
                string carbs = Console.ReadLine();
                Console.Clear();

                if (!File.Exists(path))
                {
                    using (sw = File.CreateText(path))
                    {
                        sw.WriteLine(itemName + " " + carbs);
                    }
                }
                else
                {
                    using (sw = File.AppendText(path))
                    {
                        sw.WriteLine(itemName + " " + carbs);
                    }
                }
                i++;
                Console.WriteLine("Would you like to add anymore items? (y/n) ");
                answer = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine(i + " item(s) added! (Press any key to continue)");
            Console.ReadKey();
            Console.Clear();
            IntroText();
        }
    }
}
