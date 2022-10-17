using System;
using System.Collections.Generic;
using System.Text;

namespace event_timers_project
{
    class Character
    {
        public string Name { get; set; }
        public List<Character> Friends { get; set; }
        public List<Character> Ennemies { get; set; }
        public int LifeTime { get; set; }

        public Character(string name, int lifeTime)
        {
            this.Name = name;
            this.LifeTime = lifeTime;
            this.Friends = new List<Character>();
            this.Ennemies = new List<Character>();
        }

        public Character(string name)
        {
            Random rand = new Random();
            this.Name = name;
            this.LifeTime = rand.Next(1, 10);
            this.Friends = new List<Character>();
            this.Ennemies = new List<Character>();
        }

        public void MakingFriendsAndEnnemies(List<Character> characters)
        {
            foreach (Character character in characters)
            {

                if (character != this)
                {
                    FriendOrEnnemy(character);
                }
            }
        }

        private void FriendOrEnnemy(Character character)
        {
            Random rand = new Random();
            int friendOrEnnemy = rand.Next(0, 2);

            if (friendOrEnnemy == 0)
            {
                if (!character.Friends.Contains(this))
                {
                    this.Ennemies.Add(character);
                    Console.WriteLine($"{this.Name} considère {character.Name} comme un ennemi");
                }
                else
                {
                    Console.WriteLine($"{this.Name} est neutre envers {character.Name}");
                }
                
            }
            else
            {
                if (!character.Ennemies.Contains(this))
                {
                    this.Friends.Add(character);
                    Console.WriteLine($"{this.Name} considère {character.Name} comme un ami");
                }
                else
                {
                    Console.WriteLine($"{this.Name} est neutre envers {character.Name}");
                }
                
            }
        }
    }
}
