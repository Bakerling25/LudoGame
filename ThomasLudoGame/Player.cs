using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Player
    {
        
        private string Name { get; set; }
        public List<Piece> Pieces { get; set; }
        
        public Player(string name,List<Piece> pieces)
        {
            Name = name;
            Pieces = pieces;
        }
        

    }
}
