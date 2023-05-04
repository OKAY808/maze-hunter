using System;

namespace Maze_Hunter
{
	class NewGameScreen : Screen
	{
		public NewGameScreen(string title, OptionsMenu menu) 
			: base(title, menu)
		{
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();
			switch (currentOptionText)
			{
				case "Start Game":
					GameUI.CurrentScreen = "MazeScreen";
					break;

				// For now the other options in the New Game screen do nothing.
				case "Back":
					GameUI.CurrentScreen = "StartScreen";
					break;

				case "Guild":
					GameUI.CurrentScreen = "GuildScreen";
					break;

				case "Gender":
					GameUI.CurrentScreen = "GenderScreen";
					break;

				case "Name":
					GameUI.CurrentScreen = "NameScreen";
					break;

				case "Attributes":
					GameUI.CurrentScreen = "AttributesScreen";
					break;

				case "Randomize":
					GameUI.CurrentScreen = "RandomizeScreen";
					break;
			}
		}
	}
}
