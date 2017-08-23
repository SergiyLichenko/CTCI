using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.ChatServer
{
    public class ChatServer
    {
        public ChatServer()
        {
            Users = new List<User>();
            Chats = new List<Chat>();
            _connectedUsers = new List<User>();
        }
        private readonly ICollection<User> _connectedUsers;
        public ICollection<User> Users { get; private set; }
        public ICollection<Chat> Chats { get; private set; }

        public void Connect(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            if (Users.Contains(user))
                user.IsConnected = true;
            _connectedUsers.Add(user);

            foreach (var userChat in user.Chats)
                userChat.NotifyConnect(user);
        }

        public void Disconnect(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            if (!user.IsConnected || !Users.Contains(user))
                return;
            user.IsConnected = false;
            _connectedUsers.Remove(user);

            foreach (var userChat in user.Chats)
                userChat.NotifyDisconnect(user);
        }

        public bool IsConnected(User user)
        {
            if(user == null)
                throw new ArgumentNullException();
            return _connectedUsers.Contains(user);
        }
    }
}
