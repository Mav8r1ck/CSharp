using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Lesson_4._1
{
    partial class Lesson
    {
        public static void LessonExampleFor()
        {
            Console.WriteLine("Type number1");
            var number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type number2");
            var number2 = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Type result");
                var result = Convert.ToInt32(Console.ReadLine());

                if ((number1 + number2) != result)
                {
                    Console.WriteLine("Incorrect");
                    continue;
                }

                Console.WriteLine("Coorect");
                break;
            }

           
        }

        public static void LessonExampleWhile()
        {
            Console.WriteLine("Type number1");
            var number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type number2");
            var number2 = Convert.ToInt32(Console.ReadLine());

            int attempts = 2;
            bool coorect = false;


            do
            {
                Console.WriteLine("Type result");
                var result = Convert.ToInt32(Console.ReadLine());

                attempts--;

                if ((number1 + number2) != result)
                {
                    Console.WriteLine("Correct");
                    coorect = true;
                }
                else
                {
                    Console.WriteLine("Incorrect");
                }

            } while (!coorect && attempts != 0);
        }

        public static void Switch_OddEven_Example()
        {
            var i = int.Parse(Console.ReadLine());

            switch (i % 2)
            {
                case 0:
                    Console.Write("Number is an even number");
                    break;

                case 1:
                    Console.Write("Number is an odd number");
                    break;
            }
        }

        public static void Switch_LessGreater_Example()
        {
            int y = 2;
            int x = 6;

            switch (y - x)
            {
                case int r when r > 0:
                    Console.WriteLine("y > x");
                    break;

                case int r when r < 0:
                    Console.WriteLine("y < x");
                    break;

                case int r when r == 0:
                    Console.WriteLine("y == x");
                    break;

                default:
                    break;
            }
        }

        public static void CyclesExample()
        {
            #region for

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }

            #endregion

            #region foreach

            var numbers = new List<int> { 0, 1, 2, 3, 4 };

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            #endregion

            #region while

            int n = 0;

            while (n < 5)
            {
                Console.WriteLine(n);
                n++;
            }

            #endregion

            #region do/while

            int m = 0;

            do
            {
                Console.WriteLine(m);
                m++;
            } while (m < 5);


            #endregion
        }

        public static void ForVariations()
        {
            #region Multiple cycle variables

            for (int i = 0, j = 10; i < j; i++, j--)
                Console.WriteLine($"Элементы {i},{j}");


            #endregion

            #region Condition

            var flag = true;
            for (int i = 0; flag; i++)
            {
                if (i == 5) flag = false;
            }

            #endregion

            #region Missed Iteration

            for (int i = 0; i < 30;)
            {
                i += 3;
                Console.WriteLine($"Значение i = {i}");
            }

            #endregion

            #region Infinite loop

            for (int i = 0; ;)
            {
                i++;
                Console.WriteLine($"Значение i = {i}");
                if (i == 1000) break;
            }

            #endregion

            #region Without body

            int sum = 0;
            for (int i = 0; i < 10; sum += i++);

            #endregion
        }

        public static void ForeachExample()
        {
            String word = "word";
            foreach (Char letter in word)
            {
                Console.WriteLine(letter);
            }
        }

        public static void TransitionOperatorsExamples()
        {
            #region break vs continue

            for (int i = 1; i <= 10; i++)
            {
                if (i == 5) { break; }
                Console.WriteLine(i);

            }

            for (int i = 1; i <= 10; i++)
            {
                if (i == 5) { continue; }
                Console.WriteLine(i);

            }

            #endregion

            #region break vs return + throw

            math(1, 3, "+");
            math(1, 3, "~");

            Console.WriteLine(math2(1, 3, "+"));
            Console.WriteLine(math2(1, 3, "~"));

            #endregion
        }

        public static void math(int a, int b, string operand)
        {
            var result = 0;

            switch (operand)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;

                default: Console.WriteLine("Not supported operation"); break;
            }

            Console.WriteLine(result);
        }

        public static int math2(int a, int b, string operand)
        {
            switch (operand)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;

                default: throw new Exception("Not supported operation");
            }
        }


    }
}

