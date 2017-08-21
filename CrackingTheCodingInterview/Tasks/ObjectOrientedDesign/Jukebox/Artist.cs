namespace Tasks.ObjectOrientedDesign.Jukebox
{
    public class Artist 
    {
        public Artist(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}