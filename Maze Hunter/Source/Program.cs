using System;

namespace Maze_Hunter
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Game game = new Game();		// Create an instance of the game
			game.Loop();				// Start the game loop.
		}
	}
}
