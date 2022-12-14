using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace event_timers_project
{
    class Character
    {
        public string Name { get; set; }
        public List<Character> Friends { get; set; }
        public List<Character> Ennemies { get; set; }
        public int LifeTime { get; set; }
        public bool IsPresident { get; set; }

        public event EventHandler Death;
        public event EventHandler PresidentDeath;

        public Character(string name, int lifeTime)
        {
            this.Name = name;
            this.LifeTime = lifeTime;
            this.Friends = new List<Character>();
            this.Ennemies = new List<Character>();
            this.IsPresident = false;
        }

        public Character(string name)
        {
            Random rand = new Random();
            this.Name = name;
            this.LifeTime = rand.Next(1, 10);
            this.Friends = new List<Character>();
            this.Ennemies = new List<Character>();
            this.IsPresident = false;
        }

        public Character()
        {
        }

        public void OnDeath(EventArgs e)
        {
            EventHandler handler = Death;
            handler?.Invoke(this, e);
        }

        public void OnPresidentDeath(EventArgs e)
        {
            EventHandler handler = PresidentDeath;
            handler?.Invoke(this, e);
        }

        public async Task LifeReduction(List<Character> characters, List<Character> deadCharacters)
        {
            await Task.Delay(1000);
            this.LifeTime--;

            if (this.LifeTime == 0)
            {
                deadCharacters.Add(this);
                Console.WriteLine($"{this.Name} est mort");

                if (this.IsPresident == true)
                {
                    PresidentDeathEvent(characters);
                }
                else
                {
                    foreach (Character character in characters)
                    {
                        character.Death -= this.Cry;
                        character.Death -= this.Laugh;
                    }
                    this.OnDeath(EventArgs.Empty);
                }
            }
        }

        private void PresidentDeathEvent(List<Character> characters)
        {
            foreach (Character character in characters)
            {
                if (character != this)
                {
                    if (!character.Ennemies.Contains(this))
                    {
                        this.PresidentDeath += character.Tribute;
                    }
                }
            }

            foreach (Character character in characters)
            {
                character.Death -= this.Cry;
                character.Death -= this.Laugh;
            }
            this.OnPresidentDeath(EventArgs.Empty);
        }

        public void Tribute(object sender, EventArgs e)
        {
            Console.WriteLine($"{this.Name} rend hommage à la mort du président");
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
