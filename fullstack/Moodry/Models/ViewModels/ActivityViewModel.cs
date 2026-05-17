using System.ComponentModel.DataAnnotations;

namespace Moodry.Models.ViewModels {
    public class ActivityViewModel {
        public List<Activity> activities { get; set; } = new();
        public List<string> selectedActivities { get; set; } = new();
        public string? customActivity { get; set; }
        public string defaultSvg => "icons/activities/default.svg";
    }
}