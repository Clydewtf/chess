using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.piece;

namespace Chess
{
    public class Game
    {
        private readonly Board _board;
        protected BoardConsoleRenderer renderer = new BoardConsoleRenderer();
        protected InputCoordinates inputCoordinates = new InputCoordinates();
        protected Board board { get { return _board; } }

        public Game(Board board)
        { 
            _board = board;
        }
        public void gameLoop()
        {
            bool isWhiteToMove = true;

            while (true)
            {
                //render
                renderer.render(board);

                if (isWhiteToMove )
                {
                    Console.WriteLine("White to move");
                }
                else
                {
                    Console.WriteLine("Black to move");
                }

                //input
                Coordinates sourceCoordinates = inputCoordinates.inputPieceCoordinatesForColor(
                    isWhiteToMove ? Color.WHITE : Color.BLACK, board);

                Piece piece = board.getPiece(sourceCoordinates);
                HashSet<Coordinates> availableMoveSquare = piece.getAvailableMoveSquares(board);

                //render
                renderer.render(board, piece);

                Coordinates targetCoordinates = inputCoordinates.inputAvailableSquare(availableMoveSquare);

                //make move
                board.movePiece(sourceCoordinates, targetCoordinates);

                //pass move
                isWhiteToMove =! isWhiteToMove;
            }
        }
    }
}
