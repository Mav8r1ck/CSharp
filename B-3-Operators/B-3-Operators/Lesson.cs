using System;

namespace B_3_Operators
{
    public partial class Lesson
    {
        public static void Examples()
        {
            #region !~

            //Логические операции делятся на две категории: одни выполняются над логическими значениями операндов, 
            //другие осуществляют выполнение логической операции над битами операндов. По этой причине в C# существуют
            //две унарные операции отрицания - логическое отрицание, заданное операцией «!», и побитовое отрицание,
            // заданное операцией «~». Первая из них определена над операндом типа bool, вторая - над операндом целочисленного типа,
            // начиная с типа int и выше (int, uint, long, ulong). 
            // Результатом операции во втором случае является операнд, в котором каждый бит заменен его дополнением. Приведем пример:            

            bool b1, b2;
            b1 = 2 * 2 == 4;
            b2 = !b1;
            //b2= ~b1;  //NOT COMPILING

            uint j1 = 7, j2;
            j2 = ~j1;
            //j2 = !j1; //NOT COMPILING

            #endregion

            #region checked/unchecked

            // вызывает ошибку т.к переполнение 
            // По умолчанию выражение, содержащее только константные значения, вызывает ошибку компилятора в том случае,
            // если результат его вычисления выходит за допустимые пределы значений конечного типа
            // int result = 2147483647 + 10; // Int32.MaxValue + ten;

            // Ошибки переполения нет т.к используется переменная ten
            // -2,147,483,639 as the sum of 2,147,483,647 and 10.
            int ten = 10;

            int number1 = 2147483647 + ten;
            //int number2 = 2147483647 + 10; //NOT COMPILING

            int checkedNumber;
            int uncheckedNumber;

            checked
            {
                try
                {
                    checkedNumber = Int32.MaxValue + ten;
                    //checkedNumber = Int32.MaxValue + 10; //NOT COMPILING
                }
                catch (Exception)
                {
                }
            }

            unchecked
            {
                uncheckedNumber = Int32.MaxValue + ten;
                uncheckedNumber = Int32.MaxValue + 10;
            }

            #endregion

            #region x++/--y

            Console.WriteLine("#region x++/--y ");

            int x1 = 0, y1 = 10;

            Console.WriteLine(x1++);
            Console.WriteLine(x1);

            Console.WriteLine(--y1);
            Console.WriteLine(y1);

            #endregion

            #region sizeof

            Console.WriteLine("#region sizeof");
            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(bool));

            //Console.WriteLine(sizeof(x1));


            #endregion

            #region typeof

            Console.WriteLine("#region typeof");
            Type type = typeof(char);
            Console.WriteLine(type);

            #endregion
            
            #region /%

            Console.WriteLine("#region /%");
            Console.WriteLine(8 / 5);
            Console.WriteLine(8 % 5);
            Console.WriteLine(8 / 5.0);

            #endregion

            #region +=

            Console.WriteLine("#region +=");

            int x = 3;
            x = x + 5;
            x += 5;

            Console.WriteLine(x);

            #endregion

            #region ??

            Console.WriteLine("#region ??");

            object c = null; // 9;
            object k = c ?? 10;
            if (c != null)
                k = c;
            else k = 10;

            #endregion

            #region >> << операции сдвига

            Console.WriteLine("#region >> << операции сдвига");

            int n = 80, m = 3;
            Console.WriteLine(n >> 4); // разделить нацело на 2 в степени 4 => 5
            Console.WriteLine(m << 5); // умножить на 2 в степени 5 => 96

            #endregion

            #region & even number

            Console.WriteLine("#region &| with numbers");

            int a = 0b0111/*7*/;
            int b = 0b1001/*9*/;

            int d = a & b/*0x0001*//*1*/;
            int e = a | b/*0x1111*//*15*/;
           
            var intNumber = 11;
            if ((intNumber & 1) == 1)
            {
                Console.WriteLine("{0} not even", intNumber);
            }

            #endregion

            #region ?:

            Console.WriteLine("?:");

            int l = 7;
            int f = 4;

            int max = l > f ? l : f;
            Console.WriteLine(max);

            #endregion
        }
    }
}
