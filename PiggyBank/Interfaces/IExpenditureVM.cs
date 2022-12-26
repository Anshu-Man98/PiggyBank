using System.Collections.Generic;
using System.ComponentModel;
using PiggyBank.Model;

namespace PiggyBank.ViewModel
{
    public interface IExpenditureVM
    {
        string TotalBalance { get; set; }
        string MonthBalance { get; set; }
        List<UserExpenditure> UserExpense { get; set; }
        int HeightRequest { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void getUserExpense(int UserId);
        void setAmount(int UserId);
    }
}