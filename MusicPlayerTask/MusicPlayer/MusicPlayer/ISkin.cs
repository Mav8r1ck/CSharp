using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    interface ISkin
    {
        void Clear();
        void Render(string text);
    }
}
