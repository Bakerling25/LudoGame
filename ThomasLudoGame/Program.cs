using System;

namespace ThomasLudoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv Antal spillere? 2-4 : ");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            if (numberOfPlayers == 2)
            {
                Console.WriteLine("Skriv navnene på spillerne");
                string player1 = Console.ReadLine();
                string player2 = Console.ReadLine();
                Game game = new Game(player1, player2);
                while (game.GameFinished() == false)
                {
                    game.Play();
                }
            }
            else if (numberOfPlayers == 3)
            {
                Console.WriteLine("Skriv navnene på spillerne");
                string player1 = Console.ReadLine();
                string player2 = Console.ReadLine();
                string player3 = Console.ReadLine();
                Game game = new Game(player1, player2, player3);
                while (!game.GameFinished())
                {
                    game.Play();
                }
            }
            else if (numberOfPlayers == 4)
            {
                Console.WriteLine("Skriv navnene på spillerne");
                string player1 = Console.ReadLine();
                string player2 = Console.ReadLine();
                string player3 = Console.ReadLine();
                string player4 = Console.ReadLine();
                Game game = new Game(player1, player2, player3, player4);
                while (!game.GameFinished())
                {
                    game.Play();
                }

            }
            else
            {
                Console.WriteLine("Tallet skal være immelem 2 og 4");
                
            }
            
            
            Console.ReadLine();
        }
    }
}
