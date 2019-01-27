using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
        class Program
        {
            static void Main(string[] args)
            {

            //Practice.AL3_P1_3();

            //AL3-P3/3 GuessType

            Practice.GuessType<uint>(12345);
            Practice.GuessType<int>(-12345);
            Practice.GuessType<string>("12345");
            Practice.GuessType<DateTime>(DateTime.Now);
            //Lesson.RentPointsExample();

            Console.ReadLine();
            }
        }

        

}
