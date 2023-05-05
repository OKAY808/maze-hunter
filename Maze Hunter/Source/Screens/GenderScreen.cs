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
		private Character player;

		public GenderScreen(string title, OptionsMenu menu) 
			: base(title, menu)
		{
			player = Game.GetInstance().Player;
		}

		public override void Update()
		{
			string currentOptionText = Menu.GetCurrentOptionText();

			switch (currentOptionText)
			{
				case "Male":
					player.Gender = Genders.Male;
					break;

				case "Female":
					player.Gender = Genders.Female;
					break;

				case "Random":
					player.Gender = PlayerUtils.GetRandomGender();
					break;

			}

			if (currentOptionText != null)
				GameUI.CurrentScreen = ScreenState.NewGame;
		}
	}
}
