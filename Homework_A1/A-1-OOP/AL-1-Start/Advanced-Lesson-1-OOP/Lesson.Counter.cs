using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_1_OOP
{
    public static partial class Lesson
    {

        public static void OverloadingExample()
        {
            Counter c1 = new Counter { Value = 23 };
            Counter c2 = new Counter { Value = 45 };

            Counter c3 = c1 + c2;

            c1++;
            c2--;

            bool compare = c1 > c2;

            Console.WriteLine($"c1 = {c1.Value}");
            Console.WriteLine($"c2 = {c2.Value}");
            Console.WriteLine($"c3 = {c3.Value}");
            Console.WriteLine($"c1 > c2 = {compare}");           
        }        
    }

    class Counter
    {
        public int Value { get; set; }

        public void Reset()
        {
            this.Value = 0;
        }

        public static Counter operator ++(Counter c1)
        {
            return new Counter { Value = c1.Value + 1 };
        }

        public static Counter operator --(Counter c1)
        {
            return new Counter { Value = c1.Value - 1 };
        }

        public static Counter operator +(Counter c1, Counter c2)
        {
            return new Counter { Value = c1.Value + c2.Value };
        }
        public static bool operator >(Counter c1, Counter c2)
        {
            return c1.Value > c2.Value;
        }
        public static bool operator <(Counter c1, Counter c2)
        {
            return c1.Value < c2.Value;
        }
    }

}
