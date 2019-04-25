using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class FailedToPlayException : Exception
    {
        public string _path;
        public FailedToPlayException(string message, string path) : base(message)
        {
            _path = path;
        }
    }
}
