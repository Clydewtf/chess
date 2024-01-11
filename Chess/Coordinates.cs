using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Coordinates
    {
        private readonly File _file;
        private readonly int _rank;
        public File file
        {
            get { return _file; }
        }
        public int rank
        {
            get { return _rank; }
        }

        public Coordinates(File file, int rank)
        {
            _file = file;
            _rank = rank;
        }

        public Coordinates shift(CoordinatesShift shift)
        {
            return new Coordinates((File)(((int)_file + shift.fileShift)
                % Enum.GetValues(typeof(File)).Length), _rank + shift.rankShift);
        }

        public bool canShift(CoordinatesShift shift)
        {
            int f = (int)_file + shift.fileShift;
            int r = (int)_rank + shift.rankShift;

            if ((f < 0) || (f > 7)) return false;
            if ((r < 1) || (r > 8)) return false;

            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coordinates other = (Coordinates)obj;
            return file == other.file && rank == other.rank;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + file.GetHashCode();
                hash = hash * 23 + rank.GetHashCode();
                return hash;
            }
        }
    }
}
