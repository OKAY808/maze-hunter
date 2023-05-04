using System;
using System.Numerics;

namespace Maze_Hunter
{

	class NameScreen : Screen
	{
		public NameScreen(string title, OptionsMenu menu)
			: base(title, menu) { }

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();
			Game game = Game.GetInstance();

			switch (currentOptionText)
			{
				case "Back":
					GameUI.CurrentScreen = "NewGameScreen";
					break;

				case "Enter Name":
					GameUI.CurrentScreen = "NameEnter";

					if (GameUI.GetMenu().GetCurrentOptionText() == "Save Name")
					{
						Console.CursorVisible = true;
						game.Player.Name = Console.ReadLine();
						Console.CursorVisible = false;
						GameUI.CurrentScreen = "NewGameScreen";
					}
					break;

				case "Random Name":
					game.Player.RandomName();
					GameUI.CurrentScreen = "NewGameScreen";
					break;
			}
		}
	}
}
