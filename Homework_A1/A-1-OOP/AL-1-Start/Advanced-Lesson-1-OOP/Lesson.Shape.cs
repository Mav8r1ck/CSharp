using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_1_OOP
{
    public static partial class Lesson
    {

        public static void AbstractionShapeExample()
        {
            IShape[] shapes = new IShape[]
            {
                new Rectangle(10, 10),
                new Circle(5),
                new Circle(12)
            };

            Print(shapes);
        }

        public static void Print(params IShape[] shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }

    }

    public interface IShape
    {
        void Draw();
    }

    class Rectangle : IShape
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Rectangle {this.width}x{this.height}");
        }
    }


    class Circle : IShape
    {
        private int rad;

        public Circle(int rad)
        {
            this.rad = rad;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Circle R{this.rad}");
        }
    }


    public class Triangle : IShape
    {
        private int a;
        private int b;
        private int c;

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.a = c;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        }
    }

}
