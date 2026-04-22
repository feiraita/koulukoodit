namespace BlazorCoreHybrid.Models {
    public class Todo : SaveableObject {
        public string Text { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
    }
}