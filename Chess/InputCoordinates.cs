using Chess.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class InputCoordinates
    {
        public Coordinates input()
        {
            while (true)
            {
                Console.WriteLine("Enter coordinates (ex. a1)");

                string line = Console.ReadLine();

                if (line.Length != 2)
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }

                char fileChar = line[0];
                char rankChar = line[1];

                if (!char.IsLetter(fileChar))
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }

                if (!char.IsDigit(rankChar))
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }

                int rank = (int)char.GetNumericValue(rankChar);
                if (rank < 1 || rank > 8)
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }

                File? file = FileExtensions.fromChar(fileChar);
                if (file == null)
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }

                return new Coordinates((File)file, rank);
            }
        }

        public Coordinates inputPieceCoordinatesForColor(Color color, Board board)
        {
            while (true)
            {
                Console.WriteLine("Enter coordinates for a piece to move");
                Coordinates coordinates = input();

                if (board.isSquareEmpty(coordinates))
                {
                    Console.WriteLine("Empty square");
                    continue;
                }

                Piece piece = board.getPiece(coordinates);
                if (piece.color != color)
                {
                    Console.WriteLine("Wrong color");
                    continue;
                }

                HashSet<Coordinates> availableMoveSquares = piece.getAvailableMoveSquares(board);
                if (availableMoveSquares.Count() == 0)
                {
                    Console.WriteLine("Blocked piece");
                    continue;
                }

                return coordinates;
            }
        }

        public Coordinates inputAvailableSquare(HashSet<Coordinates> coordinates)
        {
            while (true)
            {
                Console.WriteLine("Enter your move for selected piece");
                Coordinates _input = input();

                if (!coordinates.Contains(_input))
                {
                    Console.WriteLine("Non available square");
                    continue;
                }

                return _input;
            }
        }

        //public static void Main(string[] args)
        //{
        //    Console.OutputEncoding = Encoding.UTF8;

        //    InputCoordinates inputCoordinates = new InputCoordinates();
        //    Board board = new Board();
        //    board.setupDefaultPiecesPositions();

        //    Coordinates coordiates = inputCoordinates.inputPieceCoordinatesForColor(Color.WHITE, board);
        //    Console.WriteLine(coordiates);
        //}
    }
}
