using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Hunter
{
	class StartScreen : Screen
	{
		public StartScreen(string title, OptionsMenu menu) 
			: base(title, menu)
		{
		}

		public override void Update()
		{
			switch (Menu.GetCurrentOptionText())
			{
				case "New Game":
					GameUI.CurrentScreen = "NewGameScreen";
					break;
				case "History":
					GameUI.CurrentScreen = "HistoryScreen";
					break;
				case "Exit":
					Game.GetInstance().Exit();
					break;
			}
		}
	}

	class HistoryScreen : Screen
	{
		public HistoryScreen(string title, OptionsMenu menu)
			: base(title, menu) { }

		public override void Update()
		{
			// For now only the Back option is available.
			string currentOptionText = Menu.GetCurrentOptionText();
			if (currentOptionText == "Back")
			{
				GameUI.CurrentScreen = "StartScreen";
			}
		}
	}
}
