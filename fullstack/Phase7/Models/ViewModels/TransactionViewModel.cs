namespace Phase7.Models.ViewModels {
    public class TransactionViewModel {
        public List<Expense> ExpenseList { get; set; } = new();
        public List<Income> IncomeList { get; set; } = new();

        public decimal Balance { get; set; } = 0;

        public List<Category> Categories { get; set; } = new();
        public List<SavingGoal> Savings { get; set; } = new();
    }
}