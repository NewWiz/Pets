using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Helpers
    {
        // Main list of pets
        List<Pet> pets = new List<Pet>();

        // Main Menu
        public void Menu()
        {
            int choice = GetOption("Select '1' to enter a pet, select '2' to see a list of pets, select '3' to select a pet, '4' to exit.");
            if (choice == 1)
            {
                RunEnterAPet();
                Menu();
            }
            else if (choice == 2)
            {
                // Iterates through pets and displays them
                foreach (Pet p in pets)
                {
                    p.Display();
                }
                Menu();
            }
            else if (choice == 3)
            {
                // SelectPet selects a pet and enters into the submenu.
                SelectPet();
            }
            else if (choice == 4)
            {
                Environment.Exit(1);
            }
            else
            {
                Error();
            }
        }

        // This is the pet submenu where you can choose to cuddle, take a selfie, or brush your pet.
        public void SubMenu(Pet p)
        {
            int choice = GetOption("Select '1' to cuddle with your pet, select '2' to take a selfie with your pet, select '3' to brush your pet, select '4' to return to the main menu.");
            if (choice == 1)
            {
                //calls the override from the particular pet type
                p.Cuddle();
                SubMenu(p);
            }
            else if (choice == 2)
            {
                //calls the override from the particular pet type
                p.Selfie();
                SubMenu(p);
            }
            else if (choice == 3)
            {
                //calls the override from the particular pet type
                p.Brush();
                SubMenu(p);
            }
            else if (choice == 4)
            {
                // Back to the main menu
                Menu();
            }
            else
            {
                Error();
                // Calls back SubMenu if invalid entry
                SubMenu(p);
            }
        }

        // Just a prompt to get menu options (int)
        public static int GetOption(string prompt)
        {
            Console.Write("{0}> ", prompt);
            return int.Parse(Console.ReadLine());
        }

        // Another prompt to get string entries
        public static string GetString(string prompt)
        {
            Console.Write("{0}> ", prompt);
            return Console.ReadLine();
        }

        public void RunEnterAPet()
        {
            int choice = GetOption("Enter Type: '1' for dog, '2' for cat, '3' for bird, or '4' to return to the main menu.");

            // Instantiates the pet by type, gets data about pet, then adds it to the <Pet> pets list. All 3 types of animal inherit from the Pet class so they can be in a <Pet> list.
            if (choice == 1)
            {
                Dog dog = new Dog();
                dog.Name = GetString("Enter name");
                dog.Breed = GetString("Breed?");
                pets.Add(dog);
            }
            else if (choice == 2)
            {
                Cat cat = new Cat();
                cat.Name = GetString("Enter name");
                cat.Breed = GetString("Breed?");
                pets.Add(cat);
            }
            else if (choice == 3)
            {
                Bird bird = new Bird();
                bird.Name = GetString("Enter name");
                bird.Breed = GetString("Breed?");
                pets.Add(bird);
            }
            else if (choice == 4)
            {
                Menu();
            }
            else
            {
                Error();
                // If invalid entry RunEnterAPet() again.
                RunEnterAPet();
            }
            return;
        }

        // Reads pet's name from input and sends it as an argument to submenu.
        public void SelectPet()
        {
            string name = GetString("Please enter the pet's name from the list or select '1' to return to the main menu.");
            if (name is "1")
            {
                Menu();
            }
            else
            {
                bool flag = false;
                foreach (Pet p in pets)
                {
                    if (name == p.Name)
                    {
                        flag = true;
                        SubMenu(p);
                    }
                }
                // if flag is false then the name was not found.
                if (flag == false)
                {
                    Error();
                    // Return to main menu.
                    Menu();

                }

            }
        }

        // Error handling
        public static void Error()
        {
            Console.WriteLine("Please select a valid entry ^-^");
        }
    }
}
