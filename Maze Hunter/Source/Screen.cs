using System;
using System.Numerics;
using System.Threading.Tasks.Dataflow;

namespace Maze_Hunter
{
    // The Screen class manages and draws a screen on the console.
    class Screen
    {
        public string Title;
        public OptionsMenu Menu;

        // Creates a new screen with a given title and menu.
        public Screen(string title, OptionsMenu menu)
        {
            Title = title;
            Menu = menu;
        }

        // Draw the screen on the console, using the WriteLine method.
        public virtual void Draw()
        {
            Console.Clear();                                // Reset the console, before drawing
            Console.WriteLine(Title);                       // Draw the title on top of the screen

            for (int i = 0; i < Menu.Options.Count; i++)    // Draw the menu
            {
                if (Menu.SelectedOptionIndex == i)          // The current selection is highlighted in blue
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                string currentOption = Menu.GetOptionAt(i);
                Console.Write("   " + currentOption + "   ");
                if (Menu.Options[currentOption] != null)
                {
                    Console.WriteLine(" - " + Menu.Options[currentOption]);
                }
                else
                {
                    Console.WriteLine();
                }
                Console.BackgroundColor = ConsoleColor.Black; // Reset to black after the current selection is drawn.
            }
        }

        public virtual void Update() { }

        public virtual void OnLoad() { }

        // Navigate up and down the menu of the screen.
        public virtual void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Menu.SelectPreviousOption();
                    break;
                case ConsoleKey.DownArrow:
                    Menu.SelectNextOption();
                    break;
            }
        }
    }

}
