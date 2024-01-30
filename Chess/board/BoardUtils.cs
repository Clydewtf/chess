using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.board
{
    public class BoardUtils
    {
        public static List<Coordinates> getDiagonalCoordinatesBetween(Coordinates source, Coordinates target)
        {
            //presumption - squares are on the same diagonal

            List<Coordinates> result = new List<Coordinates>();
            int fileShift = (int)source.file < (int)target.file ? 1 : -1;
            int rankShift = source.rank < target.rank ? 1 : -1;

            for (
                int fileIndex = (int)source.file + fileShift,
                rank = source.rank + rankShift;

                fileIndex != (int)target.file && rank != target.rank;

                fileIndex += fileShift, rank += rankShift
                )
            {
                result.Add(new Coordinates((File)Enum.ToObject(typeof(File), fileIndex), rank));
            }

            return result;
        }

        public static List<Coordinates> getVerticalCoordinatesBetween(Coordinates source, Coordinates target)
        {
            //presumption - squares are on the same vertical

            List<Coordinates> result = new List<Coordinates>();
            int rankShift = source.rank < target.rank ? 1 : -1;

            for (int rank = source.rank + rankShift;
                rank != target.rank; rank += rankShift)
            {
                result.Add(new Coordinates(source.file, rank));
            }

            return result;
        }

        public static List<Coordinates> getHorizontalCoordinatesBetween(Coordinates source, Coordinates target)
        {
            //presumption - squares are on the same horizontal

            List<Coordinates> result = new List<Coordinates>();
            int fileShift = (int)source.file < (int)target.file ? 1 : -1;

            for (
                int fileIndex = (int)source.file + fileShift;
                fileIndex != (int)target.file; fileIndex += fileShift)
            {
                result.Add(new Coordinates((File)Enum.ToObject(typeof(File), fileIndex), source.rank));
            }

            return result;
        }
    }
}
