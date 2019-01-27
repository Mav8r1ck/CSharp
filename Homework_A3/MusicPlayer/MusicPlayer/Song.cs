using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song : PlayingItem
    {
        
        public Artist Artist;
        public Album Album;
        
        public SongGenres genre;
        //BL8 -Player3/3.SongGenres
        public enum SongGenres
        {
            Classic = 0b00000001,
            Rock = 0b00000010,
            Pop = 0b00000100
        }
    }
}
