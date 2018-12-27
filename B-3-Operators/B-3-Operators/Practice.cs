using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_3_Operators
{
    public partial class Practice
    {
        /// <summary>
        /// B3-P1/5. NumbersAddition. Напишите алгоритм, который складывает два числа.
        /// </summary>
        public static void B3_P1_9_NumbersAddition()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Answer: {x+y}");
            Console.ReadKey();
        }

        /// <summary>
        /// B3-P2/9. CheckResultAddition. Изменить предыдущий алгоритм. 
        /// Пускай он теперь не выводит ответ сам. 
        /// А запрашивает ответ и потом проверяет его на правильность.
        /// </summary>
        public static void B3_P2_9_CheckResultAddition()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your answer:");
            int answer = Convert.ToInt32(Console.ReadLine());
            if ((x + y) == answer)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// B3-P3/9. CheckResultAdditionWithTips. Изменить предыдущий алгоритм. 
        /// Пускай он теперь выводит не только информацию правильно или не правильно, 
        /// но и дополнительно, 	ожидается число больше или меньше указанного.
        /// </summary>
        public static void B3_P3_9_CheckResultAdditionWithTips()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your answer:");
            int answer = Convert.ToInt32(Console.ReadLine());
            if ((x + y) == answer)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
                if (answer > (x + y)) Console.WriteLine("Must be less");
                else Console.WriteLine("Must be more");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// B3-P4/9. CheckResultWithOperator. Изменить предыдущий алгоритм. 
        /// Пускай алгоритм теперь запрашивает оператор (+ или -).
        /// </summary>
        public static void B3_P4_9_CheckResultWithOperator()
        {
            int answer, x, y, addPart;

                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your answer:");
                answer = Convert.ToInt32(Console.ReadLine());
            if ((x + y) == answer)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
                if (answer > (x + y))
                {
                    do
                    {
                        Console.WriteLine("Must be less");
                        Console.WriteLine("Enter number for minus");
                        addPart = answer - Convert.ToInt32(Console.ReadLine());
                    } while (addPart != (y + x));
                    Console.WriteLine("True");
                    Console.ReadKey();
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Must be more");
                        Console.WriteLine("Enter number for plus");
                        addPart = answer + Convert.ToInt32(Console.ReadLine());

                    } while (addPart != (y + x));
                    Console.WriteLine("True");
                    Console.ReadKey();
                }
            }
                
        }

        /// <summary>
        /// B3-P5/9. CheckResultWithAttemps. Изменить предыдущий алгоритм. 
        /// Пускай у пользователя будет 3 попытки чтобы решить эту задачу правильно
        /// </summary>
        public static void B3_P5_9_CheckResultWithAttemps()
        {
            int answer, x, y;

            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your answer:");
            answer = Convert.ToInt32(Console.ReadLine());
            if ((x + y) == answer)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
                if (answer > (x + y))
                {
                    int addPart = 0;
                    int attempt= 0;
                    while (attempt != 3)
                    {
                        attempt++;
                        Console.WriteLine("Must be less");
                        Console.WriteLine("Enter number for minus");
                        addPart = answer - Convert.ToInt32(Console.ReadLine());
                        if (addPart == (x + y)) break;
                    };
                    if (addPart == (x + y)) Console.WriteLine("True");
                    else Console.WriteLine("You had three attempts only");
                    Console.ReadKey();
                }
                else
                {
                    int addPart = 0;
                    int attempt = 0;
                    while (attempt != 3)
                    {
                        attempt++;
                        Console.WriteLine("Must be less");
                        Console.WriteLine("Enter number for minus");
                        addPart = answer + Convert.ToInt32(Console.ReadLine());
                        if (addPart == (x + y)) break;
                    };
                    if (addPart == (x + y)) Console.WriteLine("True");
                    else Console.WriteLine("You had three attempts only");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// B3-P6/9. FiveNumbersAddition. Изменить предыдущий алгоритм. 
        /// Пускай алгоритм складывает пять чисел вместо двух.
        /// </summary>
        public static void B3_P6_9_FiveNumbersAddition()
        {
            int answer, y;
            int x = 0;
            Console.WriteLine("Enter five numbers");
            for(int index = 0; index < 5; index++) x += Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your answer:");
            answer = Convert.ToInt32(Console.ReadLine());
            if ((x) == answer)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
                if (answer > (x))
                {
                    int addPart = 0;
                    int attempt = 0;
                    while (attempt != 2)
                    {
                        attempt++;
                        Console.WriteLine("Must be less");
                        Console.WriteLine("Enter number for minus");
                        addPart = answer - Convert.ToInt32(Console.ReadLine());
                        if (addPart == (x)) break;
                    };
                    if (addPart == (x)) Console.WriteLine("True");
                    else Console.WriteLine("You had three attempts only");
                    Console.ReadKey();
                }
                else
                {
                    int addPart = 0;
                    int attempt = 0;
                    while (attempt != 2)
                    {
                        attempt++;
                        Console.WriteLine("Must be less");
                        Console.WriteLine("Enter number for minus");
                        addPart = answer + Convert.ToInt32(Console.ReadLine());
                        if (addPart == (x)) break;
                    };
                    if (addPart == (x)) Console.WriteLine("True");
                    else Console.WriteLine("You had three attempts only");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// B3-P7/9. NumbersResultWithInfoIfCorrect. Изменить предыдущий алгоритм. 
        /// В конце алгоритма выводить информацию была ли задача решена правильно.
        /// </summary>
        public static void B3_P7_9_NumbersResultWithInfoIfCorrect()
        {
            //I've done it. Could you see the end of previous method?
        }

        /// <summary>
        /// B3-P8/9. CircleArea. Написать алгоритм, рассчитывающий площадь круга по заданному радиусу. 
        /// </summary>
        public static void B3_P8_9_CircleArea()
        {
            Console.WriteLine("Enter radius");
            double x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(x * x * Math.PI);
            Console.ReadKey();
        }

        /// <summary>
        /// B3-P9/9. CreaditCalculator.Написать программу - калькулятор кредита на 1 год.
        /// </summary>
        public static void B3_P9_9_CreaditCalculator()
        {
            Console.WriteLine("Enter amount of credit");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter rate of credit");
            decimal rate = Convert.ToDecimal(Console.ReadLine());
            decimal amountForMonth = amount / 12;
            decimal ratePerMonth = rate / 12;
            decimal sumForYear = 0;
            for (int month = 1; month <= 12; month++)
            {
                decimal inMonth = amountForMonth + (amount * (ratePerMonth / 100));
                amount -= inMonth;
                sumForYear += inMonth ;
                Console.WriteLine($"For month {month} = {Math.Round(inMonth, 2, MidpointRounding.AwayFromZero)}");
            }

            Console.WriteLine($"Total amount {Math.Round(sumForYear, 2, MidpointRounding.AwayFromZero)}");
            Console.ReadKey();
          
        }
    }
}
