using System;

namespace NameParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new [] {"First Option","Second Option", "Third Option"};
            
            Console.WriteLine("Please enter your name: ");
            var parser = new Parser();
            var name = Console.ReadLine();

            Console.WriteLine($"Hi, {name}!");

            var user = parser.ParseName(name);

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Your first name is {user.FirstName}!");

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your last name is {user.LastName}!");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press enter to clear the screen");
            Console.ReadLine();
            Console.Clear();

            foreach (var item in menu)
            {
                Console.WriteLine($"{Array.IndexOf(menu,item)+1}.) {item}");
            }

            var choice = Console.ReadKey();

            Console.Clear();
            Console.WriteLine($"You chose {menu[int.Parse(choice.KeyChar.ToString())-1]}");

            // Console.ResetColor();

        }
    }
}
