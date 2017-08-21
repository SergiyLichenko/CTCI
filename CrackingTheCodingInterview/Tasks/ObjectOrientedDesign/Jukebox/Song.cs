using System;

namespace Tasks.ObjectOrientedDesign.Jukebox
{
    public class Song
    {
        public int Id { get; private set; }
        public string Name { get;private set; }
        public int Cost { get; private set; }
        public Artist Artist { get; private set; }
        public Song(int id, string name, int cost, Artist artist)
        {
            if(cost<0)
                throw new ArgumentOutOfRangeException();
            Id = id;
            Name = name;
            Cost = cost;
            Artist = artist;
        }
    }
}