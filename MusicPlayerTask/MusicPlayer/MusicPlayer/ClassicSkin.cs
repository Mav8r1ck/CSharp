using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class ClassicSkin : ISkin
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}
