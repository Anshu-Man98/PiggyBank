using System;
using System.Collections.Generic;
using PiggyBank.Model;

namespace PiggyBank.ViewModel
{
    public interface IUserDatabase
    {
        List<LoginData> UsrData();
        double[] getUserAmt(int userId);
        void addUserData(LoginData userData);
        string getUserName(int userId);
        List<UserExpenditure> getUserExpense(int userId);
        double TotalUserExpense(int userId);
        void addUserExpense(UserExpenditure expense);
    }
}
