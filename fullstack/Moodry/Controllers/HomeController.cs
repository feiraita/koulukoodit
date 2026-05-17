using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moodry.Models;
using Moodry.Models.Manipulators;
using Moodry.Models.ViewModels;

namespace Moodry.Controllers {
    [Authorize]
    public class HomeController : Controller {

        public IActionResult Index() { return View(); }

        public class MoodCounts {
            public int content { get; set; }
            public int smile { get; set; }
            public int neutral { get; set; }
            public int sad { get; set; }
        }

        public class ActivityStat {
            public string title { get; set; }
            public string svg { get; set; }
            public int count { get; set; }
        }

        public class MoodActivity {
            public string title { get; set; }
            public string svg { get; set; }
            public int count { get; set; }
        }

        public class StatisticsViewModel {
            public MoodCounts moodCounts { get; set; }
            public List<ActivityStat> topActivities { get; set; }
            public Dictionary<string, List<MoodActivity>> moodActivities { get; set; }
        }

        [HttpGet]
        public IActionResult GetStatistics() {
            var userId = User.Identity?.Name;

            if (string.IsNullOrEmpty(userId)) {
                return Json(new StatisticsViewModel {
                    moodCounts = new MoodCounts { content = 0, smile = 0, neutral = 0, sad = 0 },
                    topActivities = new List<ActivityStat>(),
                    moodActivities = new Dictionary<string, List<MoodActivity>>()
                });
            }

            var userEntries = DatabaseManipulator.GetAll<Entry>()
                .Where(e => e.userID == userId).ToList();

            // Count moods
            var moodCounts = new MoodCounts {
                content = userEntries.Count(e => e.mood == "content"),
                smile = userEntries.Count(e => e.mood == "smile"),
                neutral = userEntries.Count(e => e.mood == "neutral"),
                sad = userEntries.Count(e => e.mood == "sad")
            };

            // Get activities
            var allActivities = DatabaseManipulator.GetAll<Activity>()
                .Where(a => a.userID == null || a.userID == userId).ToList();

            var activityCounts = new Dictionary<string, ActivityStat>();

            foreach (var entry in userEntries) {
                foreach (var activityId in entry.ActivityIDs) {
                    var activity = allActivities.FirstOrDefault(a => a._id == activityId);
                    if (activity != null) {
                        var activityKey = activity._id.ToString();
                        if (!activityCounts.ContainsKey(activityKey)) {
                            activityCounts[activityKey] = new ActivityStat {
                                title = activity.title,
                                svg = activity.svg ?? "default.svg",
                                count = 0
                            };
                        }
                        activityCounts[activityKey].count++;
                    }
                }
            }

            // top 4
            var topActivities = activityCounts.Values
                .OrderByDescending(a => a.count).Take(4).ToList();

            var moodActivities = new Dictionary<string, List<MoodActivity>>();
            var moods = new[] { "content", "smile", "neutral", "sad" };

            foreach (var mood in moods) {
                var moodEntries = userEntries.Where(e => e.mood == mood).ToList();
                var moodActivityCounts = new Dictionary<string, MoodActivity>();

                foreach (var entry in moodEntries) {
                    foreach (var activityId in entry.ActivityIDs) {
                        var activity = allActivities.FirstOrDefault(a => a._id == activityId);
                        if (activity != null) {
                            var activityKey = activity._id.ToString();
                            if (!moodActivityCounts.ContainsKey(activityKey)) {
                                moodActivityCounts[activityKey] = new MoodActivity {
                                    title = activity.title,
                                    svg = activity.svg ?? "default.svg",
                                    count = 0
                                };
                            }
                            moodActivityCounts[activityKey].count++;
                        }
                    }
                }

                // top3 activities for mood
                var topMoodActivities = moodActivityCounts.Values
                    .OrderByDescending(a => a.count).Take(3).ToList();

                moodActivities[mood] = topMoodActivities;
            }

            var result = new StatisticsViewModel {
                moodCounts = moodCounts,
                topActivities = topActivities,
                moodActivities = moodActivities
            };

            return Json(result);
        }

        public IActionResult _Calendar(int month) {
            var userId = User.Identity?.Name;
            List<Entry> userEntries = null;

            if (!string.IsNullOrEmpty(userId)) {
                userEntries = DatabaseManipulator.GetAll<Entry>()
                    .Where(e => e.userID == userId).ToList();
            }

            var vm = new CalendarViewModel(month, userEntries);
            return PartialView(vm);
        }

        public IActionResult Entries(int? year) {
            var userId = User.Identity?.Name;
            var allUserEntries = DatabaseManipulator.GetAll<Entry>().Where(e => e.userID == userId).ToList();

            var availableYears = allUserEntries
                .Select(e => {
                    DateTime.TryParse(e.entryDate, out DateTime date);
                    return date.Year;
                }).Distinct().OrderByDescending(y => y).ToList();

            if (!availableYears.Any()) { availableYears.Add(DateTime.Now.Year); }

            var selectedYear = year ?? availableYears.First();

            var entries = allUserEntries
                .Where(e => {
                    DateTime.TryParse(e.entryDate, out DateTime date);
                    return date.Year == selectedYear;
                }).ToList();

            var allActivities = DatabaseManipulator.GetAll<Activity>()
                .Where(a => a.userID == null || a.userID == userId).ToList();

            var activitiesDict = allActivities.ToDictionary(a => a._id.ToString(), a => a);

            var vm = new EntriesViewModel {
                Entries = entries,
                Activities = activitiesDict,
                AvailableYears = availableYears
            };

            ViewBag.SelectedYear = selectedYear;

            return View(vm);
        }

        public IActionResult EntriesOpen(int year, int month, int? day = null) {
            var userId = User.Identity?.Name;
            var entries = DatabaseManipulator.GetAll<Entry>()
                .Where(e => e.userID == userId).ToList()
                .Where(e => {
                    DateTime.TryParse(e.entryDate, out DateTime date);
                    return date.Year == year && date.Month == month;
                }).ToList();

            var allActivities = DatabaseManipulator.GetAll<Activity>()
                .Where(a => a.userID == null || a.userID == userId).ToList();

            var activitiesDict = allActivities.ToDictionary(a => a._id.ToString(), a => a);

            var vm = new EntriesViewModel {
                Entries = entries,
                Activities = activitiesDict
            };

            ViewBag.Month = new DateTime(year, month, 1).ToString("MMMM");
            ViewBag.Year = year;
            ViewBag.SelectedDay = day;

            return View(vm);
        }

        public IActionResult Mood(string date = null) {
            ModelState.Clear();
            var now = DateTime.Now;

            DateTime selectedDate;
            if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out selectedDate)) {
            } else { selectedDate = now; }

            var vm = new EntryViewModel {
                date = selectedDate.ToString("yyyy-MM-dd"),
                time = now.ToString("HH:mm"),

                Activity = new ActivityViewModel {
                    activities = DatabaseManipulator.GetAll<Activity>()
                        .Where(a => a.userID == null || a.userID == User.Identity?.Name).ToList(),
                    selectedActivities = new List<string>()
                },
                Mood = new MoodViewModel(),
                Notes = new NotesViewModel()
            };

            return View(vm);
        }

        public IActionResult _Mood(EntryViewModel model) { return PartialView(model); }

        public IActionResult _Activity() {
            var vm = new EntryViewModel {
                Activity = new ActivityViewModel {
                    activities = DatabaseManipulator.GetAll<Activity>()
                        .Where(a => a.userID == null || a.userID == User.Identity?.Name).ToList(),
                    selectedActivities = new List<string>()
                }
            };

            return PartialView(vm);
        }

        public IActionResult _Notes() { return PartialView(new EntryViewModel()); }

        public IActionResult _Submit(EntryViewModel vm) { return PartialView(vm); }

        [HttpPost]
        public IActionResult Submit(EntryViewModel model) {
            ModelState.Remove("Mood.description");
            ModelState.Remove("Notes.text");

            if (!ModelState.IsValid) {
                model.Activity.activities = DatabaseManipulator.GetAll<Activity>()
                    .Where(a => a.userID == null || a.userID == User.Identity?.Name).ToList();
                return View("Mood", model);
            }

            var selectedIds = model.Activity.selectedActivities ?? new List<string>();

            var activityIds = selectedIds.Where(id => ObjectId.TryParse(id, out _)).Select(ObjectId.Parse).ToList();

            if (!string.IsNullOrWhiteSpace(model.Activity.customActivity)) {
                var custom = new Activity {
                    title = model.Activity.customActivity,
                    svg = "default.svg",
                    userID = User.Identity?.Name
                };
                DatabaseManipulator.SaveItem(custom);
                activityIds.Add(custom._id);
            }

            var moodDescription = string.IsNullOrWhiteSpace(model.Mood?.description)
                ? model.Mood?.mood ?? "" : model.Mood.description;

            var entry = new Entry {
                userID = User.Identity?.Name,
                mood = model.Mood?.mood ?? "",
                moodDescription = moodDescription,
                note = model.Notes?.text ?? "",
                ActivityIDs = activityIds,
                entryDate = model.date,
                entryTime = model.time
            };

            DatabaseManipulator.SaveItem(entry);

            return RedirectToAction("Entries");
        }
    }
}