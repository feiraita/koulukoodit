using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Phase7.Models {
    public class User {
        [BsonId]
        public ObjectId _id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public decimal? balance { get; set; } = 0;

        public List<Category> categories { get; set; } = new List<Category>();
        public List<SavingGoal> savings { get; set; } = new List<SavingGoal>();


        public User() { }
    }
}
