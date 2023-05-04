using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Hunter
{
	class GenderScreen : Screen
	{
		public GenderScreen(string title, OptionsMenu menu) 
			: base(title, menu)
		{
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();

			Game game = Game.GetInstance();

			switch (currentOptionText)
			{
				case "Male":
					game.Player.Gender = "Male";
					GameUI.CurrentScreen = "NewGameScreen";
					break;

				case "Female":
					game.Player.Gender = "Female";
					GameUI.CurrentScreen = "NewGameScreen";
					break;

				case "Random":
					game.Player.RandomGender();
					GameUI.CurrentScreen = "NewGameScreen";
					break;

				case "Back":
					GameUI.CurrentScreen = "NewGameScreen";
					break;

			}
		}
	}
}
