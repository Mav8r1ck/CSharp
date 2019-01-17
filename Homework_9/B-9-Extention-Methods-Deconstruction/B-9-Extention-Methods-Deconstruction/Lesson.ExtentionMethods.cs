using System.Collections.Generic;
using System.Linq;

namespace Base_Lesson_9.Lesson
{
    public static partial class Lesson
    {
    }   

    public class Song
    {
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public int Duration { get; set; }
    }

    public class Playlist
    {
        public List<Song> Songs { get; set; }

        public void Sort()
        {            
            this.Songs = this.Songs.SortSongs();
        }
    }

    public class AudioPlayer
    {
        public List<Song> Songs { get; set; }

        public void Sort(List<Song> songs)
        {
           
            this.Songs = this.Songs.SortSongs();
        }

        public void Load(params Playlist[] playlists)
        {
            var songs = playlists.SelectMany(x => x.Songs);           
            this.Songs = this.Songs.SortSongs();
            //Do distincting
            //this.Songs = songs.ToArray();

            //this.Songs.FirstOrDefault()
        }
    }

    public static class SortHelper
    {
        public static List<Song> SortSongs(this List<Song> songs)
        {
            //алгоритм сортировки
            return songs;
        }
    }
    
    #region Sorting utilites

    /*
    public class SortHelper
    {
        public List<Song> Sort(List<Song> items)
        {
            //Do some sorting
            return items;
        }
    }

    public static class StaticSortHelper
    {
        public static List<Song> Sort(List<Song> items)
        {
            //Do some sorting
            return items;
        }
    }

    public static class ExtentionSortHelper
    {
        public static List<Song> Sort(this List<Song> items)
        {
            //Do some sorting
            return items;
        }

        public static List<Song> Distinct(this List<Song> items)
        {
            //Do some distinct
            return items;
        }
    }

    public class EqualityComparer<T> : IEqualityComparer<T>
    {
        public EqualityComparer(Func<T, T, bool> cmp)
        {
            this.cmp = cmp;
        }
        public bool Equals(T x, T y)
        {
            return cmp(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        public Func<T, T, bool> cmp { get; set; }
    }
    */   

    #endregion Sorting utilites
}
