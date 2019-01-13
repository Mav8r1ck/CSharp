using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song
    {
        public int Duration;
        public string Name;
        public Artist Artist;
        public Album Album;
        
        //BL8 -Player3/3.SongGenres
        enum SongGenres
        {
            Classic =   0b00000001,
            Rock =      0b00000010,
            Pop=        0b00000100
        }
        //BL8 -Player 2/3. LikeDislike
        public bool? Like = null;
        public bool? LikeDislike(bool like)
        {
            if(like == true) Like = true;
            else if(like == false) Like = false;
            return Like;
        }
    }
}
