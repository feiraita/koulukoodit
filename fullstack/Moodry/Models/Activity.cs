using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Moodry.Models {
    public class Activity {
        [BsonId]
        public ObjectId _id { get; set; }

        public string title { get; set; }
        public string svg { get; set; }


        // null = global activity or custom activity
        public string? userID { get; set; }
    }
}