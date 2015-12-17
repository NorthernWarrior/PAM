using PAM.Models;
using PAM.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;

namespace PAM.ViewModels
{
    public class ExpensesViewModel : ViewModel
    {
        //****************************************************************************************************************

        private ObservableCollection<Expense> expenses;
        public ObservableCollection<Expense> Expenses
        {
            get { return expenses; }
            set
            {
                if (value == expenses)
                    return;
                expenses = value;
                OnPropertyChanged("Expenses");
            }
        }

        private Expense currentExpense;
        public Expense CurrentExpense
        {
            get { return currentExpense; }
            set
            {
                if (value == currentExpense)
                    return;
                currentExpense = value;
                OnPropertyChanged("CurrentExpense");
            }
        }

        private Expense selectedExpense;
        public Expense SelectedExpense
        {
            get { return selectedExpense; }
            set
            {
                if (value == selectedExpense)
                    return;
                selectedExpense = value;
                OnPropertyChanged("SelectedExpense");
                if (SelectedExpense != null)
                    CurrentExpense.Copy(SelectedExpense);
                else
                    CurrentExpense = new Expense();
            }
        }


        public Command ExpenseInsertCommand { get; private set; }
        public Command ExpenseChangeCommand { get; private set; }
        public Command ExpenseDeleteCommand { get; private set; }

        //****************************************************************************************************************

        public ExpensesViewModel()
        {
            Expenses = new ObservableCollection<Expense>() {
                new Expense{ Date = DateTime.Now, Value = 259.09f, Description = "Test 1" },
                new Expense{ Date = DateTime.Now, Value = 1436.53f, Description = "Test 2" },
                new Expense{ Date = DateTime.Now, Value = -345.45f, Description = "Test 3" },
                new Expense{ Date = DateTime.Now, Value = -0.45f, Description = "Test 4" },
            };

            CurrentExpense = new Expense();

            ExpenseInsertCommand = new Command(expenseInsert, () => (CurrentExpense != null && CurrentExpense.Date != null && !string.IsNullOrWhiteSpace(CurrentExpense.Description)));
            ExpenseChangeCommand = new Command(expenseChange, () => SelectedExpense != null);
            ExpenseDeleteCommand = new Command(expenseDelete, () => SelectedExpense != null);
        }

        //****************************************************************************************************************

        private void expenseInsert()
        {
            Expenses.Add(CurrentExpense.Clone());
            Expenses = new ObservableCollection<Expense>(Expenses.OrderByDescending(e => e.Date));
        }

        private void expenseChange()
        {
            SelectedExpense.Copy(CurrentExpense);
        }

        private void expenseDelete()
        {
            Expenses.Remove(SelectedExpense);
        }
    }
}
