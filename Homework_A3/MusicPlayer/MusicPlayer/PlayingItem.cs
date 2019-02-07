using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class PlayingItem
    {
        public int Duration;
        public string Name;
        public bool? Like = null;
        //BL8 -Player 2/3. LikeDislike
        public bool? LikeDislike(bool like)
        {
            return Like = like;
        }
    }
}
