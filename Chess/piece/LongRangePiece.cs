using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.piece
{
    public abstract class LongRangePiece : Piece
    {
        public LongRangePiece(Color color, Coordinates coordinates) : base(color, coordinates)
        {

        }

        protected override bool isSquareAvailableForMove(Coordinates coordinates, Board board)
        {
            bool result = base.isSquareAvailableForMove(coordinates, board);

            if (result)
            {
                List<Coordinates> coordinatesBetween;

                if (this.coordinates.file == coordinates.file)
                {
                    coordinatesBetween = BoardUtils.getVerticalCoordinatesBetween(this.coordinates, coordinates);
                }
                else if (this.coordinates.rank.Equals(coordinates.rank))
                {
                    coordinatesBetween = BoardUtils.getHorizontalCoordinatesBetween(this.coordinates, coordinates);
                }
                else
                {
                    coordinatesBetween = BoardUtils.getDiagonalCoordinatesBetween(this.coordinates, coordinates);
                }

                foreach (Coordinates c in coordinatesBetween)
                {
                    if (!board.isSquareEmpty(c))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
