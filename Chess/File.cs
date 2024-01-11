using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum File
    {
        A, B, C, D, E, F, G, H
    }

    public static class FileExtensions
    {
        public static File? fromChar(char ch)
        {
            //if (Enum.TryParse<File>(ch.ToString().ToUpper(),
            //    out File result) && Enum.IsDefined(typeof(File), result))
            //{
            //    return (File)result;
            //}
            //else
            //{
            //    return default;
            //}

            try
            {
                return (File)Enum.Parse(typeof(File), ch.ToString().ToUpper());
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
