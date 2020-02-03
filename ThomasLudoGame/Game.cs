using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Game
    {
        private int counter;
        private bool isGameFinished = false;
        public List<Player> players = new List<Player>();
        private Player Player1;
        private Player Player2;
        private Player Player3;
        private Player Player4;
        
        public Game(string player1Name,string player2Name)
        {
            var playerPieces = PieceCreator.GetPieces(PieceCreator.CreatePiece());
            Player1 = new Player(player1Name,playerPieces);
            Player2 = new Player(player2Name,playerPieces);
        }
        public Game(string player1Name,string player2Name,string player3Name)
        {
            var playerPieces = PieceCreator.GetPieces(PieceCreator.CreatePiece());
            Player1 = new Player(player1Name,playerPieces);
            Player2 = new Player(player2Name,playerPieces);
            Player3 = new Player(player3Name,playerPieces);
            
        }
        public Game(string player1Name, string player2Name, string player3Name,string player4Name)
        {
            var playerPieces = PieceCreator.GetPieces(PieceCreator.CreatePiece());
            Player1 = new Player(player1Name,playerPieces);
            Player2 = new Player(player2Name,playerPieces);
            Player3 = new Player(player3Name,playerPieces);
            Player4 = new Player(player4Name,playerPieces);
            
        }
        
        public int HowManyPlayers(int playerCount)
        {

        }
        public bool GameFinished()
        {
            return isGameFinished;
        }
    }
}
