using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Chess.board;
using Chess.piece;

namespace Chess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Board board = new BoardFactory().fromFen(
                "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
                //"4k3/8/5n2/2N5/3B4/8/8/4K3 w - - 0 1"
                //"4k3/7r/8/2P2Q2/8/7P/5r2/4K3 w - - 0 1"
                //"8/8/8/8/6p1/3k1pP1/3p1P2/3K3N w - - 0 1"
                //"rnb1kbnr/pppp1ppp/8/4p3/6Pq/5P2/PPPPP2P/RNBQKBNR w KQkq - 0 1"
                //"k2r3R/8/8/2P1P3/2PKP3/2PPP3/8/8 w - - 0 1"
                );

            ////BoardConsoleRenderer renderer = new BoardConsoleRenderer();
            ////renderer.render(board);

            ////Board board = new Board();
            ////board.setupDefaultPiecesPositions();

            Game game = new Game(board);
            game.gameLoop();
        }
    }
}
