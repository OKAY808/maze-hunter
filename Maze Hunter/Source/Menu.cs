using System.Collections.Generic;
using System.Linq;

namespace Maze_Hunter
{
	// The OptionsMenu class manages navigation with the menus.
	// The menus are array of selectable options, where each option is just a string.
	class OptionsMenu
	{
		// The keys in the dict are the names of the menu buttons.
		// The values are optional decorations, like player name, guild, etc...
		public Dictionary<string, string> Options;
		public int SelectedOptionIndex;

		public OptionsMenu(string[] options)
		{
			Options = new Dictionary<string, string>();
			foreach (string option in options)
			{
				Options.Add(option.Trim(), null);
			}
			
			SelectedOptionIndex = 0;
		}

		public void SelectNextOption()
		{
			// The ... % Options.Length; ... part is used to rotate after the last option.
			SelectedOptionIndex = (SelectedOptionIndex + 1) % Options.Count;
		}

		public void SelectPreviousOption()
		{
			// When the cursor is on the first option, the previous should rotate to the last.
			if (SelectedOptionIndex == 0)
			{
				SelectedOptionIndex = Options.Count;
			}
			SelectedOptionIndex = SelectedOptionIndex - 1;
		}

		public string GetCurrentOptionText()
		{
			return GetOptionAt(SelectedOptionIndex);
		}

		public string GetOptionAt(int i)
		{
			string currentOption = Options.ElementAt(i).Key;
			return currentOption.Trim();
		}
	}
}
