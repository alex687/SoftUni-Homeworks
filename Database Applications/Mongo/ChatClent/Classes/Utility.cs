using MongoDB.Driver;

namespace ChatClent.Classes
{
    class Utility
    {
    	// Put here your MongoLabUrl
        private const string MongoLabUrl = "";
        public  static MongoUrl ConnectionUrl = new MongoUrl(MongoLabUrl);

        public static bool IsValidUsername(string username)
        {
            if (username.Length >= 3 && username.Length <= 10)
            {
                return true;
            }
            return false;
        }
    }
}
