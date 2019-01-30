using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extantions;

namespace MusicPlayer
{
    public class GenericPlayer<T>
    {
        public bool _isLocked;
        public bool _isPlaying;
        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 100;
        private ISkin skin;
        internal ISkin Skin { get => skin; set => skin = value; }
        public List<T> Items; //B7-Player1/2. SongsListShuffle
        

        public GenericPlayer()
        {
            Skin = new ClassicSkin();
        }

        public GenericPlayer(string color)
        {
            Skin = new ColorSkin(color);
        }
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
        public void Stop()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = false;
            Skin.Render("Player has stopped");
        }

        public void Locked()
        {
            _isLocked = true;
            Skin.Render("Player is locked");
        }
        public void Unlock()
        {
            _isLocked = false;
            Skin.Render("Player is unlocked");
        }

        public virtual void Play()
        {
        }
        public virtual void Play(List<T> playingItem)
        {

        }

        //public void Add(List<T> playingItem)
        //{
        //    Items = playingItem;
        //}

        //B7-Player1/2. SongsListShuffle
        public void Shuffle() => this.Items = this.Items.ShuffleItem<T>();                     //L9 -HW -Player -1/3

    }
}
