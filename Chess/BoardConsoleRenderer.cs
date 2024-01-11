using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.piece;

namespace Chess
{
    public class BoardConsoleRenderer
    {
        public static readonly string ANSI_RESET = "\u001B[0m";
        public static readonly string ANSI_WHITE_PIECE_COLOR = "\u001B[97m";
        public static readonly string ANSI_BLACK_PIECE_COLOR = "\u001B[30m";
        public static readonly string ANSI_WHITE_SQUARE_BACKGROUND = "\u001B[47m";
        public static readonly string ANSI_BLACK_SQUARE_BACKGROUND = "\u001B[0;100m";
        public static readonly string ANSI_HIGHLIGHTED_SQUARE_BACKGROUND = "\u001B[45m";

        public void render(Board board, Piece pieceToMove)
        {
            HashSet<Coordinates> availableMoveSquares =
                new HashSet<Coordinates>(Enumerable.Empty<Coordinates>());

            if (pieceToMove != null)
            {
                availableMoveSquares = pieceToMove.getAvailableMoveSquares(board);
            }

            for (int rank = 8; rank >= 1; rank--)
            {
                string line = "";
                foreach (File file in Enum.GetValues(typeof(File)))
                {
                    //Console.WriteLine(file + rank.ToString());
                    Coordinates coordinates = new Coordinates(file, rank);
                    bool isHighlight = availableMoveSquares.Contains(coordinates);

                    if (board.isSquareEmpty(coordinates))
                    {
                        line += getSpriteForEmptySquare(coordinates, isHighlight);
                    }
                    else
                    {
                        line += getPieceSprite(board.getPiece(coordinates), isHighlight);
                    }
                }

                line += ANSI_RESET;
                Console.WriteLine(line);
            }
        }

        public void render(Board board)
        {
            render(board, null);
        }

        private string colorizeSprite(string sprite, Color pieceColor, bool isSquareDark, bool isHighlighted)
        {
            // format = background color + font color + text
            string result = sprite;

            if (pieceColor == Color.WHITE)
            {
                result = ANSI_WHITE_PIECE_COLOR + result;
            }
            else
            {
                result = ANSI_BLACK_PIECE_COLOR + result;
            }

            if (isHighlighted)
            {
                result = ANSI_HIGHLIGHTED_SQUARE_BACKGROUND + result;
            }
            else if (isSquareDark)
            {
                result = ANSI_BLACK_SQUARE_BACKGROUND + result;
            }
            else
            {
                result = ANSI_WHITE_SQUARE_BACKGROUND + result;
            }

            return result;
        }

        private string getSpriteForEmptySquare(Coordinates coordinates, bool isHighlight)
        {
            return colorizeSprite("   ", Color.WHITE, Board.isSquareDark(coordinates), isHighlight);
        }

        private string selectUnicodeSpriteForPiece(Piece piece)
        {
            switch (piece.GetType().Name)
            {
                case "Pawn":
                    return "♙";
                case "Knight":
                    return "♞";
                case "Bishop":
                    return "♝";
                case "Rook":
                    return "♜";
                case "Queen":
                    return "♛";
                case "King":
                    return "♚";
                default:
                    return "";
            }
        }

        private string getPieceSprite(Piece piece, bool isHighlight)
        {
            return colorizeSprite(" " + selectUnicodeSpriteForPiece(piece)
                + " ", piece.color, Board.isSquareDark(piece.coordinates), isHighlight);
        }
    }
}
