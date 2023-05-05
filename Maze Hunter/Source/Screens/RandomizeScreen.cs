using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Maze_Hunter
{
	class RandomizeScreen : Screen
	{
		private Character player;
		private Random rand = new Random();

		public RandomizeScreen(string title, OptionsMenu menu)
			: base(title, menu) 
		{
			player = Game.GetInstance().Player;
			rand = new Random();
		}

		public override void Update()
		{
			string currentOptionsText = Menu.GetCurrentOptionText();
			
			switch (currentOptionsText)
			{
				case "Back":
					GameUI.CurrentScreen = ScreenState.NewGame;
					break;
				case "Randomize all":
					player.Guild = PlayerUtils.GetRandomGuild();
					player.Gender = PlayerUtils.GetRandomGender();
					player.Name = PlayerUtils.GetRandomName(player.Gender);
					break;
			}
		}
	}
}
