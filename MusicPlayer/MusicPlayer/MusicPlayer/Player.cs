using MusicPlayer.Extantions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Media;



namespace MusicPlayer 
{
    public class Player : GenericPlayer<Song>, IDisposable
    {
        public const string directory = @"D:\WavForPlayer\";
        public List<Song> playlist;
        private SoundPlayer _player;
        private bool disposed = false;
        public Player() : base()
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
                //if (song.Like == true) Console.ForegroundColor = ConsoleColor.Green;     //BL8 -Player 2/3. LikeDislike
                //else if (song.Like == false) Console.ForegroundColor = ConsoleColor.Red;

                //L9 -HW -Player -2/3

                //Skin.Render($"Player is playing: {song.Name.PlayerSubstring()}, genre: {song.Artist.Genre.PlayerSubstring()}"); 
                _player = new SoundPlayer((directory + song.Name));
                Skin.Render($"Player is playing: {song.Name}");
                _player.PlaySync();
                //_player.Dispose();
                //Console.ResetColor();
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
                //Skin.Render("Filtered list");
                foreach (var song in Items)
                {
                    //if (song.Like == true) Console.ForegroundColor = ConsoleColor.Green;     //BL8 -Player 2/3. LikeDislike
                    //else if (song.Like == false) Console.ForegroundColor = ConsoleColor.Red;

                    //L9 -HW -Player -2/3

                    //Skin.Render($"Player is playing: {song.Name.PlayerSubstring()}, genre: {song.Artist.Genre.PlayerSubstring()}");
                    _player = new SoundPlayer((directory + song.Name));
                    Skin.Render($"Player is playing: {song.Name}");
                    _player.PlaySync();
                    //_player.Dispose();
                    //Console.ResetColor();
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
            SongGenres option;
            List<Song> filteredSongs = new List<Song>();
            foreach (var song in Items)
            {
                if (Enum.TryParse(genre, out option))
                {
                    if (Enum.IsDefined(typeof(SongGenres), option))
                    {
                        filteredSongs.Add(song);
                    }
                }
            }
            return filteredSongs;
        }

        public void Load(string directory)
        {
            List<Song> songs = new List<Song>();
            var directoryInfo = new DirectoryInfo(directory);
            var files = directoryInfo.GetFiles("*.wav");
            foreach (var file in files)
            {
                if (file != null)
                {
                    songs.Add(new Song
                    {
                        Name = file.Name,
                        Duration = file.Length,
                        Path = file.DirectoryName
                    });
                }
            }
            Items = songs;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void SaveAsPlaylist()
        {
            XmlSerializer toXml = new XmlSerializer(Items.GetType());
            using (FileStream fs = new FileStream("playlist.xml", FileMode.OpenOrCreate))
            {
                toXml.Serialize(fs, Items);
            }
        }

        public void LoadPlaylist()
        {
            XmlSerializer toXml = new XmlSerializer(Items.GetType());
            using (FileStream fs = new FileStream("playlist.xml", FileMode.OpenOrCreate))
            {
                playlist = (List<Song>)toXml.Deserialize(fs);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    _player.Dispose();
                }
                disposed = true;
            }
        }
        ~Player()
        {
            Dispose(false);
        }
    }
}
