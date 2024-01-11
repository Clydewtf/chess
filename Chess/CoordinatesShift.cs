using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class CoordinatesShift
    {
        private readonly int _fileShift;
        private readonly int _rankShift;

        public int fileShift
        {
            get { return _fileShift; }
        }
        public int rankShift
        {
            get { return _rankShift; }
        }

        public CoordinatesShift(int fileShift, int rankShift)
        {
            _fileShift = fileShift;
            _rankShift = rankShift;
        }
    }
}
