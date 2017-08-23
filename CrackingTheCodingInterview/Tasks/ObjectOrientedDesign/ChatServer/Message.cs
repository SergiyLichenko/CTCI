using System;

namespace Tasks.ObjectOrientedDesign.ChatServer
{
    public class Message
    {
        public User Owner { get; private set; }
        public string Text { get; private set; }
        public Message(User owner, string text)
        {
            if (owner == null || text == null)
                throw new ArgumentNullException();
            Owner = owner;
            Text = text;
        }
    }
}