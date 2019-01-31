using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Yandex;


namespace ImageProcessing
{
    public class UserMenu : ImageProcessing
    {   
        private bool flag = false;
        //public UserCommands commands;

        public async Task MenuAsync()
        {
            Console.WriteLine($"You have commands: {UserCommands.RenameByDate} push (1), {UserCommands.AddDateOnFoto} push (2), {UserCommands.SortByYear} push (3), {UserCommands.SortByPlace} push (4), push (0) for Exit");
            string userChoice = Console.ReadLine();
            if (Enum.TryParse(userChoice, out result))
            {
                while (!flag)
                {
                    switch (result)
                    {
                        case UserCommands.RenameByDate:         //Переименование изображении в соответствии с датой сьемки
                            MakeSubDirectory();
                            RenameByDate();
                            flag = true;
                            break;
                        case UserCommands.AddDateOnFoto:        //Добавления на изображение отметку, когда фото было сделано
                            MakeSubDirectory();
                            PrintDateToImage();
                            flag = true;
                            break;
                        case UserCommands.SortByYear:           //*Сортировка изображений по папкам по годам
                            MakeSubDirectory();
                            SortImagesByYear();
                            flag = true;
                            break;
                        case UserCommands.SortByPlace:          //***Сортировка изображений по папкам по месту сьемки
                            MakeSubDirectory();
                            await SortByPlaceAsync();
                            flag = true;
                            break;
                        case UserCommands.Exit:
                            flag = true;
                            break;
                        default:
                            Console.WriteLine("Unknown command");
                            break;
                    }
                }
            }            
        }
    }

    public enum UserCommands : byte
    {
        Exit = 0,
        RenameByDate = 0x01,
        AddDateOnFoto = 0x02,
        SortByYear = 0x03,
        SortByPlace = 0x04
    }
}
