using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Player
    {
        
        private string Name { get; set; }
        public Queue<Piece> Pieces { get; set; }
        
        public Player(string name,Queue<Piece> pieces)
        {
            Name = name;
            Pieces = pieces;
        }
        

    }
}
