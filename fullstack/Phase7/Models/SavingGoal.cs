using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Phase7.Models {
    public class SavingGoal {

        [BsonId]
        public ObjectId _id { get; set; }

        public string name { get; set; } = "";

        public int goal { get; set; }

        public bool? recurring { get; set; }

        public int? payments { get; set; }

        public DateTime? date { get; set; }

        public decimal? total { get; set; }

        public SavingGoal() { }
    }
}