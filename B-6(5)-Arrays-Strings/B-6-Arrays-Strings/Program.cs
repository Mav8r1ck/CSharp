using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array();
            //Matrix();
            //arraySort();
            Pyatnashki();
            Console.ReadLine();
        }

        public static void Array()
        {
            int[] array = new int[6];
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Enter number");
                string temp = Console.ReadLine();
                array[i] = Convert.ToInt32(temp);
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void Matrix()
        {
            int[,] matrix = new int[3, 3] 
            {
                {10, 20, 30},
                {40, 50, 60},
                {70, 80, 90}
            };

            for (int i = 0; i < (matrix.GetUpperBound(0) + 1); i++)
            {
                int max = 0;
                for (int j = 0; j < (matrix.Length / (matrix.GetUpperBound(0) + 1)); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                Console.WriteLine(max);
            }
            //printMatrix(matrix);
        }

        #region printMatrix
        public static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < (matrix.GetUpperBound(0) + 1); i++)
            {
                for (int j = 0; j < (matrix.Length / (matrix.GetUpperBound(0) + 1)); j++)
                {
                    if (matrix[i, j] < 10)
                    {
                        Console.Write($" {matrix[i, j]} ");
                    }
                    else
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                }
                Console.WriteLine();
            }
        }
        #endregion

        public static void arraySort() 
        {
            Random rand = new Random();
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1000);
                Console.Write($"{array[i]} ");
                if (i % 10 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            
            //Bubble sort
            int counter;
            do
            {
                counter = 0;
                for (int i = 0; i < (array.Length - 1); i++)
                {
                    int temp;
                    if (array[i] > array[i + 1])
                    {
                        counter++;
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            } while (counter != 0);
            //End of Bubble sort

            //Print result
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
                if (i % 10 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public static void Pyatnashki()
        {
            Random rand = new Random();
            int[,] gameMatrix = new int[4, 4]
                {
                {20, 20, 20, 20 },
                {20, 20, 20, 20 },
                {20, 20, 20, 20 },
                {20, 20, 20, 20 }
                };
            for (int x = 0; x < 4; x++) //random 
            {
                for (int y = 0; y < 4; y++)
                {
                    Next:
                    int number = rand.Next(16);
                        foreach (int k in gameMatrix)
                        {
                            if (k == number)
                            {
                                goto Next;
                            }
                        }
                        gameMatrix[x, y] = number;
                }
            }
            printMatrix(gameMatrix);
            int zeroXposition = 0;
            int zeroYposition = 0;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if(gameMatrix[y, x] == 0)
                    {
                        zeroXposition = x;
                        zeroYposition = y;
                    }
                }
            }
            bool exitFlug = false;
            while (exitFlug == false)
            {
                var buttom = Console.ReadKey();
                int temp;
                switch (buttom.KeyChar) 
                {
                    case 'W':
                    case 'w':
                        if (zeroYposition >= 1)
                        {
                            temp = gameMatrix[(zeroYposition - 1), zeroXposition];
                            gameMatrix[(zeroYposition - 1), zeroXposition] = gameMatrix[zeroYposition, zeroXposition];
                            gameMatrix[zeroYposition, zeroXposition] = temp;
                            zeroYposition--;
                            Console.Clear();
                            printMatrix(gameMatrix);
                        }
                        else wrongMove();
                        Console.WriteLine("up");
                        break;
                    case 'S':
                    case 's':
                        if (zeroYposition <= 3)
                        {
                            temp = gameMatrix[(zeroYposition + 1), zeroXposition];
                            gameMatrix[(zeroYposition + 1), zeroXposition] = gameMatrix[zeroYposition, zeroXposition];
                            gameMatrix[zeroYposition, zeroXposition] = temp;
                            zeroYposition++;
                            Console.Clear();
                            printMatrix(gameMatrix);
                        }
                        else wrongMove();
                        Console.WriteLine("down");
                        break;
                    case 'A':
                    case 'a':
                        if (zeroXposition >= 1)
                        {
                            temp = gameMatrix[zeroYposition, (zeroXposition - 1)];
                            gameMatrix[zeroYposition, (zeroXposition - 1)] = gameMatrix[zeroYposition, zeroXposition];
                            gameMatrix[zeroYposition, zeroXposition] = temp;
                            zeroXposition--;
                            Console.Clear();
                            printMatrix(gameMatrix);
                        }
                        else wrongMove();
                        Console.WriteLine("left");
                        break;
                    case 'D':
                    case 'd':
                        if (zeroXposition <= 3)
                        {
                            temp = gameMatrix[zeroYposition, (zeroXposition + 1)];
                            gameMatrix[zeroYposition, (zeroXposition + 1)] = gameMatrix[zeroYposition, zeroXposition];
                            gameMatrix[zeroYposition, zeroXposition] = temp;
                            zeroXposition++;
                            Console.Clear();
                            printMatrix(gameMatrix);
                        }
                        else wrongMove();
                        Console.WriteLine("right");
                        break;
                    case 'E':
                    case 'e':
                        exitFlug = true;
                        break;
                    default:
                        wrongMove();
                        break;
                }
            }
        }

        public static void wrongMove()
        {
            Console.WriteLine("You can't do that");
        }
        public static void PoemExample()
        {
            
        }
    }
}
