using MusicPlayer.Extantions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Player
    {
        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 100;

        private bool _isLocked;

        private bool _isPlaying;


        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }

            private set
            {
                if (value < MIN_VOLUME)
                {
                    _volume = MIN_VOLUME;
                }
                else if (value > MAX_VOLUME)
                {
                    _volume = MAX_VOLUME;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public List<Song> Songs { get; private set; } //B7-Player1/2. SongsListShuffle

        public void VolumeUp()
        {
            if (_isLocked == false)
            {
                Volume++;
            }
        }

        public void VolumeDown()
        {
            if (_isLocked == false)
            {
                Volume--;
            }
        }

        public void VolumeChange(int step)
        {
            if (_isLocked == false)
            {
                Volume += step;
            }
        }

        public void Play()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = true;
            foreach (var song in Songs)
            {
                if (song.Like == true) Console.ForegroundColor = ConsoleColor.Green;     //BL8 -Player 2/3. LikeDislike
                else if (song.Like == false) Console.ForegroundColor = ConsoleColor.Red;

                //L9 -HW -Player -2/3

                Console.WriteLine($"Player is playing: {song.Name.PlayerSubstring()}, genre: {song.Artist.Genre.PlayerSubstring()}"); 
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

        public void Play(List<Song> filteredSongs)          //BL8-Player4/4. FilterByGenre
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = true;
            if (filteredSongs.Count() == 0) Console.WriteLine("Nothing for play");
            else
            {
                Console.WriteLine("Filtered list");
                foreach (var song in Songs)
                {
                    if (song.Like == true) Console.ForegroundColor = ConsoleColor.Green;     //BL8 -Player 2/3. LikeDislike
                    else if (song.Like == false) Console.ForegroundColor = ConsoleColor.Red;

                    //L9 -HW -Player -2/3

                    Console.WriteLine($"Player is playing: {song.Name.PlayerSubstring()}, genre: {song.Artist.Genre.PlayerSubstring()}");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        public void Stop()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = false;
            Console.WriteLine("Player has stopped");
        }

        public void Locked()
        {
            _isLocked = true;
            Console.WriteLine("Player is locked");
        }
        public void Unlock()
        {
            _isLocked = false;
            Console.WriteLine("Player is unlocked");
        }

        public void Add(List<Song> songList)
        {
            Songs = songList;
        }

        //B7-Player1/2. SongsListShuffle
        public void Shuffle()
        {
            this.Songs = this.Songs.ShuffleSongs();                     //L9 -HW -Player -1/3
        }

        //B7-Player2/2. SongsListSort
        public void SongsListSort()
        {
            this.Songs = this.Songs.SortSongs();                        //L9 -HW -Player -1/3    
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
            foreach (var song in Songs)
            {
                Tuple<string, int, int, int> songData = GetSongData(song);
                Console.WriteLine($"Name: {songData.Item1}, Time: {songData.Item2}:{songData.Item3}:{songData.Item4}");
            }
        }

        public List<Song> FilterByGenre(string genre)                       //BL8-Player4/4. FilterByGenre
        {
            List<Song> filteredSongs = new List<Song>();
            foreach (var song in Songs)
            {
                if(song.genre.ToString() == genre)
                {
                    filteredSongs.Add(song);
                }
            }
            return filteredSongs;
        }
    }
}
