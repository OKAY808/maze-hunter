using System;
using System.Collections.Generic;

namespace Maze_Hunter
{
	// The GameUI class manages the creation of different screens and switching between them.
	// All the game screens are initialized on program start and are kept in a dictionary.
	// Only one screen is active at a time.
	enum ScreenState
	{
		Start = 0,
		NewGame,
		Attributes,
		Maze,
		Name,
		EnterName,
		History,
		Randomize,
		Guild,
		Gender
	}

	static class GameUI
	{
		private static ScreenState currentScreen;				// The key to the currently active screen
		public static ScreenState CurrentScreen 
		{
			get => currentScreen;
			set 
			{
				currentScreen = value;
				gameScreens[currentScreen].OnLoad();
				Draw();
			}
		}
		private static Dictionary<ScreenState, Screen> gameScreens;
		
		private const int SCREEN_WIDTH = 50, SCREEN_HEIGHT = 25;

		public static void Init(MazeRoom maze, Character player) 
		{
			Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
			Console.SetBufferSize(SCREEN_WIDTH, SCREEN_HEIGHT);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.CursorVisible = false;          // No need for a blinking cursor.

			InitScreens(maze, player);
			CurrentScreen = ScreenState.Start;
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
			gameScreens = new Dictionary<ScreenState, Screen>();

			// To create a new screen, add a method that returns 
			// a new Screen instance and invoke that method here.
			gameScreens[ScreenState.Start] = CreateStartScreen();
			gameScreens[ScreenState.NewGame] = CreateNewGameScreen();
			gameScreens[ScreenState.History] = CreateHistoryScreen();
			gameScreens[ScreenState.Guild] = CreateGuildScreen();
			gameScreens[ScreenState.Gender] = CreateGenderScreen();
			gameScreens[ScreenState.Name] = CreateNameScreen();
			gameScreens[ScreenState.EnterName] = EnterNameScreen(); // Enter Name Screen ;)
			gameScreens[ScreenState.Attributes] = CreateAttributesScreen(player);
			gameScreens[ScreenState.Randomize] = CreateRandomizeScreen();
            gameScreens[ScreenState.Maze] = CreateMazeScreen(maze , player);
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

	}
}