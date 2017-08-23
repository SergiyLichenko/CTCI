using System;
using System.Collections.Generic;

namespace Tasks.ObjectOrientedDesign.ChatServer
{
    public class Chat
    {
        public Chat(string name, User creator)
        {
            if (name == null || creator == null)
                throw new ArgumentNullException();
            Name = name;
            Creator = creator;
            Users = new List<User> { creator };
            Messages = new List<Message>();
        }

        public string Name { get; private set; }
        public User Creator { get; private set; }
        public ICollection<User> Users { get; private set; }
        public ICollection<Message> Messages { get; private set; }

        public void NotifyDisconnect(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            foreach (var item in Users)
                item.NotifyDisconnect(user);
        }

        public void NotifyConnect(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            foreach (var item in Users)
                item.NotifyConnect(user);
        }
    }
}