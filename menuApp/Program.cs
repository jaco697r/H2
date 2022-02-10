using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace menuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "0";
            Menu menu = new Menu();


            while (Int32.Parse(key) != 4)
            {
                Console.Clear();
                menu.showMenu(menu.screens, menu.name, menu.description);
                key = menu.takeInput();
                menu.showScreen(key, menu.screens);

            }
        }
    }
    
    class Menu
    {
        public string name;
        public string description;
        public List<string> menuNames = new List<string>();
        public List<string> descriptions = new List<string>();
        public List<int> ids = new List<int>();
        public List<Screen> screens = new List<Screen>();

        public Menu(Boolean firstPage = true)
            {
            
            if (firstPage == true)
            {
                name = "Main Menu";
                description = "Choose a screen";
                ids.Add(1);
                ids.Add(2);
                ids.Add(3);
                menuNames.Add("Se en kat");
                menuNames.Add("Tilføj en skærm");
                menuNames.Add("Slet en skærm");
                descriptions.Add("SE EN KAT!");
                descriptions.Add("Dette er anden skærm");
                descriptions.Add("Dette er tredje skærm");
            }
            ids.Add(4);
            menuNames.Add("Afslut");
            descriptions.Add("Afslut");
            for (int i = 0; i<ids.Count; i++)
            {
            screens.Add(new Screen(ids.ElementAt(i), menuNames.ElementAt(i), descriptions.ElementAt(i)));
            }
        }    
        public void showMenu(List<Screen> screens, string menu, string description)
        {
            Console.WriteLine(menu);
            Console.WriteLine("");
            Console.WriteLine(description);
            for (int i = 0; i < screens.Count; i++)
            {
                Console.WriteLine($"{screens[i].id.ToString()} {screens[i].name}");
            }
        }

        public string takeInput()
        {
            string key = Console.ReadLine();
            return key;
        }

        public void showScreen(string key, List<Screen> screens)
        {
            if (Int32.Parse(key) == 1)
            {
                Console.Clear();
                screens[1].printASCI_img("cat.txt", 0);
            }
            else if (Int32.Parse(key) == 2)
            {
                Console.Clear();
                addScreen();
            }
            else if (Int32.Parse(key) == 3)
            {
                Console.Clear();
                deleteScreen(screens);
            }
            else
                for (int i = 0; i < screens.Count; i++)
                {
                    if (screens[i].id == Int32.Parse(key))
                    {
                        showCustomScreen(Int32.Parse(key), screens);
                    }
                }
            
        }

        public void showCustomScreen(int key, List<Screen> screens)
        {
            Console.Clear();
            Console.WriteLine(screens[key-1].name);
            Console.WriteLine(" ");
            Console.WriteLine(screens[key-1].description);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }

        public void addScreen()
        {
            Console.WriteLine("ADD SCREEN");
            Console.WriteLine("");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            screens.Add(new Screen(screens.Count+1, name, description));
        }

        public void deleteScreen(List<Screen> screens)
        {
            Console.WriteLine("Enter ID of menu that you want to delete");
            int key = Int32.Parse(Console.ReadLine());
            screens.RemoveAt(key-1);
        }
    }

    class Screen
    {
        public int id;
        public string name;
        public string description;

        public Screen(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public void printASCI_img(string file, int timeout)
        // prints ASCI text file to console
        // pause between every char given in milliseconds
        {
            try
            {
                byte[] img1;
                img1 = File.ReadAllBytes(file);

                foreach (byte i in img1)
                {
                    Console.Write(Convert.ToChar(i));
                    System.Threading.Thread.Sleep(timeout);
                }
                Console.WriteLine(" ");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
