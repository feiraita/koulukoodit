using BlazorCoreHybrid.Manipulators;
using MongoDB.Bson;

namespace BlazorCoreHybrid.Models {
    public class SaveableObject {
        public ObjectId _id { get; set; }

        public void Save() {
            DatabaseManipulator.SaveTodo(this);
        }
    }
}
