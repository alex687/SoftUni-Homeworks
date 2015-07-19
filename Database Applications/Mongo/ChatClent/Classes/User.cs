using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatClent.Classes
{
    public class User
    {

        public User(string username)
        {
            this.Username = username;
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        public User(string username, string id)
        {
            this.Username = username;
            this.Id = id;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }

        public override string ToString()
        {
            return this.Username;
        }
    }
}
