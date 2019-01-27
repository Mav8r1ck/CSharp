using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Lesson_1_OOP.InternetShop;

namespace Advanced_Lesson_1_OOP
{
    public class Practice
    {
        /// <summary>
        /// A.L1.P1. Вывести матрицу (двумерный массив) отображающую площадь круга, 
        /// квадрата, равнобедренного треугольника со сторонами (радиусами) от 1 до 10.
        /// </summary>
        public static void A_L1_P1_OOP()
        {
            Circle c1 = new Circle(10);
            Circle c2 = new Circle(15);
            Square s1 = new Square(10, 15);
            Square s2 = new Square(25, 10);
            var arr = new Figure[]  {c1, c2, s1, s2};
            foreach (var f in arr)
            {
                Console.WriteLine(f.CalculateArea());
            }
        }

        public class Figure
        {
            public virtual double CalculateArea()
            {
                return 2.4;
            }
        }

        public class Circle : Figure
        {
            private int rad { get; set; }
            public Circle(int rad)
            {
                this.rad = rad;
            }
            public override double CalculateArea()
            {
                return Math.PI * rad * rad;
            }
        }

        public class Square : Figure
        {
            private int height{get; set;}
            private int width { get; set; }
            public Square(int height, int width)
            {
                this.height = height;
                this.width = width;
            }
            public override double CalculateArea()
            {
                return height*width;
            }
        }

        /// <summary>
        /// A.L1.P6. Перегрузить следующие операторы для Transport <>,==/!= на базе физических размеров. 
        /// Продемонстрировать использование в коде. 
        /// </summary>
        public static void A_L1_P6_OperatorsOverloading()
        {
            FuelCar car1 = new FuelCar(2.5f);
            FuelCar car2 = new FuelCar(1.9f);
            FuelCar car3 = new FuelCar(2.2f);

            if (car1 > car2) Console.WriteLine("Car1 bigger");
            if (car1 != car3) Console.WriteLine("That cars is different");
        }

        /// <summary>
        /// A.L1.P7.Перегрузить операторы<>,==/!=  для продаваемых вещей в интернет магазине на базе их цены. 
        /// Продемонстрировать использование в коде. 
        /// </summary>
        public static void A_L1_P7_OperatorsOverloading()
        {
            Article a1 = new Article("boots", 10, 2.50m);
            Article a2 = new Article("t-shirt", 10, 13.20m);
            bool result = (a1 > a2);
            Console.WriteLine(result);
            result = (a1 == a2);
            Console.WriteLine(result);
        }        
    }
}
