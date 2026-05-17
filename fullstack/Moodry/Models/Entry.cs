using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Moodry.Models {
    public class Entry {
        [BsonId]
        public ObjectId _id { get; set; }

        public string userID { get; set; }
        public string mood { get; set; }
        public string moodDescription { get; set; }
        public string note { get; set; }

        public List<ObjectId> ActivityIDs { get; set; } = new();

        public string entryDate { get; set; }
        public string entryTime { get; set; }

        public int MoodScore =>
        mood switch {
            "sad" => 1,
            "neutral" => 2,
            "smile" => 3,
            "content" => 4,
            _ => 2
        };

        public static string ScoreToMood(double score) {
            if (score < 1.5) { return "sad"; }
            if (score < 2.5) { return "neutral"; }
            if (score < 3.5) { return "smile"; }

            return "content";
        }
    }
}