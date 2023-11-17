using ConsoleApp1;
using System;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    class Program
    {
        // This program lets you create a list of pets from the menu where you can do certain actions on them eg.(cuddle, take a selfie, or brush).
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Al's Pet Emporium! Please select an option below.");
            // Instatiate the helpers class
            Helpers helpers = new Helpers();
            // Call the menu to begin
            helpers.Menu();

            return;
        }
    }
}