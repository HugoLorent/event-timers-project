using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace event_timers_project
{
    class Program
    {
        public static List<Character> characters = new List<Character>();
        public static List<Character> deadCharacters = new List<Character>();

        static async Task Main(string[] args)
        {
            Character remy = new Character("Rémy");
            Character olivier = new Character("Olivier");
            Character hugo = new Character("Hugo");
            characters.Add(remy);
            characters.Add(olivier);
            characters.Add(hugo);

            MakeFriendsAndEnnemies();
            Console.WriteLine($"{FindPresident().Name} est président");
            Console.WriteLine();
            await LaunchLifeTime();
        }

        private static async Task LaunchLifeTime()
        {
            while (characters.Count != deadCharacters.Count)
            {
                foreach (Character character in characters)
                {
                    await character.LifeReduction(characters, deadCharacters);
                }
            }
            Console.WriteLine("Tout le monde est mort");
        }

        private static void MakeFriendsAndEnnemies()
        {
            foreach (Character character in characters)
            {
                character.MakingFriendsAndEnnemies(characters);
                Console.WriteLine();
            }
        }

        private static Character FindPresident()
        {
            int greatestFriendsCount = 0;
            int lowestEnnemiesCount = 0;
            Character president = new Character();

            foreach (Character character in characters)
            {
                if (character.Friends.Count > greatestFriendsCount)
                {
                    greatestFriendsCount = character.Friends.Count;
                    lowestEnnemiesCount = character.Ennemies.Count;
                    president = character;
                }
                else if (character.Friends.Count == greatestFriendsCount)
                {
                    if (character.Ennemies.Count < lowestEnnemiesCount)
                    {
                        lowestEnnemiesCount = character.Ennemies.Count;
                        president = character;
                    }
                }
            }

            president.IsPresident = true;
            return president;
        }
    }
}
