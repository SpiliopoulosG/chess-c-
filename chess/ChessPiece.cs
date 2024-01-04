using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static chess.Form2;

namespace chess {
    public partial class Chess
    {
        private PictureBox[,] chessboard;

        public PictureBox[,] Chessboard
        {
            get { return chessboard; }
            set { chessboard = value; }
        }
        public void PromotePawn(PawnMove pawnMove, PieceType selectedPieceType)
        {
            // Remove the existing pawn
            // Remove the existing pawn
            chessboard[pawnMove.StartRow, pawnMove.StartCol].Tag = null;

            // Determine the new piece type based on the selected promotion
            ChessPiece newPiece;
            switch (selectedPieceType)
            {
                case PieceType.Queen:
                    newPiece = new QueenMove
                    {
                        Player = pawnMove.Player,
                        StartRow = pawnMove.StartRow,
                        StartCol = pawnMove.StartCol,
                        EndRow = pawnMove.EndRow,
                        EndCol = pawnMove.EndCol,
                        IsCapture = pawnMove.IsCapture,
                        IsPromotion = pawnMove.IsPromotion
                    };
                    break;
                // Add cases for other promoted pieces (Rook, Bishop, Knight) if needed

                default:
                    // Default to Queen if the selected piece type is not recognized
                    newPiece = new QueenMove
                    {
                        Player = pawnMove.Player,
                        StartRow = pawnMove.StartRow,
                        StartCol = pawnMove.StartCol,
                        EndRow = pawnMove.EndRow,
                        EndCol = pawnMove.EndCol,
                        IsCapture = pawnMove.IsCapture,
                        IsPromotion = pawnMove.IsPromotion
                    };
                    break;
            }

            // Place the new piece on the destination square
            this.chessboard[pawnMove.EndRow, pawnMove.EndCol].Tag = newPiece;
        }

        public void UpdateChessboardUI()
        {
            // Implement the logic to update the chessboard UI
            // This might include refreshing the PictureBoxes, labels, or other UI elements related to the chessboard.
        }

        // ... other members and methods ...
    }
    public enum PieceType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }
    
}

