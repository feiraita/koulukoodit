using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using Phase7.Models;
using Phase7.Models.Manipulators;
using Phase7.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Phase7.Controllers {
    [Authorize]
    public class PagesController : Controller {

        //Main page
        public IActionResult Index(string title) {
            ViewData["Title"] = title;

            var user = DatabaseManipulator.GetAll<User>().FirstOrDefault();

            var vm = new TransactionViewModel {
                ExpenseList = DatabaseManipulator.GetAll<Expense>(),
                IncomeList = DatabaseManipulator.GetAll<Income>(),
                Balance = user?.balance ?? 0
            };

            return View(vm);
        }
        public IActionResult UpcomingEvents(string title) {
            ViewData["Title"] = title;

            var user = DatabaseManipulator.GetAll<User>().FirstOrDefault();

            var vm = new TransactionViewModel {
                ExpenseList = DatabaseManipulator.GetAll<Expense>(),
                IncomeList = DatabaseManipulator.GetAll<Income>(),
                Balance = user?.balance ?? 0
            };

            return View(vm);
        }
        private List<Expense> ReadExpenses() {
            return DatabaseManipulator.GetAll<Expense>();
        }

        public IActionResult _AddExpense(string title) {
            ViewData["Title"] = title;

            var categories = DatabaseManipulator.GetAll<Category>();

            var vm = new ExpenseViewModel {
                Categories = categories
                    .Select(c => new SelectListItem {
                        Value = c.name,
                        Text = c.name
                    })
                    .ToList()
            };

            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _AddExpense(ExpenseViewModel vm) {
            if (!ModelState.IsValid) {
                vm.Expenses = ReadExpenses();

                vm.Categories = DatabaseManipulator.GetAll<Category>()
                    .Select(c => new SelectListItem {
                        Value = c.name,
                        Text = c.name
                    })
                    .ToList();

                return PartialView(vm);
            }

            var category = DatabaseManipulator
                .GetAll<Category>()
                .FirstOrDefault(c => c.name == vm.category);

            bool isOverLimit = false;

            if (category != null && category.monthlyLimit == true) {
                var now = DateTime.Now;

                var monthlyExpenses = DatabaseManipulator.GetAll<Expense>()
                    .Where(e =>
                        e.category == vm.category &&
                        e.date.Month == now.Month &&
                        e.date.Year == now.Year)
                    .Sum(e => e.amount);

                var newTotal = monthlyExpenses + vm.amount;
                category.total = newTotal;

                if (category.amount != null && newTotal > category.amount) {
                    isOverLimit = true;
                }
            }

            var expense = new Expense {
                category = vm.category,
                amount = vm.amount,
                date = vm.date,
                recurring = vm.recurring
            };

            DatabaseManipulator.SaveItem(expense);

            var user = DatabaseManipulator.GetAll<User>().FirstOrDefault();

            if (user != null) {
                user.balance = (user.balance ?? 0) - vm.amount;
                DatabaseManipulator.UpdateUser(user);
            }

            if (isOverLimit) {
                TempData["OverLimit"] = $"You have exceeded the monthly limit for {vm.category}!";
            }

            return RedirectToAction("Index");
        }

        public IActionResult _Balance() {
            return PartialView();
        }

        private List<Income> ReadIncomes() {
            return DatabaseManipulator.GetAll<Income>();
        }

        public IActionResult _AddIncome(string title) {
            ViewData["Title"] = title;

            var vm = new IncomeViewModel();
            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _AddIncome(IncomeViewModel vm) {
            if (!ModelState.IsValid) {
                vm.Incomes = ReadIncomes();
                return PartialView(vm);
            }

            var income = new Income {
                name = vm.name,
                amount = vm.amount,
                date = vm.date,
                recurring = vm.recurring
            };

            DatabaseManipulator.SaveItem(income);

            var user = DatabaseManipulator.GetAll<User>().FirstOrDefault();

            if (user != null) {
                user.balance = (user.balance ?? 0) + vm.amount;

                DatabaseManipulator.UpdateUser(user);
            }

            return RedirectToAction("Index");
        }


        //Budget page
        public IActionResult Budgets() {
            var categories = DatabaseManipulator.GetAll<Category>();
            var expenses = DatabaseManipulator.GetAll<Expense>();

            var now = DateTime.Now;

            var vm = new BudgetViewModel {
                WithLimit = categories
                    .Where(c => c.monthlyLimit == true)
                    .Select(c => new CategoryViewModel {
                        categoryID = c._id,
                        name = c.name,
                        amount = c.amount,
                        monthlyLimit = c.monthlyLimit,

                        total = expenses
                    .Where(e =>
                        e.category == c.name &&
                        e.date.Month == now.Month &&
                        e.date.Year == now.Year)
                    .Sum(e => (decimal)e.amount)
                    })
                    .ToList(),

                WithoutLimit = categories
                    .Where(c => c.monthlyLimit == false || c.monthlyLimit == null)
                    .Select(c => new CategoryViewModel {
                        categoryID = c._id,
                        name = c.name,
                        amount = c.amount,
                        monthlyLimit = c.monthlyLimit,

                        total = expenses
                            .Where(e =>
                                e.category == c.name &&
                                e.date.Month == now.Month &&
                                e.date.Year == now.Year)
                            .Sum(e => e.amount)
                    })
                    .ToList()
            };

            return View(vm);
        }

        public IActionResult BudgetsOpen(ObjectId id) {
            var category = DatabaseManipulator
                .GetAll<Category>()
                .FirstOrDefault(c => c._id == id);

            if (category == null)
                return NotFound();

            var expenses = DatabaseManipulator.GetAll<Expense>();

            var now = DateTime.Now;

            var categoryExpenses = expenses
                .Where(e => e.category == category.name)
                .OrderByDescending(e => e.date)
                .ToList();

            var total = categoryExpenses.Sum(e => (decimal)e.amount);

            var vm = new CategoryViewModel {
                categoryID = category._id,
                name = category.name,
                amount = category.amount,
                monthlyLimit = category.monthlyLimit,
                total = total,
                Expenses = categoryExpenses
            };

            return View(vm);
        }

        //Categories
        public IActionResult _AddCategory(string title) {
            ViewData["Title"] = title;

            var vm = new CategoryViewModel();
            return PartialView(vm);
        }

        private List<Category> ReadCategories() {
            return DatabaseManipulator.GetAll<Category>();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _AddCategory(CategoryViewModel vm) {
            if (!ModelState.IsValid) {
                vm.Categories = ReadCategories();
                return PartialView(vm);
            }

            var category = new Category {
                name = vm.name,
                monthlyLimit = vm.monthlyLimit ?? false,
                amount = vm.amount
            };

            DatabaseManipulator.SaveItem(category);

            return RedirectToAction("Budgets");
        }

        public IActionResult _EditCategory(ObjectId id) {
            var category = DatabaseManipulator
                .GetAll<Category>()
                .FirstOrDefault(c => c._id == id);

            if (category == null) { return NotFound(); }

            var model = new CategoryViewModel {
                categoryID = category._id,
                name = category.name,
                monthlyLimit = category.monthlyLimit,
                amount = category.monthlyLimit == true ? category.amount : null
            };

            return PartialView(model); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _EditCategory(CategoryViewModel vm) {
            if (!ModelState.IsValid) {
                vm.Categories = ReadCategories();
                return PartialView(vm);
            }

            var category = new Category {
                _id = vm.categoryID,
                name = vm.name,
                monthlyLimit = vm.monthlyLimit ?? false,
                amount = vm.monthlyLimit == true ? vm.amount : null
            };

            DatabaseManipulator.UpdateCategory(category);

            return RedirectToAction("Budgets");
        }

        //Savings
        private List<SavingGoal> ReadSavings() {
            return DatabaseManipulator.GetAll<SavingGoal>();
        }

        public IActionResult Savings() {
            var savings = DatabaseManipulator.GetAll<SavingGoal>();

            var vm = new SavingGoalViewModel {
                SavingGoals = savings
            };

            return View(vm);
        }

        public IActionResult SavingsOpen(ObjectId id) {
            var savings = DatabaseManipulator
                .GetAll<SavingGoal>()
                .FirstOrDefault(s => s._id == id);

            if (savings == null)
                return NotFound();

            var vm = new SavingGoalViewModel {
                savingID = savings._id,
                name = savings.name,
                goal = savings.goal,
                recurring = savings.recurring,
                payments = savings.payments,
                date = savings.date,
                total = savings.total
            };

            return View(vm);
        }

        public IActionResult _CreateSaving(string title) {
            ViewData["Title"] = title;

            var vm = new SavingGoalViewModel();
            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _CreateSaving(SavingGoalViewModel vm) {
            if (vm.recurring == true) {
                if (vm.payments == null)
                    ModelState.AddModelError("payments", "Required for recurring");

                if (vm.date == null)
                    ModelState.AddModelError("date", "Required for recurring");
            }

            if (!ModelState.IsValid) {
                vm.SavingGoals = ReadSavings();
                return PartialView(vm);
            }

            var saving = new SavingGoal {
                _id = ObjectId.GenerateNewId(),
                name = vm.name,
                goal = vm.goal,
                recurring = vm.recurring ?? false,
                payments = vm.recurring == true ? vm.payments : null,
                date = vm.recurring == true ? vm.date : null,
                total = 0
            };

            DatabaseManipulator.SaveItem(saving);

            var user = DatabaseManipulator.GetAll<User>().FirstOrDefault();
            if (user != null) {
                user.balance = (user.balance ?? 0) - (vm.amount ?? 0);
                DatabaseManipulator.UpdateUser(user);
            }

            return RedirectToAction("Savings");
        }

        public IActionResult _WithdrawFromSaving(string title) {
            ViewData["Title"] = title;

            var savings = DatabaseManipulator.GetAll<SavingGoal>();

            var vm = new SavingGoalViewModel {
                SavingGoalsList = savings
                    .Select(g => new SelectListItem {
                        Value = g._id.ToString(),
                        Text = g.name
                    })
                    .ToList()
            };

            return PartialView(vm);
        }


        public IActionResult _AddToSaving(string title) {
            ViewData["Title"] = title;

            var savings = DatabaseManipulator.GetAll<SavingGoal>();

            var vm = new SavingGoalViewModel {
                SavingGoalsList = savings
                    .Select(g => new SelectListItem {
                        Value = g._id.ToString(),
                        Text = g.name
                    })
                    .ToList()
            };

            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _AddToSaving(SavingGoalViewModel vm) {
            if (!ModelState.IsValid) {
                vm.SavingGoalsList = DatabaseManipulator.GetAll<SavingGoal>()
                    .Select(g => new SelectListItem {
                        Value = g._id.ToString(),
                        Text = g.name
                    })
                    .ToList();

                return PartialView(vm);
            }

            var saving = DatabaseManipulator
               .GetAll<SavingGoal>()
               .FirstOrDefault(s => s._id == vm.savingID);
            if (saving == null)
                return NotFound();

            saving.total = (saving.total ?? 0) + vm.amount.Value;

            DatabaseManipulator.UpdateSavingGoal(saving);

            return RedirectToAction("Savings");
        }

        public IActionResult _EditSaving(ObjectId id) {
            var saving = DatabaseManipulator
                .GetAll<SavingGoal>()
                .FirstOrDefault(c => c._id == id);

            if (saving == null) { return NotFound(); }

            var model = new SavingGoalViewModel {
                savingID = saving._id,
                name = saving.name,
                recurring = saving.recurring,
                payments = saving.recurring == true ? saving.payments : null,
                date = saving.recurring == true ? saving.date : null
            };

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _EditSaving(SavingGoalViewModel vm) {
            if (!ModelState.IsValid) {
                vm.SavingGoals = ReadSavings();
                return PartialView(vm);
            }

            var saving = new SavingGoal {
                _id = vm.savingID,
                name = vm.name,
                recurring = vm.recurring ?? false,
                payments = vm.recurring == true ? vm.payments : null,
                date = vm.recurring == true ? vm.date : null
            };

            DatabaseManipulator.UpdateSavingGoal(saving);

            return RedirectToAction("Savings");
        }

    }
}