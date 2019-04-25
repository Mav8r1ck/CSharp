using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Lesson_6_Multithreading
{
    class Practice
    {      
        /// <summary>
        /// LA8.P1/X. Написать консольные часы, которые можно останавливать и запускать с 
        /// консоли без перезапуска приложения.
        /// </summary>
        public static void LA8_P1_5()
        {
            var timeThread = new Thread(() =>{
            while (true)
            {

                Console.WriteLine(DateTime.Now);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        });
            timeThread.Start();
            while (true)
            {
                if(Console.ReadKey().KeyChar == '1')
                {
                    timeThread.Suspend();
                }
                else if (Console.ReadKey().KeyChar == '2')
                {
                    timeThread.Resume();
                }
            }
        }

        /// <summary>
        /// LA8.P2/X. Написать консольное приложение, которое “делает массовую рассылку”. 
        /// </summary>
        public static void LA8_P2_5()
        {
            string workDirectory = @"D:\TempForTasks";
            string text = "ubqqiubcbbweoinwoin";
            var rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem((object state)=> 
                {
                    string mailWay = workDirectory + $@"\{i}.txt";
                    using (FileStream fs = new FileStream(mailWay, FileMode.OpenOrCreate))
                    {
                        byte[] input = Encoding.Default.GetBytes(text);
                        fs.Write(input, 0, input.Length);
                    }
                    Thread.Sleep(rand.Next(1000));
                });
            }
        }

        /// <summary>
        /// Написать код, который в цикле (10 итераций) эмулирует посещение 
        /// сайта увеличивая на единицу количество посещений для каждой из страниц.  
        /// </summary>
        public static void LA8_P3_5()
        {            
        }

        /// <summary>
        /// LA8.P4/X. Отредактировать приложение по “рассылке” “писем”. 
        /// Сохранять все “тела” “писем” в один файл. Использовать блокировку потоков, чтобы избежать проблем синхронизации.  
        /// </summary>
        public static void LA8_P4_5()
        {
            string workDirectory = @"D:\TempForTasks";
            string text = "ubqqiubcbbweoinwoin";
            var rand = new Random();
            string mailWay = workDirectory + $@"\sendMail.txt";
            var mutex = new Mutex();
            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    mutex.WaitOne();
                    using (FileStream fs = new FileStream(mailWay, FileMode.OpenOrCreate))
                    {
                        fs.Seek(0, SeekOrigin.End);
                        byte[] input = Encoding.Default.GetBytes(text);
                        fs.Write(input, 0, input.Length);
                    }
                    mutex.ReleaseMutex();
                    Thread.Sleep(rand.Next(1000));
                });
            }
        }

        /// <summary>
        /// LA8.P5/5. Асинхронная “отсылка” “письма” с блокировкой вызывающего потока 
        /// и информировании об окончании рассылки (вывод на консоль информации 
        /// удачно ли завершилась отсылка). 
        /// </summary>
        public async static void LA8_P5_5()
        {           
        }
    }    
}
