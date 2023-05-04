using System;

namespace Maze_Hunter
{
    internal class Character
    {
        public string Name;
        public string Guild;
        public string Gender;
        public int Health;
        public int Attack;
        public int MaxStats;
        public string IncreaseAttribute;
        public string DecreaseAttrtibute;
        public int GuildChecker;
        public int HealthBonus = 0;
        public int AttackBonus = 0;


        public Character()
        {
            MaxStats = 10;
            Health = 0;
            Attack = 0;
            IncreaseAttribute = "";
            DecreaseAttrtibute = "";
        }

        public void IncreaseHealth()
        {
            if (Health < 10 && MaxStats > 0)
            {
                Health++;
                MaxStats--;
            }
        }

        public void DecreaseHealth()
        {
            if (Health > 0 && MaxStats < 10)
            {
                Health--;
                MaxStats++;
            }
        }

        public void IncreaseAttack()
        {
            if (Attack < 10 && MaxStats > 0)
            {
                Attack++;
                MaxStats--;
            }
        }

        public void DecreaseAttack()
        {
            if (Attack > 0 && MaxStats < 10)
            {
                Attack--;
                MaxStats++;
            }
        }

        public void Guilds()
        {
            if (GuildChecker == 1)
            {
                if (HealthBonus <= 0)
                {
                    Guild = "Guild Of Thieves";
                    if (AttackBonus > 0)
                    {
                        Attack -= 2;
                    }
                    HealthBonus = 2;
                    AttackBonus = 0;

                    Attack += AttackBonus;
                    Health += HealthBonus;
                }
            }
            else if (GuildChecker == 2)
            {
                if (AttackBonus <= 0)
                {
                    Guild = "Guild Of Assassins";
                    if (HealthBonus > 0)
                    {
                        Health -= 2;
                    }
                    HealthBonus = 0;
                    AttackBonus = 2;

                    Attack += AttackBonus;
                    Health += HealthBonus;
                }
            }
        }

        public void RandomName()
        {
            Random rand = new Random();
            NameBase namebase = new NameBase();
            int randomName;
            if (Gender == "Male")
            {
                randomName = rand.Next(namebase.maleNames.Length);
                Name = namebase.maleNames[randomName];
            }
            else if (Gender == "Female")
            {
                randomName = rand.Next(namebase.femaleNames.Length);
                Name = namebase.femaleNames[randomName]; ;
            }
            else
            {
            }
        }

        public void RandomGender()
        {
            Random rand = new Random();
            int randomGender = rand.Next(1, 3);
            if (randomGender == 1)
            {
                Gender = "Male";
            }
            else if (randomGender == 2)
            {
                Gender = "Female";
            }
        }

        public void RandomGuild()
        {
            Random rand = new Random();
            GuildChecker = rand.Next(1, 3);
            Guilds();
        }

        public string Encounter(Character npc)
        {
            if (GuildChecker == npc.GuildChecker)
            {
                MeetFriend();
                return $"Meeting with {npc.Name}";
            }
            else
            {
                Battle(npc);
                return $"Battle with {npc.Name}";
            }
        }

        public void MeetFriend()
        {
            if (Health < MaxStats)
            {
                Health += 4;

                if (Health > MaxStats)
                {
                    Health = MaxStats;
                }
            }
            else
            {
                Health++;
            }
        }

        public string Battle(Character npc)
        {
            int totalAttack = Attack - npc.Attack;
            if(totalAttack > 0)
            {
                npc.Health -= totalAttack;
                Health--;
            }
            else if (totalAttack < 0)
            {
                totalAttack*=-1;
                Health -= totalAttack;
                npc.Health--;
            }
            else
            {
                Health--;
                npc.Health--;
            }

            if (Health<=0)
            {
                return "Lose";
            }
            else if(npc.Health<=0)
            {
                return "Win";
            }
            else
            {
                return "Draw";
            }
        }

    }
}
