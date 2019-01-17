using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_8_Struct_Enum_Tuple_Generic
{
    partial class Practice
    {
        public static Random random = new Random();
        public struct Square
        {
            public int height;
            public int lenght;
            public int x;
            public int y;
            public Square(int height, int lenght, int x, int y)
            {
                this.height = height;
                this.lenght = lenght;
                this.x = x;
                this.y = y;
            }
            public static bool operator ==(Square first, Square second)
            {
                return first.Equals(second);
            }
            public static bool operator !=(Square first, Square second)
            {
                return first.Equals(second);
            }
        }

        /// <summary>
        /// BL8-P1/3. Cоздать структуру 2DRectangle, которая будет содержать ширину, высоту и координату.
        /// </summary>
        public static Square Lb8_P1_3()
        {
            Square square0 = new Square(random.Next(10), random.Next(10), random.Next(10), random.Next(10));
            Console.WriteLine($"{square0.height}, {square0.lenght}, {square0.x}, {square0.y}");
            return square0;
        }


        /// <summary>
        /// BL8-P2/3. Cоздать случайный массив квадратов с количеством элементов 100. 
        /// Используйте класс Random(10), чтоб установить значения сторон. 
        /// </summary>
        public static void Lb8_P2_3()
        {
            int duplicate = 0;
            int itemPosition = 0;
            List <Square> squares = new List<Square>();
            for (int i = 0; i < 99; i++)
            {
                squares.Add(Lb8_P1_3());
            }
            foreach (var item in squares)
            {
                for (int i = 0; i < 99; i++)
                {
                    if(itemPosition != i)
                    {
                        //if (item.height == squares[i].height && item.lenght == squares[i].lenght && item.x == squares[i].x && item.y == squares[i].y) duplicate++;
                        if (item == squares[i])
                        {
                            duplicate++;
                        }
                    }
                }
                itemPosition++;
            }
            Console.WriteLine($"Duplicates: {duplicate}");
        }

        /// <summary>
        /// BL8-P3/3.Anonymous. Создать метод GetSongData, 
        /// который принимает обьекта типа Song и возвращает анонимный тип, 
        /// который содержит Title, Minutes, Seconds и AlbumYear. 
        /// </summary>
        public static void Lb8_P3_3_Anonymous()
        {            
        }
    }
}
