﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.piece;

namespace Chess.board
{
    public class Board
    {
        private readonly string _startingFen;
        public string startingFen { get { return _startingFen; } }
        private Dictionary<Coordinates, Piece> pieces = new Dictionary<Coordinates, Piece>();
        public List<Move> moves = new List<Move>();

        public Board(string startingFen)
        {
            _startingFen = startingFen;
        }

        public void setPiece(Coordinates coordinates, Piece piece)
        {
            piece.coordinates = coordinates;
            pieces.Remove(coordinates); //added
            pieces.Add(coordinates, piece);
        }

        public void removePiece(Coordinates coordinates)
        {
            pieces.Remove(coordinates);
        }

        public void makeMove(Move move)
        {
            Piece piece = getPiece(move.from);

            removePiece(move.from);
            setPiece(move.to, piece);
            //delete piece if eated

            moves.Add(move);
        }

        public bool isSquareEmpty(Coordinates coordinates)
        {
            return !pieces.ContainsKey(coordinates);
        }

        public Piece getPiece(Coordinates coordinates)
        {
            if (pieces.TryGetValue(coordinates, out Piece piece))
            {
                return piece;
            }
            else
            {
                return null;
            }
        }

        public void setupDefaultPiecesPositions()
        {
            //set pawns
            foreach (File file in Enum.GetValues(typeof(File)))
            {
                setPiece(new Coordinates(file, 2), new Pawn(Color.WHITE, new Coordinates(file, 2)));
                setPiece(new Coordinates(file, 7), new Pawn(Color.BLACK, new Coordinates(file, 7)));
            }

            //set rooks
            setPiece(new Coordinates(File.A, 1), new Rook(Color.WHITE, new Coordinates(File.A, 1)));
            setPiece(new Coordinates(File.H, 1), new Rook(Color.WHITE, new Coordinates(File.H, 1)));
            setPiece(new Coordinates(File.A, 8), new Rook(Color.BLACK, new Coordinates(File.A, 8)));
            setPiece(new Coordinates(File.H, 8), new Rook(Color.BLACK, new Coordinates(File.H, 8)));

            //set knights
            setPiece(new Coordinates(File.B, 1), new Knight(Color.WHITE, new Coordinates(File.B, 1)));
            setPiece(new Coordinates(File.G, 1), new Knight(Color.WHITE, new Coordinates(File.G, 1)));
            setPiece(new Coordinates(File.B, 8), new Knight(Color.BLACK, new Coordinates(File.B, 8)));
            setPiece(new Coordinates(File.G, 8), new Knight(Color.BLACK, new Coordinates(File.G, 8)));

            //set bishops
            setPiece(new Coordinates(File.C, 1), new Bishop(Color.WHITE, new Coordinates(File.C, 1)));
            setPiece(new Coordinates(File.F, 1), new Bishop(Color.WHITE, new Coordinates(File.F, 1)));
            setPiece(new Coordinates(File.C, 8), new Bishop(Color.BLACK, new Coordinates(File.C, 8)));
            setPiece(new Coordinates(File.F, 8), new Bishop(Color.BLACK, new Coordinates(File.F, 8)));

            //set queens
            setPiece(new Coordinates(File.D, 1), new Queen(Color.WHITE, new Coordinates(File.D, 1)));
            setPiece(new Coordinates(File.D, 8), new Queen(Color.BLACK, new Coordinates(File.D, 8)));

            //set kings
            setPiece(new Coordinates(File.E, 1), new King(Color.WHITE, new Coordinates(File.E, 1)));
            setPiece(new Coordinates(File.E, 8), new King(Color.BLACK, new Coordinates(File.E, 8)));
        }

        public static bool isSquareDark(Coordinates coordinates)
        {
            return ((int)coordinates.file + 1 + coordinates.rank) % 2 == 0;
        }

        public bool isSquareAttackedByColor(Coordinates coordinates, Color color)
        {
            List<Piece> pieces = getPiecesByColor(color);

            foreach (Piece piece in pieces)
            {
                HashSet<Coordinates> attackedSquares = piece.getAttackedSquares(this);

                if (attackedSquares.Contains(coordinates))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Piece> getPiecesByColor(Color color)
        {
            List<Piece> result = new List<Piece>();

            foreach (Piece piece in pieces.Values)
            {
                if (piece.color == color)
                {
                    result.Add(piece);
                }
            }

            return result;
        }
    }
}
