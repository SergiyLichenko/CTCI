using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.Jukebox
{
    public class Jukebox
    {
        public CD CurrentCD { get; private set; }
        public int Balance { get; private set; }
        public void InsertCD(CD cd)
        {
            CurrentCD = cd ?? throw new ArgumentNullException();
        }

        public IEnumerable<Song> GetSongs()
        {
            if(CurrentCD == null)
                throw new InvalidOperationException();
            return CurrentCD.Songs;
        }

        public void PlaySong(Song song)
        {
            if(song == null)
                throw new ArgumentNullException();
            if(song.Cost<0)
                throw new ArgumentOutOfRangeException();
            if (Balance >= song.Cost)
            {
                Balance -= song.Cost;
                Thread.Sleep(100); //song play
            }
        }

        public void PlayAllSongs()
        {
            if(CurrentCD == null)
                throw new InvalidOperationException();
            var songs = new Queue<Song>(CurrentCD.Songs);
            while (songs.Count > 0)
            {
                PlaySong(songs.Dequeue());
            }
        }

        public void PlaySongsByArtist(Artist artist)
        {
            if(artist == null)
                throw new ArgumentNullException();
            if (CurrentCD == null)
                throw new InvalidOperationException();
            var songs = new Queue<Song>(CurrentCD.Songs.Where(x=>x.Artist==artist));
            while (songs.Count > 0)
            {
                PlaySong(songs.Dequeue());
            }
        }

        public void IncreaseBalance(Coin coin)
        {
            if(coin == null)
                throw new ArgumentNullException();
            if(coin.Cost<0)
                throw new ArgumentOutOfRangeException();
            Balance += coin.Cost;
        }
    }
}
