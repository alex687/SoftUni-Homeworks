using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatClent.Classes
{
    public class Message
    {
        public Message(User user, string text)
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            this.User = user;
            this.Text = text;
            this.DateTime = DateTime.Now;
        }

        public Message(string id, User user, string text, DateTime dateTime)
        {
            this.Id = id;
            this.User = user;
            this.Text = text;
            this.DateTime = dateTime;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime DateTime{get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            return string.Format("User: {2}, Message: {0}, Time: {1}",
                this.Text,
                this.DateTime.ToShortTimeString(),
                this.User);
        }
    }
}
