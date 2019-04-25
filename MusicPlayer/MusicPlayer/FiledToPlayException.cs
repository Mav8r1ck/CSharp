using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class FiledToPlayException : Exception
    {
        public string _path;
        public FiledToPlayException(string message, string path) : base(message)
        {
            _path = path;
        }
    }
}
