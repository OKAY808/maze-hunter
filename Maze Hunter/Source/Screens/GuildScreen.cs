using System;
using System.Numerics;

namespace Maze_Hunter
{
	class GuildScreen : Screen
	{
		public GuildScreen(string title, OptionsMenu menu) : base(title, menu)
		{
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();
			Game game = Game.GetInstance();

			switch (currentOptionText)
			{
				case "Guild Of Thieves":
					game.Player.GuildChecker = 1;
					game.Player.Guilds();
					GameUI.CurrentScreen = "NewGameScreen";
					break;
				case "Guild Of Assassins":
					game.Player.GuildChecker = 2;
					game.Player.Guilds();
					GameUI.CurrentScreen = "NewGameScreen";
					break;
				case "Random":
					game.Player.RandomGuild();
					GameUI.CurrentScreen = "NewGameScreen";
					break;
				case "Back":
					GameUI.CurrentScreen = "NewGameScreen";
					break;
			}
		}
	}
}
