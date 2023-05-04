using System;
using System.Collections.Generic;

namespace Maze_Hunter
{
	// The GameUI class manages the creation of different screens and switching between them.
	// All the game screens are initialized on program start and are kept in a dictionary.
	// Only one screen is active at a time.
	static class GameUI
	{
		private static string currentScreen;				// The key to the currently active screen
		public static string CurrentScreen 
		{
			get => currentScreen;
			set 
			{
				currentScreen = value;
				UpdateMenuParams();
				Draw();
			}
		}
		private static Dictionary<string, Screen> gameScreens;
		public static Character Player;

		private const int SCREEN_WIDTH = 50, SCREEN_HEIGHT = 25;

		public static void Init(MazeRoom maze, Character player) 
		{
			Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
			Console.SetBufferSize(SCREEN_WIDTH, SCREEN_HEIGHT);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.CursorVisible = false;          // No need for a blinking cursor.

			Player = player;
			InitScreens(maze, player);
			CurrentScreen = "StartScreen";
		}

		public static void Draw()							// Draws the currently active screen.
		{
			gameScreens[currentScreen].Draw();
		}

		public static OptionsMenu GetMenu()				// Returns the menu of the current screen.
		{ 
			return gameScreens[currentScreen].Menu;
		}

		public static void HandleKey(ConsoleKey key)		// When a key is pressed, this method forwards
		{											// the command to the current screen.
			gameScreens[currentScreen].HandleKey(key);
		}

		public static void Update() 
		{
			gameScreens[currentScreen].Update();
		}

		private static void InitScreens(MazeRoom maze, Character player)     // Creates a dict with all the screens in the game.
		{
			gameScreens = new Dictionary<string, Screen>();

			// To create a new screen, add a method that returns 
			// a new Screen instance and invoke that method here.
			gameScreens["StartScreen"] = CreateStartScreen();
			gameScreens["NewGameScreen"] = CreateNewGameScreen();
			gameScreens["HistoryScreen"] = CreateHistoryScreen();
			gameScreens["GuildScreen"] = CreateGuildScreen();
			gameScreens["GenderScreen"] = CreateGenderScreen();
			gameScreens["NameScreen"] = CreateNameScreen();
			gameScreens["NameEnter"] = EnterNameScreen(); // Enter Name Screen ;)
			gameScreens["AttributesScreen"] = CreateAttributesScreen(player);
			gameScreens["RandomizeScreen"] = CreateRandomizeScreen();
            gameScreens["MazeScreen"] = CreateMazeScreen(maze , player);
		}

		private static Screen CreateStartScreen()
		{
			string title =	"==================================================\n" +
							"=====              Hello Warrior!            =====\n" +
							"==================================================\n";

			string[] options = new string[] 
			{
				"New Game",
				"History",
				"Exit"
			};

			OptionsMenu menu = new OptionsMenu(options);

			return new StartScreen(title, menu);
		}

		private static Screen CreateNewGameScreen()
		{
			string title =	"==================================================\n" +
							"=====                New Game!               =====\n" +
							"==================================================\n";

			//string playerName = Game.Player.Name;
			string[] options = new string[] 
			{
				"Guild",
				"Gender",
				"Name",
				"Attributes",
				"Randomize",
				"Start Game",
				"Back",
			};

			OptionsMenu menu = new OptionsMenu(options);

			return new NewGameScreen(title, menu);
		}

		private static Screen CreateHistoryScreen()
		{
			string title =  "==================================================\n" +
							"=====                 History!               =====\n" +
							"==================================================\n";

			string[] options = new string[] 
			{
				// TODO: add more options here when implementing the History feature.
				"Back"
			};

			OptionsMenu menu = new OptionsMenu(options);

			return new HistoryScreen(title, menu);
		}

        public static Screen CreateGuildScreen()
        {
            string title = "==================================================\n" +
                           "=====                 Guild!                 =====\n" +
                           "==================================================\n";

            string[] options = new string[] 
			{
				// TODO: add more options here when implementing the Guild feature.
				"Guild Of Thieves",
                "Guild Of Assassins",
				"Random", 
				"Back"
            };

            OptionsMenu menu = new OptionsMenu(options);

            return new GuildScreen(title, menu);
        }


        private static Screen CreateGenderScreen()
        {
            string title = "==================================================\n" +
                            "=====                 Gender!                =====\n" +
                            "==================================================\n";

            string[] options = new string[] 
			{
                "Male",
                "Female",
                "Random",
                "Back"
            };

            OptionsMenu menu = new OptionsMenu(options);

            return new GenderScreen(title, menu);
        }

        private static Screen CreateNameScreen()
        {
            string title = "==================================================\n" +
                           "=====                 Name!                  =====\n" +
                           "==================================================\n";

			string[] options = new string[] 
			{
				// TODO: add more options here when implementing the Name feature.
				"Enter Name",
				"Random Name",
                "Back"
            };

            OptionsMenu menu = new OptionsMenu(options);

            return new NameScreen(title, menu);
        }

		private static Screen EnterNameScreen()
		{
            string title = "==================================================\n" +
                            "=====           Enter your Name!             =====\n" +
                            "==================================================\n";

            string[] options = new string[] 
			{
				// TODO: add more options here when implementing the Name feature.
                "Save Name"
            };

            OptionsMenu menu = new OptionsMenu(options);

            return new Screen(title, menu);
        }

        private static Screen CreateAttributesScreen(Character player)
        {
            string title = "==================================================\n" +
                           "=====                 Attributes!            =====\n" +
                           "==================================================\n";

            string[] options = new string[] 
			{
				// TODO: add more options here when implementing the Attributes feature.
				"Points Left:",
				"Health:",
				"Attack:",
				"Randomize",
				"Done",
				"Back"
            };

            OptionsMenu menu = new OptionsMenu(options);

            return new AttributesScreen(title, menu, player);
		}
        
        private static Screen CreateRandomizeScreen()
        {
            string title =  "==================================================\n" +
                            "=====                 Randomize!             =====\n" +
                            "==================================================\n";

            string[] options = new string[] 
			{
				"Randomize all",
				"Back"
            };

            OptionsMenu menu = new OptionsMenu(options);

            return new RandomizeScreen(title, menu);
        }


        private static Screen CreateMazeScreen(MazeRoom maze,Character player)
		{
			string title =	"==================================================\n" +
							"=====                  MAZE!                 =====\n" +
							"==================================================\n";

			// The Maze screen has no menu in it.
			string[] options = new string[] {};

			OptionsMenu menu = new OptionsMenu(options);

			return new MazeScreen(title, menu, maze ,player);
		}

		private static void UpdateMenuParams()
		{
			if (currentScreen == "NewGameScreen")
			{
				GetMenu().Options["Name"] = Player.Name;
				GetMenu().Options["Gender"] = Player.Gender;
				GetMenu().Options["Guild"] = Player.Guild;

				if (Player.Attack != 0 || Player.Health != 0)
				{
					GetMenu().Options["Attributes"] = $"H:{Player.Health}, A:{Player.Attack}";
				}
			}
		}
	}
}