using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.Jukebox;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public class JukeboxTests
    {
        [Fact]
        public void Jukebox_Should_InsertCD_If_Null()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.InsertCD(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void Jukebox_Should_Throw_GetSongs_If_No_Cd()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.GetSongs();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Jukebox_Should_Throw_PlaySong_If_Null()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.PlaySong(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Jukebox_Should_Throw_PlaySong_If_Song_Cost_Negative()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.PlaySong(new Song(1, String.Empty, -1, null));

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Jukebox_Should_Throw_PlayAllSongs_If_No_CD()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.PlayAllSongs();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Jukebox_Should_Throw_PlayAllSongsByArtist_If_No_CD()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.PlaySongsByArtist(new Artist(1, string.Empty));

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Jukebox_Should_Throw_PlayAllSongsByArtist_If_Null()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.PlaySongsByArtist(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Jukebox_Should_Throw_IncreaseBalance_If_Null()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.IncreaseBalance(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Jukebox_Should_Throw_IncreaseBalance_If_Cost_Negative()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            Action act = () => jukebox.IncreaseBalance(new Coin(-1));

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Jukebox_Should_Throw_Create_Coin_Cost_Negative()
        {
            //arrange

            //act
            Action act = () => new Coin(-1);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Jukebox_Should_Create_Coin()
        {
            //arrange
            int cost = 5;

            //act
            var coin = new Coin(cost);

            //assert
            coin.Cost.ShouldBeEquivalentTo(cost);
        }

        [Fact]
        public void Jukebox_Should_Throw_Create_CD_If_Null()
        {
            //arrange

            //act
            Action act = () => new CD(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Jukebox_Should_Create_CD()
        {
            //arrange
            var songs = new List<Song>();

            //act
            var cd = new CD(songs);

            //assert
            cd.Songs.ShouldBeEquivalentTo(songs);
        }

        [Fact]
        public void Jukebox_Should_Throw_Create_Song_With_Negative_Cost()
        {
            //arrange

            //act
            Action act = () => new Song(1, string.Empty, -1, null);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Jukebox_Should_Create_Song()
        {
            //arrange
            int id = 1;
            string name = String.Empty;
            int cost = 5;
            var artist = new Artist(1, String.Empty);

            //act
            var song = new Song(id, name, cost, artist);

            //assert
            song.Id.ShouldBeEquivalentTo(id);
            song.Name.ShouldBeEquivalentTo(name);
            song.Cost.ShouldBeEquivalentTo(cost);
            song.Artist.ShouldBeEquivalentTo(artist);
        }

        [Fact]
        public void Jukebox_Should_Create_Artist()
        {
            //arrange
            int id = 1;
            string name = String.Empty;

            //act
            var artist = new Artist(id, name);

            //assert
            artist.Id.ShouldBeEquivalentTo(id);
            artist.Name.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void Jukebox_Should_Get_Songs()
        {
            //arrange
            var artist = new Artist(1, String.Empty);
            var songs = new List<Song>()
            {
                new Song(1, string.Empty, 1, null),
                new Song(2, string.Empty, 2, artist),
                new Song(3, string.Empty, 3, null),
                new Song(4, string.Empty, 4, artist)
            };
            var jukebox = new Jukebox();
            jukebox.InsertCD(new CD(songs));

            //act
            var result = jukebox.GetSongs().ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(songs.Count);
            for (int i = 0; i < result.Count; i++)
                result[i].ShouldBeEquivalentTo(songs[i]);
        }

        [Fact]
        public void Jukebox_Should_Play_Song_IF_Enought_Balance()
        {
            //arrange
            var artist = new Artist(1, String.Empty);
            var songs = new List<Song>()
            {
                new Song(1, string.Empty, 1, null),
                new Song(2, string.Empty, 2, artist),
                new Song(3, string.Empty, 3, null),
                new Song(4, string.Empty, 4, artist)
            };
            var jukebox = new Jukebox();
            jukebox.InsertCD(new CD(songs));
            jukebox.IncreaseBalance(new Coin(5));

            //act
            jukebox.PlaySong(songs[2]);

            //assert
            jukebox.Balance.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Jukebox_Should_Not_Play_Song_IF_Enought_Balance()
        {
            //arrange
            var artist = new Artist(1, String.Empty);
            var songs = new List<Song>()
            {
                new Song(1, string.Empty, 1, null),
                new Song(2, string.Empty, 2, artist),
                new Song(3, string.Empty, 3, null),
                new Song(4, string.Empty, 4, artist)
            };
            var jukebox = new Jukebox();
            jukebox.InsertCD(new CD(songs));
            jukebox.IncreaseBalance(new Coin(1));

            //act
            jukebox.PlaySong(songs[2]);

            //assert
            jukebox.Balance.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Jukebox_Should_Play_All_Songs()
        {
            //arrange
            var artist = new Artist(1, String.Empty);
            var songs = new List<Song>()
            {
                new Song(1, string.Empty, 1, null),
                new Song(2, string.Empty, 2, artist),
                new Song(3, string.Empty, 3, null),
                new Song(4, string.Empty, 4, artist)
            };
            var jukebox = new Jukebox();
            jukebox.InsertCD(new CD(songs));
            jukebox.IncreaseBalance(new Coin(20));

            //act
            jukebox.PlayAllSongs();

            //assert
            jukebox.Balance.ShouldBeEquivalentTo(10);
        }

        [Fact]
        public void Jukebox_Should_Play_All_Songs_With_Skip()
        {
            //arrange
            var artist = new Artist(1, String.Empty);
            var songs = new List<Song>()
            {
                new Song(1, string.Empty, 4, null),
                new Song(2, string.Empty, 3, artist),
                new Song(3, string.Empty, 2, null),
                new Song(4, string.Empty, 1, artist)
            };
            var jukebox = new Jukebox();
            jukebox.InsertCD(new CD(songs));
            jukebox.IncreaseBalance(new Coin(2));

            //act
            jukebox.PlayAllSongs();

            //assert
            jukebox.Balance.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Jukebox_Should_Increase_Balance()
        {
            //arrange
            var jukebox = new Jukebox();

            //act
            jukebox.IncreaseBalance(new Coin(2));

            //assert
            jukebox.Balance.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Jukebox_Should_Play_All_Songs_By_Artist()
        {
            //arrange
            var artist = new Artist(1, String.Empty);
            var songs = new List<Song>()
            {
                new Song(1, string.Empty, 4, null),
                new Song(2, string.Empty, 3, artist),
                new Song(3, string.Empty, 2, null),
                new Song(4, string.Empty, 1, artist)
            };
            var jukebox = new Jukebox();
            jukebox.InsertCD(new CD(songs));
            jukebox.IncreaseBalance(new Coin(20));

            //act
            jukebox.PlaySongsByArtist(artist);

            //assert
            jukebox.Balance.ShouldBeEquivalentTo(16);
        }

        [Fact]
        public void Jukebox_Should_Play_All_Songs_By_Artist_With_Skip()
        {
            //arrange
            var artist = new Artist(1, String.Empty);
            var songs = new List<Song>()
            {
                new Song(1, string.Empty, 4, null),
                new Song(2, string.Empty, 3, artist),
                new Song(3, string.Empty, 2, null),
                new Song(4, string.Empty, 1, artist)
            };
            var jukebox = new Jukebox();
            jukebox.InsertCD(new CD(songs));
            jukebox.IncreaseBalance(new Coin(1));

            //act
            jukebox.PlaySongsByArtist(artist);

            //assert
            jukebox.Balance.ShouldBeEquivalentTo(0);
        }
    }
}
