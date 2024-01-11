using Chess.piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class BoardFactory
    {
        private PieceFactory pieceFactory = new PieceFactory();

        public Board fromFen(string fen)
        {
            // rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1

            Board board = new Board();

            string[] parts = fen.Split(" ");
            string piecePositions = parts[0];

            string[] fenRows = piecePositions.Split("/");

            for (int i = 0; i < fenRows.Length; i++)
            {
                string row = fenRows[i];
                int rank = 8 - i;
                int fileIndex = 0;

                for (int j = 0; j < row.Length; j++)
                {
                    char fenChar = row[j];

                    if (char.IsDigit(fenChar))
                    {
                        fileIndex += (int)char.GetNumericValue(fenChar);
                    }
                    else
                    {
                        File file = (File)Enum.ToObject(typeof(File), fileIndex);
                        Coordinates coordinates = new Coordinates(file, rank);

                        board.setPiece(coordinates, pieceFactory.fromFenChar(fenChar, coordinates));
                        fileIndex++;
                    }
                }
            }

            return board;
        }
    }
}
