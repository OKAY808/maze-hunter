using System;

namespace Maze_Hunter
{
	static class PlayerUtils
	{
		private static Random rand = new Random();

		public static Guilds GetRandomGuild() 
		{
			return (Guilds)rand.Next(0, 2);
		}

		public static Genders GetRandomGender() 
		{
			return (Genders)rand.Next(0, 2);
		}

		public static string GetRandomName(Genders gender) 
		{
			int randomNameInd;

			switch (gender)
			{
				case Genders.Male:
					randomNameInd = rand.Next(NameBase.MaleNames.Length);
					return NameBase.MaleNames[randomNameInd];
				case Genders.Female:
					randomNameInd = rand.Next(NameBase.MaleNames.Length);
					return NameBase.FemaleNames[randomNameInd];
			}

			return "";
		}
	}
}
