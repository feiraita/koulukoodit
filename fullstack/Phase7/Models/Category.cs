using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Phase7.Models {
    public class Category {

        [BsonId]
        public ObjectId _id { get; set; }

        public string name { get; set; } = "";
        public bool? monthlyLimit { get; set; }
        public decimal? amount { get; set; }
        public decimal? total { get; set; }

        public Category() { }
    }
}
