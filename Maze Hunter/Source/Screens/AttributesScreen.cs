using System;

namespace Maze_Hunter
{
	class AttributesScreen : Screen
	{
		private Character Player;

		public AttributesScreen(string title, OptionsMenu menu, Character player)
			: base(title, menu)
		{
			Player = player;
		}

		public override void HandleKey(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.UpArrow:
					Menu.SelectPreviousOption();
					break;
				case ConsoleKey.DownArrow:
					Menu.SelectNextOption();
					break;
				case ConsoleKey.RightArrow:
					if (Player.IncreaseAttribute == "Health")
					{
						Player.IncreaseHealth();
					}
					else if (Player.IncreaseAttribute == "Attack")
					{
						Player.IncreaseAttack();
					}
					break;
				case ConsoleKey.LeftArrow:
					if (Player.DecreaseAttrtibute == "Health")
					{
						Player.DecreaseHealth();
					}
					else if (Player.DecreaseAttrtibute == "Attack")
					{
						Player.DecreaseAttack();
					}
					break;
			}
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();

			switch (currentOptionText)
			{
				case "Health:":
					Player.IncreaseAttribute = "Health";
					Player.DecreaseAttrtibute = "Health";
					break;
				case "Attack:":
					Player.IncreaseAttribute = "Attack";
					Player.DecreaseAttrtibute = "Attack";
					break;
				case "Back":
					GameUI.CurrentScreen = "NewGameScreen";
					break;
			}
		}
	}
}
