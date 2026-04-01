public class Answer {
    public int answerId { get; set; }
    public int first { get; set; }
    public int second { get; set; }

    public Answer() { }

    public Answer(int answerId, int first, int second) {
        this.answerId = answerId;
        this.first = first;
        this.second = second;
    }
}