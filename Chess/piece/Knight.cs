using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess.piece
{
    public class Knight : Piece
    {
        public Knight(Color color, Coordinates coordinates) : base(color, coordinates)
        {

        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            return new HashSet<CoordinatesShift>
            {
                new CoordinatesShift(1, 2),
                new CoordinatesShift(2, 1),

                new CoordinatesShift(2, -1),
                new CoordinatesShift(1, -2),

                new CoordinatesShift(-2, -1),
                new CoordinatesShift(-1, -2),

                new CoordinatesShift(-2, 1),
                new CoordinatesShift(-1, 2)
            };
        }
    }
}
