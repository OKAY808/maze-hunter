using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Maze_Hunter
{
    enum Guilds 
    {
        None = 0,
        Thieves,
        Assasins
    }

    enum Genders 
    {
        None = 0,
        Male,
        Female
    }

    internal class Character
    {
        public string Name;
        public Genders Gender;
        private int health;
        public int Health 
        {
            get 
            {
                return health;
            }
            set 
            {
                int modifier = value - health;
                if ((health + modifier < 0) || (health + modifier > 10) ||
					(MaxStats - modifier > 10 || MaxStats - modifier < 0)) return;

                health = value;
                MaxStats -= modifier;
            }
        }

        private int attack;
        public int Attack 
        {
            get 
            {
                return attack;
            }
            set 
            {
                int modifier = value - attack;
				if ((attack + modifier < 0 || attack + modifier > 10) || 
                    (MaxStats - modifier > 10 || MaxStats - modifier < 0)) return;

				attack = value;
                MaxStats -= modifier;
            }
        }
        public int MaxStats;

        private Guilds guild;
        public Guilds Guild 
        {
            get 
            {
                return guild; 
            }
            set 
            {
                guild = value;
                UpdateGuildBonuses();
            }
        }

        public int HealthBonus = 0;
        public int AttackBonus = 0;


        public Character()
        {
            MaxStats = 10;
            Health = 0;
            Attack = 0;
        }

        private void UpdateGuildBonuses()
        {
            switch (Guild) 
            {
                case Guilds.Thieves:
					if (HealthBonus <= 0)
					{
						if (AttackBonus > 0)
						{
							Attack -= 2;
						}
						HealthBonus = 2;
						AttackBonus = 0;

						attack += AttackBonus;
						health += HealthBonus;
					}
					break;

                case Guilds.Assasins:
					if (AttackBonus <= 0)
					{
						if (HealthBonus > 0)
						{
							Health -= 2;
						}
						HealthBonus = 0;
						AttackBonus = 2;

						attack += AttackBonus;
						health += HealthBonus;
					}
					break;
            }
        }

        public string Encounter(Character npc)
        {
            if (Guild == npc.Guild)
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
