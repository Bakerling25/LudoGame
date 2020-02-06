using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Piece
    {
        public PieceColor color { get; set; }
        public int PieceNumber{ get; set; }
        public int pos { get; set; }
        public bool IsAtGoal { get; set; }
    }
}
