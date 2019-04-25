using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Yandex;

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            UserMenu menu = new UserMenu();
            menu.MenuAsync();
            Console.ReadKey();
        }
    }
}
