using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tasks.ObjectOrientedDesign.ChatServer
{
    public class User
    {
        public User(string name)
        {
            Name = name;
            Chats = new List<Chat>();
        }
        public string Name { get; private set; }
        public ICollection<Chat> Chats { get; private set; }
        public bool IsConnected { get; set; }
        public void AddToChat(Chat chat)
        {
            if (chat == null)
                throw new ArgumentNullException();
            if (chat.Users.Contains(this))
                throw new InvalidOperationException();
            Chats.Add(chat);
            chat.Users.Add(this);
        }

        public void ReceiveMessage(Message message)
        {
            if (message == null)
                throw new ArgumentNullException();
            Thread.Sleep(100);
        }

        public void SendMessage(Chat toChat, Message message)
        {
            if (toChat == null || message == null)
                throw new ArgumentNullException();
            if (!toChat.Users.Contains(this))
                throw new InvalidOperationException();
            if (this != message.Owner)
                throw new ArgumentException();
            toChat.Messages.Add(message);
            foreach (var user in toChat.Users.Where(x => !x.Equals(this)))
                user.ReceiveMessage(message);
        }

        public void NotifyDisconnect(User user)
        {
            if(user == null)
                throw new ArgumentNullException();
            Thread.Sleep(100);
        }

        public void NotifyConnect(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            Thread.Sleep(100);
        }
    }
}