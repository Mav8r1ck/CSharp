using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            //player.Volume = 20;
            int min;
            int max;
            int total = 0;
            player.Add(GetSongsData(out min, out max, ref total));

            Console.WriteLine($"Min = {min}, max = {max}, total = {total}");


            //            TraceInfo(player);

            player.Play();
            player.VolumeUp();
            Console.WriteLine(player.Volume);

            player.VolumeChange(-300);
            Console.WriteLine(player.Volume);

            player.VolumeChange(300);
            Console.WriteLine(player.Volume);

            /*player.Volume = -25;
            Console.WriteLine(player.Volume);
            */
            player.Stop();
            player.Shuffle();                                       //B7-Player1/2. SongsListShuffle
            player.ListSong();                                      //BL8 -Player1/3.SongTuples
            player.Play();
            player.Stop();
            player.SongsListSort();                                 //B7-Player2/2. SongsListSort
            player.Play();
            player.Stop();
            player.Shuffle();
            player.Play();
            player.Stop();
            player.Play(player.FilterByGenre("Classic"));            //BL8-Player4/4. FilterByGenre
            player.Stop();
            player.Play(player.FilterByGenre("Rock"));

            /*
            var randSong = CreateSong();
            var randSong_2 = CreateSong("Go!");
            var randSong_3 = CreateSong("Signals", 123);
            
            //player.Add( randSong , randSong_2, randSong_3 );
            player.Play();
            */


            Console.ReadLine();
        }



        public static List<Song> GetSongsData(out int minDuration, out int maxDuration, ref int totalDuration)
        {
            minDuration = 1000;
            maxDuration = 0;

            var artist = new Artist();
            artist.Name = "Powerwolf";
            artist.Genre = "Metal";

            var artist2 = new Artist("Lordi");
            Console.WriteLine(artist2.Name);
            Console.WriteLine(artist2.Genre);

            var artist3 = new Artist("Sabaton", "Rock");
            Console.WriteLine(artist3.Name);
            Console.WriteLine(artist3.Genre);

            var album = new Album();
            album.Name = "New Album";
            album.Year = 2018;

            List<Song> songs = new List<Song>();
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                songs.Add(new Song()
                {
                    Duration = random.Next(1000),
                    Name = $"New song {i}",
                    Album = album,
                    Artist = artist,
                    genre = Song.SongGenres.Classic
                });
            }
            //BL8 -Player 2/3. LikeDislike
            songs[2].LikeDislike(true);
            songs[5].LikeDislike(false);
            songs[8].LikeDislike(false);
            songs[0].LikeDislike(true);

            foreach (var song in songs)
            {
                totalDuration += song.Duration;
                if (song.Duration < minDuration)
                {
                    minDuration = song.Duration;
                }
                maxDuration = Math.Max(maxDuration, song.Duration);
            }
            return songs;
        }

        public static void TraceInfo(Player player)
        {
            Console.WriteLine(player.Songs[0].Artist.Name);
            Console.WriteLine(player.Songs[0].Duration);
            Console.WriteLine(player.Songs.Count);
            Console.WriteLine(player.Volume);
        }

        public static Song CreateSong()
        {
            return CreateSong("Her Ghost", 300);
        }
        public static Song CreateSong(string newName)
        {
            return CreateSong(newName, 300);
        }

        public static Song CreateSong(string newName, int newDuration)
        {
            return new Song { Name = newName, Duration = newDuration };
        }
    }
}
