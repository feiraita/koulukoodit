using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Moodry.Models {
    public class User {
        [BsonId]
        public ObjectId _id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public List<Activity> activities { get; set; } = new List<Activity>();

        public User() { }
    }
}
