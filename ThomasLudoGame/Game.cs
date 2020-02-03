using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Game
    {
        private int counter;
        private List<Piece> playerPiecesAll = PieceCreator.CreatePiece();
        private List<Piece> player1Pieces = new List<Piece>();
        private List<Piece> player2Pieces = new List<Piece>();
        private List<Piece> player3Pieces = new List<Piece>();
        private List<Piece> player4Pieces = new List<Piece>();
        public Player Player1;
        private Player Player2;
        private Player Player3;
        private Player Player4;

        public Game(string player1Name,string player2Name)
        {
            
            Player1 = new Player(player1Name,Player1Pieces());
            Player2 = new Player(player2Name,Player2Pieces());
            
        }
        public Game(string player1Name, string player2Name,string player3Name)
        {
            
            Player1 = new Player(player1Name, Player1Pieces());
            Player2 = new Player(player2Name, Player2Pieces());
            Player3 = new Player(player3Name, Player3Pieces());
            
        }
        public Game(string player1Name, string player2Name, string player3Name, string player4Name)
        {

            Player1 = new Player(player1Name, Player1Pieces());
            Player2 = new Player(player2Name, Player2Pieces());
            Player3 = new Player(player3Name, Player3Pieces());
            Player4 = new Player(player4Name, Player4Pieces());
            
        }
        public List<Piece> Player1Pieces()
        {
            
            for (int i = 0; i < 4; i++)
            {
                player1Pieces.Add(playerPiecesAll[i]);
            }
            return player1Pieces;
        }
        public List<Piece> Player2Pieces()
        {
            
            for (int i = 4; i < 8; i++)
            {
                player2Pieces.Add(playerPiecesAll[i]);
            }
            return player2Pieces;
        }
        public List<Piece> Player3Pieces()
        {
            
            for (int i = 8; i < 12; i++)
            {
                player3Pieces.Add(playerPiecesAll[i]);
            }
            return player3Pieces;
        }
        public List<Piece> Player4Pieces()
        {
            for (int i = 12; i < 16; i++)
            {
                player4Pieces.Add(playerPiecesAll[i]);
            }
            return player4Pieces;
        }
        public void GetString()
        {
            foreach (Piece piece in player1Pieces)
            {
                Console.WriteLine(Player1.GetName());
                Console.WriteLine(piece.color);
                Console.WriteLine(piece.PieceNumber);
            }
            foreach (Piece piece1 in player2Pieces)
            {
                Console.WriteLine(piece1.color);
                Console.WriteLine(piece1.PieceNumber);
            }



        }
        public void Play()
        {
            for (int i = 1; i <= 2; i++)
            {
                Dice dice = new Dice();
                int diceNum = dice.ThrowDice();
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Player1.GetName() + " Har Slået: " + diceNum);
                    Console.WriteLine("Hvilken Brik vil du rykke med? ");
                    int pieceNum = int.Parse(Console.ReadLine());
                    foreach (Piece piece in Player1.Pieces)
                    {

                        if (pieceNum == piece.PieceNumber)
                        {
                            int newPos = piece.pos + diceNum;
                            piece.pos = newPos;
                            Console.WriteLine("Brik nr " + piece.PieceNumber + " er rykket frem til felt " + newPos);
                            Console.WriteLine("------------------------------------------------------------------------");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(Player2.GetName() + " Har Slået: " + diceNum);
                    Console.WriteLine("Hvilken Brik vil du rykke med? ");
                    int pieceNum = int.Parse(Console.ReadLine());
                    foreach (Piece piece in Player2.Pieces)
                    {

                        if (pieceNum == piece.PieceNumber)
                        {
                            int newPos = piece.pos + diceNum;
                            piece.pos = newPos;
                            Console.WriteLine("Brik nr " + piece.PieceNumber + " er rykket frem til felt " + newPos);
                            Console.WriteLine("------------------------------------------------------------------------");
                        }
                    }
                }
                
            }
            
           
        }
        public bool GameFinished()
        {
            if (counter == 100)
            {
                return true;
            }
            counter++;
            return false;
        }

    }
}
