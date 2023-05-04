namespace Maze_Hunter
{
    // The MazeRoom class manages the movement and actions in the maze.
    // The maze is a 8x8 matrix of characters.
    // The P character represents the Player.
    // The A and T characters represent the Assasins and Thieves
    // The ' ' character represent an empty spot.
    class MazeRoom
    {
        public char[,] Grid = new char[8, 8];

        public int[] position;
        public Character npc;

        // Checks whether the Grid is empty (does not contain any NPCs)
        public bool IsMazeEmpty()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    char c = Grid[i, j];
                    if (c == 'A' || c == 'T')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public MazeRoom()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Grid[i, j] = ' ';
                }
            }

            position = new int[2] { 0, 0 };

            // place player, thief and assassin
            Grid[0, 0] = 'P';
            Grid[0, 2] = 'T';
            Grid[2, 0] = 'A';

        }

        public void MoveUp()
        {
            //npc = EncounteredNPC(Grid);

            if (position[0] - 1 < 0) return;

            position[0]--;
            int row = position[0] + 1;
            Grid[row, position[1]] = ' ';
        }

        public void MoveDown()
        {
            if (position[0] + 1 > Grid.GetLength(0) - 1) return;

            position[0]++;
            int row = position[0] - 1;
            Grid[row, position[1]] = ' ';
        }

        public void MoveLeft()
        {
            if (position[1] - 1 < 0) return;

            position[1]--;
            int column = position[1] + 1;
            Grid[position[0], column] = ' ';
        }

        public void MoveRight()
        {
            if (position[1] + 1 > Grid.GetLength(1) - 1) return;

            position[1]++;
            int column = position[1] - 1;
            Grid[position[0], column] = ' ';
        }

        public Character EncounteredNPC(char[,] grid, int[] position) // Check for encounters with NPC's
        {
            //for (int i = 0; i < Grid.GetLength(0); i++)
            //{
            //for (int j = 0; j < Grid.GetLength(1); j++)
            //{

            if (/*Grid[i, j] == 'P' && Grid[i, j] == 'T'*/ Grid[position[0], position[1]] == 'T')
            {
                Character npc = new Character(); // Example parameters
                npc.Name = "Hristo";
                npc.Guild = "Guild Of Thieves";
                npc.GuildChecker = 1;
                return npc;
            }
            else if (/*Grid[i, j] == 'P' && Grid[i, j] == 'A'*/ Grid[position[0], position[1]] == 'A')
            {
                Character npc = new Character();
                npc.Name = "Viki";
                npc.Guild = "Guild Of Assassins";
                npc.GuildChecker = 2;
                return npc;
            }
            else
            {
                return null;
            }
            //}
            //}
        }
    }
}
