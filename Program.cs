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

            foreach (Character character in characters)
            {
                character.MakingFriendsAndEnnemies(characters);
                Console.WriteLine();
            }


            while (characters.Count != deadCharacters.Count)
            {
                foreach (Character character in characters)
                {
                    await character.LifeReduction(characters, deadCharacters);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Tout le monde est mort");
        }
    }
}
