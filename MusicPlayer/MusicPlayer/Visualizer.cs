using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Visualizer
    {
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
        }

        private static void Show_Message(object sender, PlayerEventArgs item)
        {
            Console.WriteLine(item.Message);
        }
    }
}
