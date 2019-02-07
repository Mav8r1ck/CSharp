using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class PlayerEventArgs
    {
        public string Message { get; }
        public PlayerEventArgs(string mes)
        {
            Message = mes;
        }
    }
}
