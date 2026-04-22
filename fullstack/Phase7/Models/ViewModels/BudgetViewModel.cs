namespace Phase7.Models.ViewModels {
    public class BudgetViewModel {
        public List<CategoryViewModel> WithLimit { get; set; } = new();
        public List<CategoryViewModel> WithoutLimit { get; set; } = new();
    }
}