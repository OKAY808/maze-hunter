using System;

namespace Maze_Hunter
{
	// The central class for the game logic. 
	class Game
	{
		public Character Player;
		private Random rand;
		private bool isRunning = true;		// When set to false, the game loop stops and program exits.
		//GameUI UI;					// The UI object holds the visual elements, but no game logic.
		private MazeRoom Maze;              // The Maze object holds the game logic, but no UI elements.
		private static Game instance;

		// Creates a new instance of the game. (Should only be called once in the Main method)
		public Game()
		{
			instance = this;
			rand = new Random();
			Maze = new MazeRoom();
			Player = new Character();
			GameUI.Init(Maze, Player);
		}

		public static Game GetInstance() 
		{
			return instance; 
		}

		public void Exit() 
		{
			isRunning = false; 
		}

		// All games have a central game loop. The process goes as follows:
		// Read input => Apply action => Repeat
		public void Loop()
		{

			while (isRunning)
			{
				ConsoleKeyInfo keyInfo = Console.ReadKey();
				// .Key as in key from the keyboard. Not to be confused with dictionary keys.
				if (keyInfo.Key == ConsoleKey.Escape)		// Whenever ESC is pressed, exit the app.
				{
					isRunning = false;
				}
				else if (keyInfo.Key == ConsoleKey.Enter)	// Whenever Enter is pressed, apply action.
				{
					Update();
				}
				else
				{                                           // All other keys are passed to the
					GameUI.HandleKey(keyInfo.Key);              // currently active screen. Each screen 
				}											// has specific logic for different keys

				GameUI.Draw();								// Redraw the UI each time a key is pressed.
			}
			// When the while-loop is over, the app exits.
		}

		// Handles the user selected options in the menus.
		// The outer if-else block separates different sections for different screens.
		// Each inner if-else block handles the selected options of the corresponding screen.
		void Update()
		{
			GameUI.Update();
		}
	}
}
