using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.board
{
    public class Move
    {
        private readonly Coordinates _from, _to;
        public Coordinates from { get { return _from; } }
        public Coordinates to { get { return _to; } }

        public Move(Coordinates from, Coordinates to)
        {
            _from = from;
            _to = to;
        }
    }
}
