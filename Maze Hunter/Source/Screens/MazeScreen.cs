using System;

namespace Maze_Hunter
{
	// This class manages a specific type of screen, only used for the maze.
	// The MazeScreen has no menu, instead the maze matrix is drawn.
	class MazeScreen : Screen
	{
		private MazeRoom Maze;
		private Character Player;
		private string Message;
		public MazeScreen(string title, OptionsMenu menu, MazeRoom maze, Character player)
			: base(title, menu)
		{
			Maze = maze;
			Player = player;
			Message = "";
		}

		public override void Draw()
		{
			// First draw everything that the regular screens have.
			base.Draw();

			// After that draw the maze.
			for (int i = 0; i < Maze.Grid.GetLength(0); i++)
			{
				Console.WriteLine("*-------------------------------*");
				for (int j = 0; j < Maze.Grid.GetLength(1); j++)
				{
					Console.Write($"| {Maze.Grid[i, j]} ");
				}
				Console.WriteLine("|");
			}
			Console.WriteLine("*-------------------------------*");

			Console.WriteLine(Message);

		}


		// For this screen, the arrow keys move the player, instead of menu selection.
		public override void HandleKey(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.UpArrow:
					Maze.MoveUp();
					break;
				case ConsoleKey.DownArrow:
					Maze.MoveDown();
					break;
				case ConsoleKey.LeftArrow:
					Maze.MoveLeft();
					break;
				case ConsoleKey.RightArrow:
					Maze.MoveRight();
					break;
			}

			Character character = Maze.EncounteredNPC(Maze.Grid, Maze.position);

			if (character != null)
			{
				Message = Player.Encounter(character);
			}
			else
			{
				Message = "";
			}

			Maze.Grid[Maze.position[0], Maze.position[1]] = 'P';
		}
	}
}
