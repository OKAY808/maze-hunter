using System;
using System.Numerics;

namespace Maze_Hunter
{

	class NameScreen : Screen
	{
		private Character player;

		public NameScreen(string title, OptionsMenu menu)
			: base(title, menu) 
		{
			player = Game.GetInstance().Player;
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();
			
			switch (currentOptionText)
			{
				case "Back":
					GameUI.CurrentScreen = ScreenState.NewGame;
					break;

				case "Enter Name":
					GameUI.CurrentScreen = ScreenState.EnterName;

					if (GameUI.GetMenu().GetCurrentOptionText() == "Save Name")
					{
						Console.CursorVisible = true;
						player.Name = Console.ReadLine();
						Console.CursorVisible = false;
						GameUI.CurrentScreen = ScreenState.NewGame;
					}
					break;

				case "Random Name":
					player.Name = PlayerUtils.GetRandomName(player.Gender);
					GameUI.CurrentScreen = ScreenState.NewGame;
					break;
			}
		}
	}
}
