using MusicPlayer.Extantions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer 
{
    public class Player : GenericPlayer<Song>
    {


        public Player(): base()
        {

        }

        public Player(string color) : base(color)
        {

        }

        public override void Play()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = true;
            foreach (var song in Items)
            {
                if (song.Like == true) Console.ForegroundColor = ConsoleColor.Green;     //BL8 -Player 2/3. LikeDislike
                else if (song.Like == false) Console.ForegroundColor = ConsoleColor.Red;

                //L9 -HW -Player -2/3

                Skin.Render($"Player is playing: {song.Name.PlayerSubstring()}, genre: {song.Artist.Genre.PlayerSubstring()}"); 
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void Play(bool loop) //B7-Player1/2. SongsListShuffle
        {
            if (loop == false) Play();
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Play();
                }
            }
        }

        public override void Play(List<Song> filteredSongs)          //BL8-Player4/4. FilterByGenre
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = true;
            if (filteredSongs.Count() == 0) Skin.Render("Nothing for play");
            else
            {
                Skin.Render("Filtered list");
                foreach (var song in Items)
                {
                    if (song.Like == true) Console.ForegroundColor = ConsoleColor.Green;     //BL8 -Player 2/3. LikeDislike
                    else if (song.Like == false) Console.ForegroundColor = ConsoleColor.Red;

                    //L9 -HW -Player -2/3

                    Skin.Render($"Player is playing: {song.Name.PlayerSubstring()}, genre: {song.Artist.Genre.PlayerSubstring()}");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        

        

        //B7-Player2/2. SongsListSort
        public void SongsListSort()
        {
            this.Items = this.Items.SortSongs();                        //L9 -HW -Player -1/3    
        }

        public Tuple<string, int, int, int> GetSongData(Song song)      //BL8 -Player1/3.SongTuples
        {
            var ts = TimeSpan.FromSeconds(song.Duration);
            return new Tuple<string, int, int, int>(
                    song.Name,
                    ts.Hours,
                    ts.Minutes,
                    ts.Seconds
                );
        }

        public void ListSong()                      //BL8 -Player1/3.SongTuples
        {
            foreach (var song in Items)
            {
                Tuple<string, int, int, int> songData = GetSongData(song);
                Skin.Render($"Name: {songData.Item1}, Time: {songData.Item2}:{songData.Item3}:{songData.Item4}");
            }
            Skin.Clear();
        }

        public List<Song> FilterByGenre(string genre)                       //BL8-Player4/4. FilterByGenre
        {
            Song.SongGenres option;
            List<Song> filteredSongs = new List<Song>();
            foreach (var song in Items)
            {
                if(Enum.TryParse(genre, out option))
                {
                    if(Enum.IsDefined(typeof(Song.SongGenres), option))
                    {
                        filteredSongs.Add(song);
                    }
                }
            }
            return filteredSongs;
        }
    }
}
