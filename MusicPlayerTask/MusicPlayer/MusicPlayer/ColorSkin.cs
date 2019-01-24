using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class ColorSkin : ClassicSkin, ISkin
    {
        public ColorSkin(string color) : base()
        {
            ConsoleColor option;
            if(Enum.TryParse(color, out option)) Console.ForegroundColor = option;
            else Console.WriteLine("Unknown color");
        }
    }
}
