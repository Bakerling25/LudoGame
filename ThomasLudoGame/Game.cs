using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Game
    {
        private int counter;
        private bool hasPlayerOnePieceOnBoard = false;
        private int player1Start = 0;
        private int player2Start = 0;
        //private bool hasPlayer1ThrownThreeSixes = false;
        //private bool hasPlayer2ThrownThreeSixes = false;
        private List<Piece> playerPiecesAll = PieceCreator.CreatePiece();
        private List<Piece> player1Pieces = new List<Piece>();
        private List<Piece> player2Pieces = new List<Piece>();
        private List<Piece> player3Pieces = new List<Piece>();
        private List<Piece> player4Pieces = new List<Piece>();
        private Player Player1;
        private Player Player2;
        private Player Player3;
        private Player Player4;

        public Game(string player1Name,string player2Name)
        {
            
            Player1 = new Player(player1Name,Player1Pieces(),hasPlayerOnePieceOnBoard);
            Player2 = new Player(player2Name,Player2Pieces(),hasPlayerOnePieceOnBoard);
            
        }
        public Game(string player1Name, string player2Name,string player3Name)
        {
            
            Player1 = new Player(player1Name, Player1Pieces(),hasPlayerOnePieceOnBoard);
            Player2 = new Player(player2Name, Player2Pieces(),hasPlayerOnePieceOnBoard);
            Player3 = new Player(player3Name, Player3Pieces(),hasPlayerOnePieceOnBoard);
            
        }
        public Game(string player1Name, string player2Name, string player3Name, string player4Name)
        {

            Player1 = new Player(player1Name, Player1Pieces(),hasPlayerOnePieceOnBoard);
            Player2 = new Player(player2Name, Player2Pieces(),hasPlayerOnePieceOnBoard);
            Player3 = new Player(player3Name, Player3Pieces(),hasPlayerOnePieceOnBoard);
            Player4 = new Player(player4Name, Player4Pieces(),hasPlayerOnePieceOnBoard);
            
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
       
        public void Play(int numberOfPlayers)
        {

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Dice dice = new Dice();
                
                if (i == 1)
                {
                    if (Player1.HasPlayerOnePieceOnBoard == false)
                    {
                        for (int k = 1; k < 4; k++)
                        {
                            player1Start = dice.ThrowDice();
                            Console.WriteLine(Player1.GetName() + " har slået " + player1Start + " i " + k + " forsøg");
                            if (player1Start == 6)
                            {
                                IsPlayer1AllowedToMove();
                            }
                        }
                    }
                    else
                    {
                        Player1Turn();
                    }
                }
                else
                {
                    if (Player2.HasPlayerOnePieceOnBoard == false)
                    {
                        for (int k = 1; k < 4; k++)
                        {
                            player2Start = dice.ThrowDice();
                            Console.WriteLine(Player2.GetName() + " har slået " + player2Start + " i " + k + " forsøg");
                            if (player2Start == 6)
                            {
                                IsPlayer2AllowedToMove();
                            }
                        }
                    }
                    else
                    {
                        Player2Turn();
                    }
                }
            }
            
           
        }
        public bool GameFinished()
        {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;
            foreach (Piece piece in Player1.Pieces)
            {
                if (piece.IsAtHome)
                {
                    counterPlayer1++;
                    if (counter == 4)
                    {
                        return true;
                    }
                }
            }
            foreach (Piece piece1 in Player2.Pieces)
            {
                if (piece1.IsAtHome)
                {
                    counterPlayer2++;
                    if (counter == 4)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Player1Turn() 
        {
            Dice dice = new Dice();
            int diceNum = dice.ThrowDice();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Player1.GetName() + " Har Slået: " + diceNum);
            Console.WriteLine("Hvilken Brik vil du rykke med? ");
            int pieceNum = int.Parse(Console.ReadLine());
            foreach (Piece piece in Player1.Pieces)
            {

                if (pieceNum == piece.PieceNumber && piece.IsAtHome == false)
                {
                    int newPos = piece.pos + diceNum;
                    piece.pos = newPos;
                    Console.WriteLine("Brik nr " + piece.PieceNumber + " er rykket frem til felt " + newPos);
                    Console.WriteLine("------------------------------------------------------------------------");
                    if (piece.pos > 57)
                    {
                        Console.WriteLine("Brik nr " + piece.PieceNumber + " er kommet hjem ");
                        piece.IsAtHome = true;
                    }
                }
                else if (pieceNum == piece.PieceNumber && piece.IsAtHome == true)
                {
                    WriteToPlayer(pieceNum);
                }
                
            }


        }
        public void Player2Turn()
        {
            Dice dice = new Dice();
            int diceNum = dice.ThrowDice();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Player2.GetName() + " Har Slået: " + diceNum);
            Console.WriteLine("Hvilken Brik vil du rykke med? ");
            int pieceNum = int.Parse(Console.ReadLine());
            foreach (Piece piece in Player2.Pieces)
            {

                if (pieceNum == piece.PieceNumber && piece.IsAtHome == false)
                {

                    int newPos = piece.pos + diceNum;
                    piece.pos = newPos;
                    Console.WriteLine("Brik nr " + piece.PieceNumber + " er rykket frem til felt " + newPos);
                    Console.WriteLine("------------------------------------------------------------------------");
                    if (piece.pos > 57)
                    {
                        Console.WriteLine("Brik nr " + piece.PieceNumber + " er kommet hjem ");
                        piece.IsAtHome = true;
                    }
                }
                else if(pieceNum == piece.PieceNumber && piece.IsAtHome == true)
                {
                    WriteToPlayer(pieceNum);
                }
                
                
            }

        }
        public void IsPlayer1AllowedToMove()
        {
            int counter = 0;
            foreach (Piece piece in Player1.Pieces)
            {
                if (piece.pos == 0)
                {
                    counter++;
                    if (counter == 4)
                    {
                        Player1.HasPlayerOnePieceOnBoard = false;
                    }
                    
                }
                
            }
            Player1.HasPlayerOnePieceOnBoard = true;
            
        }
        public void IsPlayer2AllowedToMove()
        {
            int counter = 0;
            foreach (Piece piece in Player2.Pieces)
            {
                if (piece.pos == 0)
                {
                    counter++;
                    if (counter == 4)
                    {
                        Player2.HasPlayerOnePieceOnBoard = false;
                    }
                    
                }

            }
            Player2.HasPlayerOnePieceOnBoard = true;
            
        }
        public void WriteToPlayer(int pieceNumber)
        {
            Console.WriteLine("Brik nr: " + pieceNumber + " er kommet hjem, så den kan ikke rykkes med!!");
        }
        //public int ThrowThreeSixes()
        //{
        //    int diceNum;
        //    Dice dice = new Dice();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        diceNum = dice.ThrowDice();
        //        Console.WriteLine("Der er slået " + diceNum + " på " + i + " forsøg");
        //        if (diceNum == 6)
        //        {
        //            return diceNum;
        //        }
                
                
        //    }
        //    Console.WriteLine("Du har ikke flere forsøg tilbage");
        //    return 0;
        //}

    }
}
