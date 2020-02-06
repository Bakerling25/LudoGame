using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class PieceCreator
    {
        
        public static List<Piece> CreatePiece()
        {
            List<Piece> pieces = new List<Piece>();
            foreach (PieceColor pieceColor in Enum.GetValues(typeof(PieceColor)))
            {
                for (int pieceNum = 1; pieceNum < 5; pieceNum++)
                {
                    pieces.Add(new Piece()
                    {
                        color = pieceColor,
                        PieceNumber = pieceNum,
                        IsAtHome = false
                    });
                }
                
            }
            return pieces;
        }
        
       

    }
}
