using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class PieceCreator
    {
        private Queue<Piece> pieces = new Queue<Piece>();
        public static Queue<Piece> CreatePiece()
        {
            Queue<Piece> pieces = new Queue<Piece>();
            foreach (PieceColor pieceColor in Enum.GetValues(typeof(PieceColor)))
            {
                for (int pieceNum = 1; pieceNum < 5; pieceNum++)
                {
                    pieces.Enqueue(new Piece()
                    {
                        color = pieceColor,
                        PieceNumber = pieceNum
                        
                    });
                }
                
            }
            return pieces;
        }
        public static Queue<Piece> GetPieces(Queue<Piece> pieces)
        {
            for (int i = 0; i < 4; i++)
            {
                pieces.Enqueue(pieces.Dequeue());
            }
            return pieces;
        }

    }
}
