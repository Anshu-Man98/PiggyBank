using System;
using System.Collections.Generic;
using PiggyBank.Model;

namespace PiggyBank.ViewModel
{
    public interface IUserDatabase
    { 
        void addUserData(LoginData userData);
        List<ExpenceCategory> Expencecategories();
        double[] getUserBalanceAndIncome();
        string getUserNikName();
        List<UserExpenditure> getUserExpense(int userId);
        double TotalUserExpense();
        void addUserExpense(UserExpenditure expense);
    }
}
