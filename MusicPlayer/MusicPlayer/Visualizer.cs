using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Visualizer
    {
        private UserCommands result;
        private bool flag = false;
        private ISkin skin;
        internal ISkin Skin { get => skin; set => skin = value; }
        public Visualizer(Player player, string color)
        {
            if(color != null)
            {
                Skin = new ColorSkin(color);
            }
            else
            {
                Skin = new ClassicSkin();
            }
            player.PlayerLockedUnlocked += Show_Message;
            player.PlayerStarted += Show_Message;
            player.PlayerStopped += Show_Message;
            player.SongsListChanged += Show_Message;
            player.VolumeChanged += Show_Message;
            player.SongStarted += Show_Message;
            player.OnError += Show_Message;
            player.OnWarning += Show_MessageForOnWarning;
            //WaitForCommands(player);
        }

        private static void Show_Message(object sender, PlayerEventArgs item)
        {
            Console.WriteLine(item.Message);
        }

        private static void Show_MessageForOnWarning(object sender, PlayerEventArgs item)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(item.Message);
            Console.ResetColor();
        }

        public void WaitForCommands(Player player)              //PlayerLA8.Player 2/2**2**2**.AsyncCommands
        {
            Console.WriteLine($"You have commands: {UserCommands.Start} push (1), {UserCommands.Stop} push (2), {UserCommands.LoadPlaylist} push (3), {UserCommands.LoadFolder} push (4), push (0) for Exit");
            while (!flag)
            {
                string userChoice = Console.ReadLine();
                if (Enum.TryParse(userChoice, out result))
                {
                    switch (result)
                    {
                        case UserCommands.Start:
                            player.Play();

                            break;
                        case UserCommands.Stop:
                            player.Stop();
                            flag = true;
                            break;
                        case UserCommands.LoadPlaylist:
                            player.LoadPlaylist();

                            break;
                        case UserCommands.LoadFolder:
                            Console.WriteLine("Enter directory for load");
                            player.Load(Console.ReadLine());

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
        Start = 0x01,
        Stop = 0x02,
        LoadPlaylist = 0x03,
        LoadFolder = 0x04
    }
}
