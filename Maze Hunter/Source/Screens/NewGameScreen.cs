using System;
using System.Numerics;

namespace Maze_Hunter
{
	class NewGameScreen : Screen
	{
		private Character player;

		public NewGameScreen(string title, OptionsMenu menu) 
			: base(title, menu)
		{
			player = Game.GetInstance().Player;
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();
			switch (currentOptionText)
			{
				case "Start Game":
					GameUI.CurrentScreen = ScreenState.Maze;
					break;

				// For now the other options in the New Game screen do nothing.
				case "Back":
					GameUI.CurrentScreen = ScreenState.Start;
					break;

				case "Guild":
					GameUI.CurrentScreen = ScreenState.Guild;
					break;

				case "Gender":
					GameUI.CurrentScreen = ScreenState.Gender;
					break;

				case "Name":
					GameUI.CurrentScreen = ScreenState.Name;
					break;

				case "Attributes":
					GameUI.CurrentScreen = ScreenState.Attributes;
					break;

				case "Randomize":
					GameUI.CurrentScreen = ScreenState.Randomize;
					break;
			}
		}

		public override void OnLoad()
		{
			Menu.Options["Name"] = player.Name;
			Menu.Options["Gender"] = player.Gender == Genders.None ? null : player.Gender.ToString();
			Menu.Options["Guild"] = player.Guild == Guilds.None ? null : $"Guild of {player.Guild}";

			if (player.Attack != 0 || player.Health != 0)
			{
				Menu.Options["Attributes"] = $"H:{player.Health}, A:{player.Attack}";
			}
		}
	}
}
