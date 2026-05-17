using System.Globalization;
using System.Xml.Serialization;

namespace Moodry.Models.ViewModels {
    public class CalendarViewModel {
        public List<DateTime> dates { get; set; } = new List<DateTime>();
        public List<List<DateTime>> datesPerWeek { get; set; } = new List<List<DateTime>>();
        public int ObservableMonth { get; set; }
        public string MonthName { get; set; }

        // dict for daily moods
        public Dictionary<DateTime, double> DailyMoodScores { get; set; } = new Dictionary<DateTime, double>();

        public CalendarViewModel(int month, List<Entry> userEntries = null) {
            int thisYear = DateTime.Now.Year;
            var thisMonth = DateTime.Today.Month;
            var firstDayOfTheMonth = new DateTime(thisYear, thisMonth, 1);

            if (month > 0 && month < 13)
                firstDayOfTheMonth = new DateTime(thisYear, month, 1);

            ObservableMonth = firstDayOfTheMonth.Month;
            MonthName = getMonthName(ObservableMonth);

            var lastDayOfTheMonth = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

            var startDate = firstDayOfTheMonth;
            while (startDate.DayOfWeek != DayOfWeek.Monday) { startDate = startDate.AddDays(-1); }

            dates = new List<DateTime>();
            int increment = 0;
            while (dates.Count() == 0 || dates.Last() != lastDayOfTheMonth) {
                dates.Add(startDate.AddDays(increment));
                increment++;
            }

            while (dates.Last().DayOfWeek != DayOfWeek.Sunday) { dates.Add(dates.Last().AddDays(1)); }

            if (userEntries != null) {
                CalculateDailyMoodScores(userEntries);
            }

            //jaetaan viikkoihin
            int i = 0;
            while (i < dates.Count()) {
                var weekList = new List<DateTime>();
                while (i % 7 != 0 || weekList.Count() == 0) {
                    weekList.Add(dates[i]);
                    i++;
                }
                datesPerWeek.Add(weekList);
            }
        }

        private void CalculateDailyMoodScores(List<Entry> userEntries) {
            // entries by date
            var entriesByDate = userEntries
                .Where(e => DateTime.TryParse(e.entryDate, out _))
                .GroupBy(e => DateTime.Parse(e.entryDate).Date);

            foreach (var group in entriesByDate) {
                var averageScore = group.Average(e => e.MoodScore);
                DailyMoodScores[group.Key] = averageScore;
            }
        }

        public string getMonthName(int month) { return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month); }

        // CSS based on mood
        public string GetMoodColorClass(DateTime date) {
            if (!DailyMoodScores.ContainsKey(date)) { return "no-entry"; }

            double score = DailyMoodScores[date];

            if (score < 1.5) { return "mood-very-sad"; }
            if (score < 2.5) { return "mood-neutral"; }
            if (score < 3.5) { return "mood-smile"; }

            return "mood-content";
        }
    }
}