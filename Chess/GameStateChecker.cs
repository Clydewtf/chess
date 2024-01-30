using Chess.board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class GameStateChecker
    {
        public abstract GameState check(Board board, Color color);
    }
}
