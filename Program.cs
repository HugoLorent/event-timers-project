using System;
using System.Collections.Generic;

namespace event_timers_project
{
    class Program
    {
        public static List<Character> characters = new List<Character>();
        static void Main(string[] args)
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

            foreach (Character character in characters)
            {
                foreach (Character friend in character.Friends)
                {
                    Console.WriteLine($"{character.Name} est ami avec {friend.Name}");
                }

                foreach (Character ennemy in character.Ennemies)
                {
                    Console.WriteLine($"{character.Name} est ennemi avec {ennemy.Name}");
                }

                Console.WriteLine();
            }
        }
    }
}
