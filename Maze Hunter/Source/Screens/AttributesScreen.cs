using System;

namespace Maze_Hunter
{
	class AttributesScreen : Screen
	{
		private string selectedAttribute;
		private Character player;

		public AttributesScreen(string title, OptionsMenu menu, Character player)
			: base(title, menu)
		{
			this.player = player;
		}

		public override void HandleKey(ConsoleKey key)
		{
			int attributeModifier = 0;
			switch (key)
			{
				case ConsoleKey.UpArrow:
					Menu.SelectPreviousOption();
					break;
				case ConsoleKey.DownArrow:
					Menu.SelectNextOption();
					break;
				case ConsoleKey.RightArrow:
					attributeModifier = 1;
					break;
				case ConsoleKey.LeftArrow:
					attributeModifier = -1;
					break;
			}

			if (selectedAttribute == "Health")
			{
				player.Health += attributeModifier;
			}
			else if (selectedAttribute == "Attack") 
			{
				player.Attack += attributeModifier;
			}

			if (attributeModifier != 0)
			{
				UpdateAttributes();
			}
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();

			switch (currentOptionText)
			{
				case "Health:":
				case "Attack:":
					selectedAttribute = currentOptionText.Substring(0, currentOptionText.Length - 1);
					break;
				case "Back":
					GameUI.CurrentScreen = ScreenState.NewGame;
					break;
			}
		}

		public override void OnLoad()
		{
			UpdateAttributes();
		}

		private void UpdateAttributes() 
		{
			Menu.Options["Points Left:"] = player.MaxStats.ToString();
			Menu.Options["Health:"] = player.Health.ToString();
			Menu.Options["Attack:"] = player.Attack.ToString();
		}
	}
}
