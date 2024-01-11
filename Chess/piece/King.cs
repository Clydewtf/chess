using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.piece
{
    public class King : Piece
    {
        public King(Color color, Coordinates coordinates) : base(color, coordinates)
        {

        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            return null;
        }
    }
}
