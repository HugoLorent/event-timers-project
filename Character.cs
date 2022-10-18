using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_timers_project
{
    class Character
    {
        public string Name { get; set; }
        public List<Character> Friends { get; set; }
        public List<Character> Ennemies { get; set; }
        public int LifeTime { get; set; }

        public event EventHandler Death;

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

        public void OnDeath(EventArgs e)
        {
            EventHandler handler = Death;
            handler?.Invoke(this, e);
        }

        public async Task LifeReduction(List<Character> characters, List<Character> deadCharacters)
        {
            await Task.Delay(1000);
            this.LifeTime--;

            if (this.LifeTime == 0)
            {
                Console.WriteLine($"{this.Name} est mort");
                deadCharacters.Add(this);

                foreach (Character character in characters)
                {
                    character.Death -= this.Cry;
                    character.Death -= this.Laugh;
                }
                this.OnDeath(EventArgs.Empty);
            }
        }

        public void Cry(object sender, EventArgs e)
        {
            Console.WriteLine($"{this.Name} pleure");
        }

        public void Laugh(object sender, EventArgs e)
        {
            Console.WriteLine($"{this.Name} rigole");
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
                    character.Death += this.Laugh;
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
                    character.Death += this.Cry;
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
