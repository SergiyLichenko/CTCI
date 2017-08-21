using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.CallCenter;
using Tasks.ObjectOrientedDesign.DeckOfCards;
using Tasks.ObjectOrientedDesign.Jukebox;
using Tasks.ObjectOrientedDesign.ParkingLot;
using Xunit;

namespace Tasks.UT
{
    public class ObjectOrientedDesignTests
    {
        [Fact]
        public void DeckOfCards_Should_Create_Default_BlackJack_Deck()
        {
            //arrange
            int cardCount = 52;
            int suitCount = 4;

            //act
            var deck = new BlackJackDeck();

            //assert
            deck.Cards.Count.ShouldBeEquivalentTo(cardCount);
            var grouped = deck.Cards.GroupBy(x => x.Suit).ToDictionary(x => x.Key);

            grouped.Keys.ElementAt(0).ShouldBeEquivalentTo(Suit.Clubs);
            grouped.Keys.ElementAt(1).ShouldBeEquivalentTo(Suit.Diamonds);
            grouped.Keys.ElementAt(2).ShouldBeEquivalentTo(Suit.Hearts);
            grouped.Keys.ElementAt(3).ShouldBeEquivalentTo(Suit.Spades);

            foreach (var item in grouped)
            {
                var values = grouped[item.Key].Select(x => x.Rank).ToList();
                values.Count.Should().Be(cardCount / suitCount);

                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    values.Contains(rank).ShouldBeEquivalentTo(true);
            }
            deck.Cards.All(x => x.GameType == GameType.BlackJack).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Shuffle()
        {
            //arrange
            int cardCount = 52;
            int suitCount = 4;
            var deck = new BlackJackDeck();

            var initialOrder = deck.Cards.ToList();

            //act
            deck.ShuffleCards();

            //assert
            deck.Cards.SequenceEqual(initialOrder).ShouldBeEquivalentTo(false);

            deck.Cards.Count.ShouldBeEquivalentTo(cardCount);
            var grouped = deck.Cards.GroupBy(x => x.Suit).OrderBy(x => x.Key).ToDictionary(x => x.Key);

            grouped.Keys.ElementAt(0).ShouldBeEquivalentTo(Suit.Clubs);
            grouped.Keys.ElementAt(1).ShouldBeEquivalentTo(Suit.Diamonds);
            grouped.Keys.ElementAt(2).ShouldBeEquivalentTo(Suit.Hearts);
            grouped.Keys.ElementAt(3).ShouldBeEquivalentTo(Suit.Spades);

            foreach (var item in grouped)
            {
                var values = grouped[item.Key].Select(x => x.Rank).ToList();
                values.Count.Should().Be(cardCount / suitCount);

                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    values.Contains(rank).ShouldBeEquivalentTo(true);
            }
            deck.Cards.All(x => x.GameType == GameType.BlackJack).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Get_Random_Card()
        {
            //arrange
            int cardCount = 52;
            var deck = new BlackJackDeck();

            //act
            var card = deck.GetRandomCard();

            //assert
            deck.Cards.Count.ShouldBeEquivalentTo(cardCount - 1);
            deck.Cards.Contains(card).ShouldBeEquivalentTo(false);
            deck.Cards.All(x => x.GameType == GameType.BlackJack).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Get_Random_Card_Throw_If_Empty()
        {
            //arrange
            int cardCount = 52;
            var deck = new BlackJackDeck();
            for (int i = 0; i < cardCount; i++)
                deck.GetRandomCard();

            //act
            Action act = () => deck.GetRandomCard();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void DeckOfCards_Should_Check_Card_Values()
        {
            //arrange
            int cardsCount = 13;
            var cards = new List<Card>();
            for (int i = 0; i < cardsCount; i++)
                cards.Add(new BlackJackCard((Rank)i, Suit.Clubs, GameType.BlackJack));

            var res = Enumerable.Range(1, 10).ToList();
            foreach (var item in Enumerable.Repeat(10, 3))
                res.Add(item);

            //act
            var result = cards.Select(x => x.GetValue()).OrderBy(x => x).ToList();

            //assert
            result.SequenceEqual(res).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Check_Renew()
        {
            //arrange
            int cardCount = 52;
            int suitCount = 4;
            var deck = new BlackJackDeck();

            deck.GetRandomCard();
            deck.GetRandomCard();
            //act
            deck.Renew();

            //assert
            deck.Cards.Count.ShouldBeEquivalentTo(cardCount);
            var grouped = deck.Cards.GroupBy(x => x.Suit).ToDictionary(x => x.Key);

            grouped.Keys.ElementAt(0).ShouldBeEquivalentTo(Suit.Clubs);
            grouped.Keys.ElementAt(1).ShouldBeEquivalentTo(Suit.Diamonds);
            grouped.Keys.ElementAt(2).ShouldBeEquivalentTo(Suit.Hearts);
            grouped.Keys.ElementAt(3).ShouldBeEquivalentTo(Suit.Spades);

            foreach (var item in grouped)
            {
                var values = grouped[item.Key].Select(x => x.Rank).ToList();
                values.Count.Should().Be(cardCount / suitCount);

                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    values.Contains(rank).ShouldBeEquivalentTo(true);
            }
            deck.Cards.All(x => x.GameType == GameType.BlackJack).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Check_Hand_Overflow()
        {
            //arrange
            int cardCount = 52;
            var deck = new BlackJackDeck();
            var hand = new BlackJackHand(deck);

            //act
            for (int i = 0; i < cardCount; i++)
                hand.TakeCard();

            //assert
            deck.Cards.Count.ShouldBeEquivalentTo(0);
            hand.Points.ShouldBeEquivalentTo(340);
            hand.IsOverFlow.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CallCenter_Should_Check_Employee_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));

            var call = new Call(EmployeeType.Respondent);

            //act
            var result = callCenter.Simulate(call);

            //assert
            result.ShouldBeEquivalentTo(true);
            call.IsTaken.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CallCenter_Should_Check_Manager_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));
            callCenter.Employees.Add(new Manager(callCenter));

            var call = new Call(EmployeeType.Manager);

            //act
            var result = callCenter.Simulate(call);

            //assert
            result.ShouldBeEquivalentTo(true);
            call.IsTaken.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CallCenter_Should_Check_Director_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));
            callCenter.Employees.Add(new Manager(callCenter));
            callCenter.Employees.Add(new Director(callCenter));

            var call = new Call(EmployeeType.Director);

            //act
            var result = callCenter.Simulate(call);

            //assert
            result.ShouldBeEquivalentTo(true);
            call.IsTaken.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CallCenter_Should_Throw_If_No_Repondents_To_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();

            var call = new Call(EmployeeType.Respondent);

            //act
            Action act = () => callCenter.Simulate(call);

            //assert
            act.ShouldThrow<InvalidOperationException>();
            call.IsTaken.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void CallCenter_Should_Throw_If_No_Manager_To_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));
            var call = new Call(EmployeeType.Manager);

            //act
            Action act = () => callCenter.Simulate(call);

            //assert
            act.ShouldThrow<InvalidOperationException>();
            call.IsTaken.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void CallCenter_Should_Throw_If_No_Director_To_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));
            callCenter.Employees.Add(new Manager(callCenter));
            var call = new Call(EmployeeType.Director);

            //act
            Action act = () => callCenter.Simulate(call);

            //assert
            act.ShouldThrow<InvalidOperationException>();
            call.IsTaken.ShouldBeEquivalentTo(false);
        }

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

        [Fact]
        public void ParkingLot_Should_Throw_If_Not_In_Range_Create_ParkingLot()
        {
            //arrange

            //act
            Action actFloors = () => new ParkingLot(-1, 1, 1);
            Action actWidth = () => new ParkingLot(1, -1, 1);
            Action actHeight = () => new ParkingLot(1, 1, -1);

            //assert
            actFloors.ShouldThrow<ArgumentOutOfRangeException>();
            actWidth.ShouldThrow<ArgumentOutOfRangeException>();
            actHeight.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Create_ParkingLot_Default()
        {
            //arrange
            int floorsCount = 3;
            int width = 4;
            int height = 5;

            //act
            var parkingLot = new ParkingLot(floorsCount, width, height);

            //assert
            parkingLot.FloorsCount.ShouldBeEquivalentTo(floorsCount);
            parkingLot.GetFloor(floorsCount - 1).Height.ShouldBeEquivalentTo(height);
            parkingLot.GetFloor(floorsCount - 1).Width.ShouldBeEquivalentTo(width);
        }

        [Fact]
        public void ParkingLot_Should_Throw_GetFlor_If_Not_In_Range()
        {
            //arrange
            int floorsCount = 3;
            int width = 4;
            int height = 5;
            var parkingLot = new ParkingLot(floorsCount, width, height);

            //act
            Action actHigher = () => parkingLot.GetFloor(floorsCount);
            Action actLower = () => parkingLot.GetFloor(-1);

            //assert
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Throw_Create_Floor_If_Not_In_Range()
        {
            //arrange

            //act
            Action actFirst = () => new Floor(-1, 1);
            Action actSecond = () => new Floor(1, -1);

            //assert
            actFirst.ShouldThrow<ArgumentOutOfRangeException>();
            actSecond.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Create_Floor()
        {
            //arrange
            int width = 10;
            int height = 15;

            //act
            var floor = new Floor(width, height);

            //assert
            floor.Height.ShouldBeEquivalentTo(height);
            floor.Width.ShouldBeEquivalentTo(width);
            floor.Count.ShouldBeEquivalentTo(0);
        }

       
        [Fact]
        public void ParkingLot_Should_Throw_Get_Place_If_Not_In_Range()
        {
            //arrange
            int width = 10;
            int height = 15;
            var floor = new Floor(width, height);

            //act
            Action actFirstLower = () => floor.GetPlace(-1, 1);
            Action actFirstHigher = () => floor.GetPlace(height, 1);
            Action actSecondLower = () => floor.GetPlace(1, -1);
            Action actSecondHigher = () => floor.GetPlace(1, width);

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Throw_Set_Place_If_Not_In_Range()
        {
            //arrange
            int width = 10;
            int height = 15;
            var floor = new Floor(width, height);

            //act
            Action actFirstLower = () => floor.SetPlace(-1, 1, new Car(string.Empty));
            Action actFirstHigher = () => floor.SetPlace(height, 1, new Car(string.Empty));
            Action actSecondLower = () => floor.SetPlace(1, -1, new Car(string.Empty));
            Action actSecondHigher = () => floor.SetPlace(1, width, new Car(string.Empty));

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Throw_Set_Place_If_Null()
        {
            //arrange
            int width = 10;
            int height = 15;
            var floor = new Floor(width, height);

            //act
            Action actFirstLower = () => floor.SetPlace(1, 1, null);

            //assert
            actFirstLower.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ParkingLot_Should_Throw_Clear_Place_If_Not_In_Range()
        {
            //arrange
            int width = 10;
            int height = 15;
            var floor = new Floor(width, height);

            //act
            Action actFirstLower = () => floor.ClearPlace(-1, 1);
            Action actFirstHigher = () => floor.ClearPlace(height, 1);
            Action actSecondLower = () => floor.ClearPlace(1, -1);
            Action actSecondHigher = () => floor.ClearPlace(1, width);

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Check_Set_Place()
        {
            //arrange
            var parkingLot = new ParkingLot(3,5,5);
            int floor = 2;
            int i = 1;
            int j = 2;

            //act
            parkingLot.GetFloor(floor).SetPlace(i,j, new Car(string.Empty));

            //assert
            parkingLot.Count.ShouldBeEquivalentTo(1);
            parkingLot.GetFloor(floor).Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void ParkingLot_Should_Check_Get_Place()
        {
            //arrange
            int floor = 2;
            int i = 1;
            int j = 2;
            var car = new Car(string.Empty);
            var parkingLot = new ParkingLot(3, 5, 5);
            parkingLot.GetFloor(floor).SetPlace(i, j, car);

            //act
            var result = parkingLot.GetFloor(floor).GetPlace(i, j);

            //assert
            parkingLot.Count.ShouldBeEquivalentTo(1);
            parkingLot.GetFloor(floor).Count.ShouldBeEquivalentTo(1);
            result.ShouldBeEquivalentTo(car);
        }

        [Fact]
        public void ParkingLot_Should_Check_Clear_Place()
        {
            //arrange
            int floor = 2;
            int i = 1;
            int j = 2;
            var car = new Car(string.Empty);
            var parkingLot = new ParkingLot(3, 5, 5);
            parkingLot.GetFloor(floor).SetPlace(i, j, car);

            //act
            parkingLot.GetFloor(floor).ClearPlace(i,j);
            var result = parkingLot.GetFloor(floor).GetPlace(i, j);

            //assert
            parkingLot.Count.ShouldBeEquivalentTo(0);
            parkingLot.GetFloor(floor).Count.ShouldBeEquivalentTo(0);
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void ParkingLot_Should_Throw_Set_Place_If_Taken()
        {
            //arrange
            int floor = 2;
            int i = 1;
            int j = 2;
            var car = new Car(string.Empty);
            var parkingLot = new ParkingLot(3, 5, 5);
            parkingLot.GetFloor(floor).SetPlace(i, j, car);

            //act
            Action act = ()=> parkingLot.GetFloor(floor).SetPlace(i, j, new Car(string.Empty));

            //assert
            act.ShouldThrow<InvalidOperationException>();
            parkingLot.Count.ShouldBeEquivalentTo(1);
            parkingLot.GetFloor(floor).Count.ShouldBeEquivalentTo(1);
            parkingLot.GetFloor(floor).GetPlace(i,j).ShouldBeEquivalentTo(car);
        }
    }
}
