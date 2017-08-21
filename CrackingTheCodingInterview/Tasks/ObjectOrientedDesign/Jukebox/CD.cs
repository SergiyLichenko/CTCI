using System;
using System.Collections.Generic;

namespace Tasks.ObjectOrientedDesign.Jukebox
{
    public class CD
    {
        public IEnumerable<Song> Songs { get; private set; }
        public CD(IEnumerable<Song> songs)
        {
            if(songs ==null)
                throw new ArgumentNullException();
            Songs = songs;
        }
    }
}