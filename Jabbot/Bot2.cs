using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JabbR.Client;

namespace Jabbot
{
    public class Bot2
    {
        private readonly string _password = string.Empty;
        private readonly string _url = string.Empty;

        JabbRClient client;

        public Bot2(string name, string password, string url)
        {
            Name = name;
            _url = url;
            _password = password;

            client = new JabbRClient(_url);
        }

        public string Name { get; private set; }

        public void PowerUp()
        {
            client.MessageReceived += (message, room) =>
            {
                Console.WriteLine("{0} {1} {2}", room, message.Content, message.User.Name);
                client.Send("Received " + message.Content + " from " + message.User.Name + " in " + room, room);
            };


            client.Connect(Name, _password).ContinueWith(task =>
            {
                if (!task.IsFaulted)
                {
                    client.JoinRoom("twitterbot");
                }
                else
                {
                    Console.WriteLine(task.Exception);
                }
            });
        }

    }
}
