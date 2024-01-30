using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.board;

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

        protected virtual bool isSquareAvailableForAttack(Coordinates coordinates, Board board)
        {
            return true;
        }

        protected abstract HashSet<CoordinatesShift> getPieceMoves();

        protected virtual HashSet<CoordinatesShift> getPieceAttacks()
        {
            return getPieceMoves();
        }

        public HashSet<Coordinates> getAttackedSquares(Board board)
        {
            HashSet<CoordinatesShift> pieceAttacks = getPieceAttacks();
            HashSet<Coordinates> result = new HashSet<Coordinates>();

            foreach (CoordinatesShift pieceAttack in pieceAttacks)
            {
                if (coordinates.canShift(pieceAttack))
                {
                    Coordinates shiftedCoordinates = coordinates.shift(pieceAttack);

                    if (isSquareAvailableForAttack(shiftedCoordinates, board))
                    {
                        result.Add(shiftedCoordinates);
                    }
                }
            }

            return result;
        }
    }
}