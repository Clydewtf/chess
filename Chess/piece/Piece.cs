using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.piece
{
    abstract public class Piece
    {
        private readonly Color _color;
        public Coordinates coordinates;

        public Color color
        {
            get { return _color; }
        }

        public Piece(Color color, Coordinates coordinates)
        {
            _color = color;
            this.coordinates = coordinates;
        }

        public HashSet<Coordinates> getAvailableMoveSquares(Board board)
        {
            HashSet<Coordinates> result = new HashSet<Coordinates>();

            foreach (CoordinatesShift shift in getPieceMoves())
            {
                if (coordinates.canShift(shift))
                {
                    Coordinates newCoordinates = coordinates.shift(shift);

                    if (isSquareAvailableForMove(newCoordinates, board))
                    {
                        result.Add(newCoordinates);
                    }
                }
            }

            return result;
        }

        protected virtual bool isSquareAvailableForMove(Coordinates coordinates, Board board)
        {
            return board.isSquareEmpty(coordinates) || board.getPiece(coordinates).color != color;
        }

        protected abstract HashSet<CoordinatesShift> getPieceMoves();
    }
}