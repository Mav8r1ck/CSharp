using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Practice
    {
        /// <summary>
        /// AL3-P1/3. Создать класс UniqueItem c числовым полем Id. 
        /// Каждый раз, когда создается новый экземпляр данного класса, 
        /// его идентификатор должен увеличиваться на 1 относительно последнего созданного. 
        /// Приложение должно поддерживать возможность начать идентификаторы с любого числа. 
        /// </summary>
        public static void AL3_P1_3()
        {
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(100); i++)
            {
                StaticUniqueId a = new StaticUniqueId();
            }
            Console.WriteLine(StaticUniqueId.id);
        }

        /// <summary>
        /// AL3-P2/3. Отредактировать консольное приложение Printer. 
        /// Заменить базовый абстрактный класс на интерфейс.
        /// </summary>
        public static void AL3_P2_3()
        {

        }


        /// <summary>
        /// AL3-P3/3. Создайте обобщенный метод GuessType<T>(T item), 
        /// который будет принимать переменную обобщенного типа и выводить на консоль, 
        /// что это за тип был передан.
        /// </summary>
        public static void AL3_P3_3()
        {

            
        }

        public static void GuessType<T>(T item)
        {
            var type = item.GetType();
            switch (item.GetType().Name)
            {
                case "String":
                    Console.WriteLine($"Item's type is {item.GetType().Name}");
                    break;
                case "Int32":
                    Console.WriteLine($"Item's type is {item.GetType().Name}");
                    break;
                case "UInt32":
                    Console.WriteLine($"Item's type is {item.GetType().Name}");
                    break;
                case "DateTime":
                    Console.WriteLine($"Item's type is {item.GetType().Name}");
                    break;
                default:
                    Console.WriteLine("What does it mean?");
                    break;
            }
        }

        public class StaticUniqueId
        {
            public static int id {get; private set;}
            public string name;

            static StaticUniqueId()
            {
                id = 1000;
            }

            public StaticUniqueId()
            {
                id++;
                Console.WriteLine();
            }
        }
    }    
}
