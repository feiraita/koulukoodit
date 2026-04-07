using MongoDB.Bson;

namespace MongoDB_testi.Models {
    public class Auto : SaveableObject {
        public string merkki { get; set; } = string.Empty;
        public Auto() { }
    }
}
