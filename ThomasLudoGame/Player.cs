using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Player
    {
        
        private string Name { get; set; }
        public List<Piece> Pieces { get; set; }
        public bool HasPlayerOnePieceOnBoard { get; set; }
        
        public Player(string name,List<Piece> pieces,bool hasPlayerOnePieceOnBoard)
        {
            Name = name;
            Pieces = pieces;
            HasPlayerOnePieceOnBoard = hasPlayerOnePieceOnBoard;
        }
        public string GetName()
        {
            return Name;
        }

    }
}
