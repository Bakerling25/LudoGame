﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Game
    {
        private bool hasPlayerPieceOnBoard = false;
        private int player1Start = 0;
        private int player2Start = 0;
        private List<Piece> playerPiecesAll = PieceCreator.CreatePiece();//Mine brikker bliver lagt listen 
        private List<Piece> player1Pieces = new List<Piece>();
        private List<Piece> player2Pieces = new List<Piece>();
        private List<Piece> player3Pieces = new List<Piece>();
        private List<Piece> player4Pieces = new List<Piece>();
        private Player Player1;
        private Player Player2;
        private Player Player3;
        private Player Player4;

        public Game(string player1Name,string player2Name)// Denne constructor bliver invoked af to string navne argumenter 
        {
            ///
            ///Her bliver player objektet instantieret med navn, brikker og falsk til at have nogle brikker på brættet 
            ///
            Player1 = new Player(player1Name,Player1Pieces(),hasPlayerPieceOnBoard);
            Player2 = new Player(player2Name,Player2Pieces(),hasPlayerPieceOnBoard);
            
        }
        public Game(string player1Name, string player2Name,string player3Name)
        {
            
            Player1 = new Player(player1Name, Player1Pieces(),hasPlayerPieceOnBoard);
            Player2 = new Player(player2Name, Player2Pieces(),hasPlayerPieceOnBoard);
            Player3 = new Player(player3Name, Player3Pieces(),hasPlayerPieceOnBoard);
            
        }
        public Game(string player1Name, string player2Name, string player3Name, string player4Name)
        {

            Player1 = new Player(player1Name, Player1Pieces(),hasPlayerPieceOnBoard);
            Player2 = new Player(player2Name, Player2Pieces(),hasPlayerPieceOnBoard);
            Player3 = new Player(player3Name, Player3Pieces(),hasPlayerPieceOnBoard);
            Player4 = new Player(player4Name, Player4Pieces(),hasPlayerPieceOnBoard);
            
        }
        public List<Piece> Player1Pieces() // Uddeller de første fire brikker i playerPiecesAll til player1
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
                
                if (i == 1)// hvir det er player 1 tur 
                {
                    if (Player1.HasPlayerOnePieceOnBoard == false)// ikke har nogen brikker på brættet 
                    {
                        for (int k = 1; k < 4; k++)// de tre forsøg man har til at slå en sekser for at komme ud
                        {
                            player1Start = dice.ThrowDice();
                            Console.WriteLine(Player1.GetName() + " har slået " + player1Start + " i " + k + " forsøg");
                            if (player1Start == 6)// hvis en sekser er slået
                            {
                                IsPlayer1AllowedToMove();// for spileren lov til at rykke
                            }
                        }
                    }
                    else
                    {
                        Player1Turn();// lige så snart at player har en brik på brættet køres denne metode
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
        public bool GameFinished()// returns true hvis spilet er slut ellers false
        {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;
            foreach (Piece piece in Player1.Pieces)
            {
                if (piece.IsAtGoal)// chekker om brikken er mål
                {
                    counterPlayer1++;
                    if (counterPlayer1 == 4)// hvis alle 4 brikker er i mål returner true
                    {
                        Console.WriteLine(Player1.GetName() + " har vundet");
                        return true;
                    }
                }
            }
            foreach (Piece piece1 in Player2.Pieces)
            {
                if (piece1.IsAtGoal)
                {
                    counterPlayer2++;
                    if (counterPlayer2 == 4)
                    {
                        Console.WriteLine(Player2.GetName() + " har vundet");
                        return true;
                    }
                }
            }
            return false; 
        }
        public void Player1Turn() // sørger for at player1 kan rykke sin brik
        {
            Dice dice = new Dice();
            int diceNum = dice.ThrowDice();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Player1.GetName() + " Har Slået: " + diceNum);
            Console.WriteLine("Hvilken Brik vil du rykke med? ");
            int pieceNum = int.Parse(Console.ReadLine());
            foreach (Piece piece in Player1.Pieces)
            {

                if (pieceNum == piece.PieceNumber && piece.IsAtGoal == false)// tjekker om brikken er i mål
                {
                    int newPos = piece.pos + diceNum;// ligger det terningen har rullet til den nuværende position
                    piece.pos = newPos;
                    Console.WriteLine("Brik nr " + piece.PieceNumber + " er rykket frem til felt " + newPos);
                    Console.WriteLine("------------------------------------------------------------------------");
                    if (piece.pos >= 57)// hvis brikken er i mål 
                    {
                        Console.WriteLine("Brik nr " + piece.PieceNumber + " er kommet hjem ");
                        piece.IsAtGoal = true;
                    }
                }
                else if (pieceNum == piece.PieceNumber && piece.IsAtGoal == true)// hvis brikken er i mål 
                {
                    if (GameFinished())// tjekker igen
                    {
                        break;
                    }
                    WriteToPlayer(pieceNum);// fortæller hvilken brik som ikke må rykkes med
                    Player1Turn();// kør igen
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

                if (pieceNum == piece.PieceNumber && piece.IsAtGoal == false)
                {

                    int newPos = piece.pos + diceNum;
                    piece.pos = newPos;
                    Console.WriteLine("Brik nr " + piece.PieceNumber + " er rykket frem til felt " + newPos);
                    Console.WriteLine("------------------------------------------------------------------------");
                    if (piece.pos >= 57)
                    {
                        Console.WriteLine("Brik nr " + piece.PieceNumber + " er kommet hjem ");
                        piece.IsAtGoal = true;
                    }
                }
                else if(pieceNum == piece.PieceNumber && piece.IsAtGoal == true)
                {
                    if (GameFinished())
                    {
                        break;
                    }
                    WriteToPlayer(pieceNum);
                    Player2Turn();
                }
                
                
            }

        }
        public void IsPlayer1AllowedToMove()// Tjekker om spilleren har har en brik på brættet 
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
        public bool IsitHome(Player player, int pieceNum)// tjekker om brikker er ude
        {
            foreach (Piece piece in player.Pieces)
            {
                if (piece.pos == 0 && piece.PieceNumber == pieceNum)
                {
                    return true;
                }
            }
            return false;
        }
        

    }
}
