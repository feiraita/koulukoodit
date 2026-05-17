using System.Globalization;
using System.Text.Json;

namespace DataVisualisation.Models {
    public class StatsViewModel {
        public List<Stats> stats { get; set; } = new();
        public Dictionary<string, int> GamesPerMonth { get; set; } = new();
        public Dictionary<string, int> ScorePerMonth { get; set; } = new();

        public string GetGPM_Labels {
            get {
                if (GamesPerMonth.Count() > 1) {
                    var Months = JsonSerializer.Serialize(GamesPerMonth.Keys);
                    return Months;
                } else return "[]";
            }
        }
        public string GetGPM_Data {
            get {
                if (GamesPerMonth.Count() > 1) {
                    var datas = JsonSerializer.Serialize(GamesPerMonth.Values);
                    return datas;
                } else return "[]";
            }
        }

        public string GetGPM_Data {
            get {
                if (GamesPerMonthDelta.Count() > 1) {
                    var datas = JsonSerializer.Serialize(GamesPerMonthDelta.Values);
                    return datas;
                } else return "[]";
            }
        }

        public StatsViewModel(List<Stats> stats) {
            this.stats = stats;
            GamesPerMonth = new Dictionary<string, int>();
            if (stats.Count() > 1) {
                var minDate = stats.OrderBy(e => e.TimeStamp).First().Date;
                var maxDate = stats.OrderByDescending(e => e.TimeStamp).First().Date;
                var Dates = new List<string>();
                int maxIterations = 0;
                while (minDate <= maxDate) {
                    var DateToAdd = CreateMonthYearPair(minDate);

                    if (!Dates.Contains(DateToAdd))
                        Dates.Add(DateToAdd);

                    maxIterations++;
                    if (maxIterations > 100)
                        break;

                    minDate = minDate.AddMonths(1);
                }

                foreach (var date in Dates) {
                    var gamesInThisDate = stats.Where(e =>
                                                CreateMonthYearPair(e.Date) == date)
                                                .Count();
                    GamesPerMonth.Add(date, gamesInThisDate);
                }
            }
        }

        private string CreateMonthYearPair(DateTime dateTime) {
            return dateTime.ToString("MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}