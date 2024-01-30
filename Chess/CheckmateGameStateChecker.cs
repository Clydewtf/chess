using Chess.board;
using Chess.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class CheckmateGameStateChecker : GameStateChecker
    {
        public override GameState check(Board board, Color color)
        {
            //we trust that there is king on the board
            Piece? king = board.getPiecesByColor(color).Where(piece => piece is King).FirstOrDefault();

            if (!board.isSquareAttackedByColor(king.coordinates, color.opposite()))
            {
                return GameState.ONGOING;
            }
            else
            {
                List<Piece> pieces = board.getPiecesByColor(color);

                foreach (Piece piece in pieces)
                {
                    HashSet<Coordinates> availableMoveSquares = piece.getAvailableMoveSquares(board);

                    foreach (Coordinates coordinates in availableMoveSquares)
                    {
                        Board clone = new BoardFactory().copy(board);

                        clone.makeMove(new Move(piece.coordinates, coordinates));

                        Piece? clonedKing = clone.getPiecesByColor(color).Where(p => p is King).FirstOrDefault();

                        if (!clone.isSquareAttackedByColor(clonedKing.coordinates, color.opposite()))
                        {
                            return GameState.ONGOING;
                        }
                    }
                }

                if (color == Color.WHITE)
                {
                    return GameState.CHECKMATE_TO_WHITE_KING;
                }
                else
                {
                    return GameState.CHECKMATE_TO_BLACK_KING;
                }
            }
        }
    }
}
