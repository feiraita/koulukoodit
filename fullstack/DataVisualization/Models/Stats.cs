namespace DataVisualisation.Models {
    public class Stats {
        public double Score { get; set; }
        public long TimeStamp { get; set; }
        public DateTime Date {
            get {
                return new DateTime(TimeStamp);
            }
        }

        public Stats(double score, DateTime timeStamp) {
            Score = score;
            TimeStamp = timeStamp.Ticks;
        }
        public Stats() { }
    }
}