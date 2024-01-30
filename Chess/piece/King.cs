using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.board;

namespace Chess.piece
{
    public class King : Piece
    {
        public King(Color color, Coordinates coordinates) : base(color, coordinates)
        {

        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();

            for (int fileShift = -1; fileShift <= 1; fileShift++)
            {
                for (int rankShift = -1; rankShift <= 1; rankShift++)
                {
                    if ((fileShift == 0) && (rankShift == 0))
                    {
                        continue;
                    }

                    result.Add(new CoordinatesShift(fileShift, rankShift));
                }
            }

            return result;
        }

        protected override bool isSquareAvailableForMove(Coordinates coordinates, Board board)
        {
            bool result = base.isSquareAvailableForMove(coordinates, board);

            if (result)
            {
                return !board.isSquareAttackedByColor(coordinates, color.opposite());
            }
            else
            {
                return false;
            }
        }
    }
}
