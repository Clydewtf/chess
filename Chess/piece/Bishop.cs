using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.piece
{
    public class Bishop : LongRangePiece
    {
        public Bishop(Color color, Coordinates coordinates) : base(color, coordinates)
        {

        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();

            //bottom-left to top-right
            for (int i = -7; i <= 7; i++)
            {
                if (i == 0) continue;

                result.Add(new CoordinatesShift(i, i));
            }

            //top-left to bottom-right
            for (int i = -7; i <= 7; i++)
            {
                if (i == 0) continue;

                result.Add(new CoordinatesShift(i, -i));
            }

            return result;
        }
    }
}
