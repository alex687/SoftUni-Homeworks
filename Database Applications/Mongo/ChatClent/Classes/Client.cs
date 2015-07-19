using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace ChatClent.Classes
{
    public static class Client
    {
        private static MongoDatabase Db;
        public static User User;

        public static bool AddUser()
        {
            try
            {
                OpenConnection();
                var userCollection = Db.GetCollection<User>("users");
                userCollection.Insert(User);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static bool AddNewMessage(string message)
        {
            try
            {
                var messages = Db.GetCollection<Message>("messages");
                messages.Insert(new Message(User, message));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Message> GetMessages(DateTime lastUpdate)
        {
            var messageCollection = Db.GetCollection<Message>("messages").AsQueryable<Message>().Where(m=>m.DateTime > lastUpdate).ToList();
            return messageCollection;
        }

        public static List<Message> GetAllMessages()
        {
            var messageCollection = Db.GetCollection<Message>("messages").FindAll().ToList();
            return messageCollection;
        }

        private static void OpenConnection()
        {
            var clent = new MongoClient(Utility.ConnectionUrl);
            var server = clent.GetServer();
            Db = server.GetDatabase("chat_db");
        }

        public static string GetOnlineUser()
        {
            var users = Db.GetCollection<User>("users").AsQueryable().Select(u=>u.Username).ToList();
            var result = String.Join(", ", users);
            return result;
        }

        public static void LogoutUser()
        {
            Db.GetCollection<User>("users").Remove(Query<User>.Where(u => u.Id == User.Id));
        }
    }
}
