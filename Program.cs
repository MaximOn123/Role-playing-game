using System;

namespace Role_playing_game
{
    class Program
    {
        static void Main()
        {
            Character Char = new Character("Orс", Character.Races.Orс, Character.Sexes.Male );
            Console.WriteLine(Char.ToString());
        }
    }
}
