using Chess.board;
using Chess.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class StalemateGameStateChecker : GameStateChecker
    {
        public override GameState check(Board board, Color color)
        {
            List<Piece> pieces = board.getPiecesByColor(color);

            foreach (Piece piece in pieces)
            {
                HashSet<Coordinates> availableMoveSquares = piece.getAvailableMoveSquares(board);

                if (availableMoveSquares.Count() > 0)
                {
                    return GameState.ONGOING;
                }
            }

            return GameState.STALEMATE;
        }
    }
}
