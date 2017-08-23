using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Tasks.ObjectOrientedDesign.ChatServer;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public class ChatServerTests
    {
        [Fact]
        public void Should_Create_Message()
        {
            //arrange
            var owner = new User(string.Empty);
            var text = string.Empty;

            //act
            var message = new Message(owner, text);

            //assert
            message.Owner.ShouldBeEquivalentTo(owner);
            message.Text.ShouldBeEquivalentTo(text);
        }

        [Fact]
        public void Should_Throw_Create_Message_If_Null()
        {
            //arrange
            var owner = new User(string.Empty);
            var text = string.Empty;

            //act
            Action actFirst = () => new Message(null, text);
            Action actSecond = () => new Message(owner, null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Add_To_Chat_If_Null()
        {
            //arrange
            var user = new User(string.Empty);

            //act
            Action act = () => user.AddToChat(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_AddToChat()
        {
            //arrange
            var user = new User(string.Empty);
            var chat = new Chat(String.Empty, new User(string.Empty));

            //act
            user.AddToChat(chat);

            //assert
            chat.Users.Contains(user).ShouldBeEquivalentTo(true);
            user.Chats.Contains(chat).ShouldBeEquivalentTo(true);
            chat.Users.Count.ShouldBeEquivalentTo(2);
            user.Chats.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Throw_Create_Chat_If_Null()
        {
            //arrange

            //act
            Action actFirst = () => new Chat(null, new User(string.Empty));
            Action actSecond = () => new Chat(string.Empty, null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Create_Chat_With_Owner()
        {
            //arrange
            var owner = new User(string.Empty);
            var name = string.Empty;

            //act
            var chat = new Chat(name, owner);

            //assert
            chat.Users.Count.ShouldBeEquivalentTo(1);
            chat.Users.Contains(owner).ShouldBeEquivalentTo(true);
            chat.Creator.ShouldBeEquivalentTo(owner);
            chat.Name.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void Should_Not_Add_To_Chat_Owner_Twice()
        {
            //arrange
            var owner = new User(string.Empty);
            var name = string.Empty;
            var chat = new Chat(name, owner);

            //act
            Action act = () => owner.AddToChat(chat);

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Throw_Send_Message_Chat_If_Null()
        {
            //arrange
            var owner = new User(string.Empty);
            var name = string.Empty;
            var chat = new Chat(name, owner);

            //act

            Action actFirst = () => owner.SendMessage(null, new Message(owner, string.Empty));
            Action actSecond = () => owner.SendMessage(chat, null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Receive_Message_If_Null()
        {
            //arrange
            var owner = new User(string.Empty);

            //act
            Action act = () => owner.ReceiveMessage(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Send()
        {
            //arrange
            var owner = new User(string.Empty);
            var name = string.Empty;
            var chat = new Chat(name, owner);
            var message = new Message(owner, string.Empty);

            var newUser = new User(string.Empty);
            newUser.AddToChat(chat);

            //act
            owner.SendMessage(chat, message);

            //assert
            chat.Messages.Count.ShouldBeEquivalentTo(1);
            chat.Messages.Contains(message).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Throw_Send_Message_If_User_Not_In_Chat()
        {
            //arrange
            var owner = new User(string.Empty);
            var name = string.Empty;
            var chat = new Chat(name, owner);
            var message = new Message(owner, string.Empty);

            var newUser = new User(string.Empty);

            //act
            Action act = () => newUser.SendMessage(chat, message);

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Throw_Send_Message_If_User_Is_Not_Owner()
        {
            //arrange
            var owner = new User(string.Empty);
            var name = string.Empty;
            var chat = new Chat(name, owner);
            var message = new Message(owner, string.Empty);

            var newUser = new User(string.Empty);
            newUser.AddToChat(chat);

            //act
            Action act = () => newUser.SendMessage(chat, message);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Connect_To_Chat_Server()
        {
            //arrange
            var user = new User(string.Empty);
            var server = new ChatServer();
            server.Users.Add(user);
           
            //act
            server.Connect(user);

            //assert
            user.IsConnected.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Not_Connect_To_Chat_Server()
        {
            //arrange
            var user = new User(string.Empty);
            var server = new ChatServer();

            //act
            server.Connect(user);

            //assert
            user.IsConnected.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Throw_Connect_Chat_Server_If_Null()
        {
            //arrange

            //act
            Action act = () => new ChatServer().Connect(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Disconnect_From_Chat_Server()
        {
            //arrange
            var user = new User(string.Empty);
            var server = new ChatServer();
            server.Users.Add(user);
            server.Connect(user);
           
            //act
            server.Disconnect(user);

            //assert
            user.IsConnected.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Throw_Disconnect_Chat_Server_If_Null()
        {
            //arrange

            //act
            Action act = () => new ChatServer().Disconnect(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Notify_Disconnect_If_Null()
        {
            //arrange

            //act
            Action act = () => new Chat(string.Empty, new User(string.Empty)).NotifyDisconnect(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Notify_Disconnect_If_Null_User()
        {
            //arrange

            //act
            Action act = () => new User(string.Empty).NotifyDisconnect(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Notify_Connect_If_Null()
        {
            //arrange

            //act
            Action act = () => new Chat(string.Empty, new User(string.Empty)).NotifyConnect(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Notify_Connect_If_Null_User()
        {
            //arrange

            //act
            Action act = () => new User(string.Empty).NotifyConnect(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Check_If_User_Is_Connected_True()
        { 
            //arrange
            var server = new ChatServer();
            var user = new User(String.Empty);
            server.Users.Add(user);
            server.Connect(user);

            //act
            var result = server.IsConnected(user);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_If_User_Is_Connected_False()
        {
            //arrange
            var server = new ChatServer();
            var user = new User(String.Empty);
            server.Users.Add(user);
            server.Connect(user);

            var newUser = new User(string.Empty);
            
            //act
            var result = server.IsConnected(newUser);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Throw_Check_If_User_Is_Connected_When_Null()
        {
            //arrange

            //act
            Action act = () => new ChatServer().IsConnected(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Check_If_User_Is_Connected_After_Disconnect_Connect()
        {
            //arrange
            var server = new ChatServer();
            var user = new User(String.Empty);
            server.Users.Add(user);

            //act
            server.Connect(user);
            server.Disconnect(user);
            server.Connect(user);
            var result = server.IsConnected(user);

            //assert
            result.ShouldBeEquivalentTo(true);
        }
    }
}
