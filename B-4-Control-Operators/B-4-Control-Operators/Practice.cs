using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Lesson_4._1
{
    partial class Practice
    {
        //B4-P1/25. If_TimeOfDayGreeting
        public static void B4_P1_25_If_TimeOfDayGreeting()
        {
            var today = DateTime.Now;
            if (today.Hour <= 8 && today.Hour >= 5) Console.WriteLine("Good morning, Olya!");
            else if (today.Hour <= 17) Console.WriteLine("Good day, Olya!");
            else if (today.Hour <= 23) Console.WriteLine("Good evening, Olya!");
            Console.ReadKey();
        }

        //B4-P2/25. If_NumbersComparing
        public static void B4_P2_25_If_NumbersComparing()
        {
            Console.WriteLine("Enter first number");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int y = Convert.ToInt32(Console.ReadLine());
            if (x == y) Console.WriteLine("Equal");
            else if (x < y) Console.WriteLine($"{x} less than {y}");
            else Console.WriteLine($"{x} more than {y}");
        }

        //B4-P3/25. If_PositiveNumbersComparing
        public static void B4_P3_25_If_PositiveNumbersComparing()
        {
            Console.WriteLine("Enter first number");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int y = Convert.ToInt32(Console.ReadLine());
            if (x >= 0 && y > 0)
            {
                if (x == y) Console.WriteLine("Equal");
                else if (x < y) Console.WriteLine($"{x} less than {y}");
                else Console.WriteLine($"{x} more than {y}");
            }
        }

        //B4-P4/25. If_Akinator5Numbers
        public static void B4_P4_25_If_Akinator5Numbers()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string yesNo = "N";
            for (int i = 0; i < 5; i++)
            {
                WrongSymbol:
                Console.WriteLine($"Is that number {numbers[i]}?");
                yesNo = Console.ReadLine();
                if (yesNo == "N" || yesNo =="n") continue;
                else if (yesNo == "Y" || yesNo == "y")
                {
                    Console.WriteLine($"Your number is {numbers[i]}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Wrong symbol");
                    goto WrongSymbol;
                }
            }
        }

        //B4-P5/25. Switch_DayOfWeek
        public static void B4_P5_25_Switch_DayOfWeek()
        {
            var today = DateTime.Today;
            var dayOfWeek = (int)today.DayOfWeek;
            switch (dayOfWeek - 1) {
                case 0:
                    Console.WriteLine("Доброго понедельника, Ольга");
                    break;
                case 1:
                    Console.WriteLine("Доброго вторника, Ольга");
                    break;
                case 2:
                    Console.WriteLine("Доброй среды, Ольга");
                    break;
                case 3:
                    Console.WriteLine("Доброго четверга, Ольга");
                    break;
                case 4:
                    Console.WriteLine("Доброй пятницы, Ольга");
                    break;
                case 5:
                    Console.WriteLine("Доброй субботы, Ольга");
                    break;
                case 6:
                    Console.WriteLine("Доброго воскресенья, Ольга");
                    break;
            }
        }

        //B4-P6/25. Switch_GameNavigation
        public static void B4_P6_25_Switch_GameNavigation()
        {
            LabelStart:

            var buttom = Console.ReadKey();
            switch (buttom.KeyChar)
            {
                case 'W':
                case 'w':
                    Console.WriteLine("Верх");
                    break;
                case 'S':
                case 's':
                    Console.WriteLine("Низ");
                    break;
                case 'A':
                case 'a':
                    Console.WriteLine("Лево");
                    break;
                case 'D':
                case 'd':
                    Console.WriteLine("Право");
                    break;
                default:
                    Console.WriteLine("Куда прешь?");
                    break;
            }

            goto LabelStart;
        }

        //B4-P7/25. For_10OddEven
        public static void B4_P7_25_For_10OddEven()
        {
            for(int index = 1; index <= 10; index++)
            {
                if (index % 2 == 0) Console.WriteLine(index);
            }
        }


        //B4-P8/25. For_3DevideNumbers
        public static void B4_P8_25_For_3DevideNumbers()
        {
            for (int index = 30; index >= 0; index--)
            {
                if (index % 3 == 0) Console.WriteLine(index);
            }
        }


        //B4-P9/25. For_Matrix10x10
        public static void B4_P9_25_For_Matrix10x10()
        {
            int[,] matrix = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Console.Write(matrix[i, y]);
                }
                Console.WriteLine();
            }
        }


        //B4-P10/25. For_HelloWorld
        public static void B4_P10_25_For_HelloWorld()
        {
        }


        //B4_P11/25. For_Afrochildren
        public static void B4_P11_25_For_Afrochildren()
        {
            
        }


        //B4-P12/25. For_Minus10OddEven
        public static void B4_P12_25_For_Minus10OddEven()
        {
        }


        //B4-P13/25 For_LettersCount
        public static void B4_P13_25_For_LettersCount()
        {
            
        }


        //B4-P14/25 *For_AlphabetBack
        public static void B4_P14_25_For_AlphabetBack()
        {
            for (int i = 90; i >= 65; i--)
            {
                Console.Write((char)i);
            }
        }


        //B4-P15/25 While_OddEventNumber
        public static void B4_P15_25_While_OddEventNumber()
        {
            
        }


        //B4-P16/25 DoWhile_OddEventNumber
        public static void B4_P16_25_DoWhile_OddEventNumber()
        {
           
        }


        //B4-P17/25 While_HelloWorld
        public static void B4_P17_25_While_HelloWorld()
        {
        }


        //B4-P18/25 While_Multiplier
        public static void B4_P18_25_While_Multiplier()
        {
            
        }


        //B4-P19/25 While_SolveNumberAdding
        public static void B4_P19_25_While_SolveNumberAdding()
        {
            
        }


        //B4-P20/25 While_DiceGame
        public static void B4_P20_25_While_DiceGame()
        {
            
        }


        //B4-P21/25 *While_DiceGameMultiplePlayers
        public static void B4_P21_25_While_DiceGameMultiplePlayers()
        {
            const int endGame = 25;
            string firtsPlayer = "Player1";
            string secondPlayer = "Player2";
            int firstPlayerScore = 0;
            int secondPlayerScore = 0;
            ConsoleKeyInfo cki;
            Console.WriteLine($"Enter 1 for {firtsPlayer}, Enter 2 for {secondPlayer}, Enter ESC for Exit");

            do
            {
                if (firstPlayerScore == endGame || secondPlayerScore == endGame) break;
                else
                {
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine($"The {firtsPlayer}'s bones value {BonesRandom(ref firstPlayerScore)}, total score {firstPlayerScore}");
                    }
                    if (cki.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine($"The {secondPlayer}'s bones value {BonesRandom(ref secondPlayerScore)}, total score {secondPlayerScore}");
                    }
                }
            } while (cki.Key != ConsoleKey.Escape);
            if (firstPlayerScore > secondPlayerScore) Console.WriteLine($"The {firtsPlayer} is WINNER!!!");
            else Console.WriteLine($"The {secondPlayer} is WINNER!!!");
        }
        #region DiceGame
        public static int BonesRandom(ref int playersScore)
        {
            Random rnd = new Random();
            int bonesValue = rnd.Next(1, 6);
            playersScore += bonesValue;
            return bonesValue; 
        }
        #endregion

        //B4-P22_25 *While_Akinator100Numbers
        public static void B4_P22_25_While_Akinator100Numbers()
        {
            bool flag = false;
            int min = 1;
            int max = 100;
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = i + 1;
            }
            while (flag == false)
            {
                double average = averageFunction(min, max, array); //нахождение середины диапазона
                Console.WriteLine($"Is that number {average}?");
                string answerKey = answer();
                if (answerKey == "Y"|| answerKey == "y")
                {
                    Console.WriteLine($"Your number is {average}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Is that number more than {average}?");
                    answerKey = answer();
                    if (answerKey == "Y" || answerKey == "y")
                    {
                        min = (int)average;
                    }
                    else
                    {
                        max = (int)average;
                    }
                }
            }
            Console.ReadLine();
        }
        #region Akinator
        public static double averageFunction(int min, int max, params int[] array) //нахождение середины диапазона
        {
            double average = 0;
            int quantityOfNumbers = 0;
            for (int i = (min - 1); i < max; i++)
            {
                quantityOfNumbers++;
                average += array[i]; 
            }
            return Math.Round((average/quantityOfNumbers), 0);
        }

        public static string answer() //чтение ответа пользователя
        {
            string answer = Console.ReadLine();
            return answer;
        }
        #endregion

        //B4-P23/25 IfElse_Calcultor
        public static void B4_P23_25_IfElse_Calcultor()
        {
            
        }


        //B4-P24_25 Switch_Calculator
        public static void B4_P24_25_Switch_Calculator()
        {
            
        }


        //B4-P25/25 Cycle_WordRevercse
        public static void B4_P25_25_Cycle_WordRevercse()
        {
        }
    }
}
