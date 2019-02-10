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

        public event PlayerStateHandler SongStarted;
        public event PlayerStateHandler SongsListChanged;
        public event PlayerStateHandler PlayerStarted;
        public event PlayerStateHandler OnError;


        public const string directory = @"D:\WavForPlayer\";
        public List<Song> playlist;
        private SoundPlayer _player= new SoundPlayer();
        private bool _disposed = false;
        public Player() : base()
        {

        }

        //public Player(string color) //: base(color)
        //{

        //}

        public override void Play()
        {
            PlayAsync(Items);
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

        public override async void PlayAsync(List<Song> filteredSongs)          //BL8-Player4/4. FilterByGenre
        {
            if (_isLocked)
            {
                return;
            }
            PlayerStarted(this, new PlayerEventArgs("Player started"));
            _isPlaying = true;
            try
            {
                if (filteredSongs.Count() == 0) throw new FileNotFoundException();
                else
                {

                    //Skin.Render("Filtered list");
                    foreach (var song in Items)
                    {
                        //Skin.Render($"Player is playing: {song.Name}");


                        _player.SoundLocation = song.Path;
                        await Task.Run(() =>
                            {
                                SongStarted(this, new PlayerEventArgs($"Player is playing: {song.Name}"));
                                _player.PlaySync();
                                System.Threading.Thread.Sleep(1000);
                            });
                        //PlaySongAsync(song);

                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                OnError(this, new PlayerEventArgs("Can't find files"));
            }
            catch (InvalidOperationException ex)
            {
                OnError(this, new PlayerEventArgs("Unknown file's format"));
            }
            Clear();
        }
        //public async Task PlaySongAsync(Song song)
        //{
        //    await Task.Run(() => 
        //    {
        //        SongStarted(this, new PlayerEventArgs($"Player is playing: {song.Name}"));
        //        _player.PlaySync();
        //    });
        //}

        //B7-Player2/2. SongsListSort
        public void SongsListSort()
        {
            this.Items = this.Items.SortSongs();                        //L9 -HW -Player -1/3    
            SongsListChanged(this, new PlayerEventArgs("SongList changed"));
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
                //Skin.Render($"Name: {songData.Item1}, Time: {songData.Item2}:{songData.Item3}:{songData.Item4}");
            }
            //Skin.Clear();
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
            SongsListChanged(this, new PlayerEventArgs("SongList filtered"));
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
                        Path = file.FullName
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
            if (!this._disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    playlist = null;
                    //Skin = null;
                    Items = null;
                }
                _player.Dispose();
                _disposed = true;
            }
        }
        ~Player()
        {
            Dispose(false);
        }
    }
}
