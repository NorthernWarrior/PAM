using PAM.Models;
using PAM.MVVM;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PAM.ViewModels
{
    public class ExpensesViewModel : ViewModel
    {
        //****************************************************************************************************************

        private List<Expense> expenses;
        public List<Expense> Expenses
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

        //****************************************************************************************************************

        public ExpensesViewModel()
        {
            Expenses = new List<Expense>() {
                new Expense{ Date = DateTime.Now, Value = 259.09f, Description = "Test 1" },
                new Expense{ Date = DateTime.Now, Value = 1436.53f, Description = "Test 2" },
                new Expense{ Date = DateTime.Now, Value = -345.45f, Description = "Test 3" },
                new Expense{ Date = DateTime.Now, Value = -0.45f, Description = "Test 4" },
            };
        }

        //****************************************************************************************************************


    }
}
