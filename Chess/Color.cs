using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum Color
    {
        WHITE, BLACK
    }

    public static class ColorExtensions
    {
        public static Color opposite(this Color color)
        {
            return color == Color.WHITE ? Color.BLACK : Color.WHITE;
        }
    }
}
