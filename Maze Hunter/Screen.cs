﻿using System;

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
			Console.Clear();								// Reset the console, before drawing
			Console.WriteLine(Title);						// Draw the title on top of the screen

			for (int i = 0; i < Menu.Options.Length; i++)	// Draw the menu
			{
				if (Menu.SelectedOptionIndex == i)			// The current selection is highlighted in blue
				{
					Console.BackgroundColor = ConsoleColor.DarkBlue;
				}
				Console.WriteLine(Menu.Options[i]);			
				Console.BackgroundColor = ConsoleColor.Black; // Reset to black after the current selection is drawn.
			}
		}

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

	// This class manages a specific type of screen, only used for the maze.
	// The MazeScreen has no menu, instead the maze matrix is drawn.
	class MazeScreen : Screen
	{
		private MazeRoom Maze;

		public MazeScreen(string title, OptionsMenu menu, MazeRoom maze) 
			: base (title, menu)
		{
			Maze = maze;
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
		}
	}
}