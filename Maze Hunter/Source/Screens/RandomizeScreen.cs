using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Hunter
{
	class RandomizeScreen : Screen
	{
		public RandomizeScreen(string title, OptionsMenu menu)
			: base(title, menu) { }

		public override void Update()
		{
			string currentOptionsText = Menu.GetCurrentOptionText();
			Game game = Game.GetInstance();

			switch (currentOptionsText)
			{
				case "Back":
					GameUI.CurrentScreen = "NewGameScreen";
					break;
				case "Randomize all":
					game.Player.RandomGuild();
					game.Player.RandomGender();
					game.Player.RandomName();
					break;
			}
		}
	}
}
