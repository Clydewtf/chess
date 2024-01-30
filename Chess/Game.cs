using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.board;
using Chess.piece;

namespace Chess
{
    public class Game
    {
        private readonly Board _board;
        protected BoardConsoleRenderer renderer = new BoardConsoleRenderer();
        protected List<GameStateChecker> checkers = new List<GameStateChecker> {
            new StalemateGameStateChecker(),
            new CheckmateGameStateChecker()
        };
        protected Board board { get { return _board; } }

        public Game(Board board)
        { 
            _board = board;
        }
        public void gameLoop()
        {
            Color colorToMove = Color.WHITE;
            GameState state = determineGameState(board, colorToMove);

            while (state == GameState.ONGOING)
            {
                //render
                renderer.render(board);

                if (colorToMove == Color.WHITE)
                {
                    Console.WriteLine("White to move");
                }
                else
                {
                    Console.WriteLine("Black to move");
                }

                //input
                Move move = InputCoordinates.inputMove(board, colorToMove, renderer);

                //make move
                board.makeMove(move);

                //pass move
                colorToMove = colorToMove.opposite();

                state = determineGameState(board, colorToMove);
            }

            renderer.render(board);
            Console.WriteLine("Game ended with state = " + state);
        }

        private GameState determineGameState(Board board, Color color)
        {
            foreach (GameStateChecker checker in checkers)
            {
                GameState state = checker.check(board, color);

                if (state != GameState.ONGOING)
                {
                    return state;
                }
            }

            return GameState.ONGOING;
        }
    }
}
