using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Game
    {
        private int counter;
        private bool isGameFinished = false;
        private static List<Piece> playerPiecesAll = PieceCreator.CreatePiece();
        private static List<Piece> player1Pieces = new List<Piece>();
        private static List<Piece> player2Pieces = new List<Piece>();
        private static List<Piece> player3Pieces = new List<Piece>();
        private static List<Piece> player4Pieces = new List<Piece>();
        private Player Player1;
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

        public bool GameFinished()
        {
            return isGameFinished;
        }
        public static List<Piece> Player1Pieces()
        {
            
            for (int i = 0; i < 4; i++)
            {
                player1Pieces.Add(playerPiecesAll[i]);
            }
            return playerPiecesAll;
        }
        public static List<Piece> Player2Pieces()
        {
            List<Piece> player2Pieces = new List<Piece>();
            for (int i = 0; i < 4; i++)
            {
                player2Pieces.Add(playerPiecesAll[i]);
            }
            return playerPiecesAll;
        }
        public static List<Piece> Player3Pieces()
        {
            List<Piece> player3Pieces = new List<Piece>();
            for (int i = 0; i < 4; i++)
            {
                player3Pieces.Add(playerPiecesAll[i]);
            }
            return playerPiecesAll;
        }
        public static List<Piece> Player4Pieces()
        {
            List<Piece> player4Pieces = new List<Piece>();
            for (int i = 0; i < 4; i++)
            {
                player4Pieces.Add(playerPiecesAll[i]);
            }
            return playerPiecesAll;
        }
        //public static void GetString()
        //{
        //    foreach (Piece piece in player1Pieces)
        //    {
        //        Console.WriteLine(piece.color);
        //        Console.WriteLine(piece.PieceNumber);
        //    }
            

        //}
    }
}
