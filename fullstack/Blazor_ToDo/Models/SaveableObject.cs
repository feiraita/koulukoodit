using Blazor_ToDo.Manipulators;
using MongoDB.Bson;

namespace Blazor_ToDo.Models {
    public class SaveableObject {
        public ObjectId _id { get; set; }

        public void Save() {
            DatabaseManipulator.SaveTodo(this);
        }
    }
}
