using Moodry.Models;

namespace Moodry.Models.ViewModels {
    public class EntriesViewModel {
        public List<Entry> Entries { get; set; }
        public Dictionary<string, Activity> Activities { get; set; }
        public List<int> AvailableYears { get; set; }
    }
}