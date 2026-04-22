using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Phase7.Models {
    public class Expense {

        [BsonId]
        public ObjectId _id { get; set; }
        public ObjectId userId { get; set; }
        public string category { get; set; } = "";
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public string recurring { get; set; } = "";

        public Expense() { }
    }
}