using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PacmanSimulator.Models;

namespace PacmanSimulator
{

    class Program
    {
        static void Main(string[] args)
        {
            Pacman pacman = null;

            Grid grid = new Grid(pacman);
            Console.WriteLine("Welcome to Pacman Stimulator Application.");
            Console.WriteLine("Please enter a command or enter 'STOP' to finish.");
            Console.WriteLine();

            string userCommand = Console.ReadLine();

            CommandProcessor commandProcessor = new CommandProcessor(grid, userCommand);

            Console.WriteLine();
            while (!userCommand.ToUpper().Contains("STOP"))
            {
                commandProcessor.Execute();

                userCommand = Console.ReadLine();

                commandProcessor.UserCommand = userCommand;
                Console.WriteLine();
            }
        }
    }
}
