using System;
using System.Numerics;

namespace Maze_Hunter
{
	class GuildScreen : Screen
	{
		private Character player;

		public GuildScreen(string title, OptionsMenu menu) 
			: base(title, menu)
		{
			player = Game.GetInstance().Player;
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();
			
			switch (currentOptionText)
			{
				case "Guild Of Thieves":
					player.Guild = Guilds.Thieves;
					break;
				case "Guild Of Assassins":
					player.Guild = Guilds.Assasins;
					break;
				case "Random":
					player.Guild = PlayerUtils.GetRandomGuild();
					break;
			}

			if (currentOptionText != null) 
			{
				GameUI.CurrentScreen = ScreenState.NewGame;
			}
		}
	}
}
