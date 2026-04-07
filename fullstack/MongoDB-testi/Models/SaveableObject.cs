using MongoDB.Bson;
using MongoDB_testi.Models.Manipulators;

namespace MongoDB_testi.Models {
    public class SaveableObject {
        public ObjectId _id { get; set; }

        public void Save() {
            DatabaseManipulator.SaveAuto(this);
        }
    }
}
