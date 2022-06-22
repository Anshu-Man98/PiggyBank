using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PiggyBank.Model;
using System.Collections.Generic;
using System.Linq;

namespace PiggyBank.ViewModel
{
    public class StatusPageVM
    {

        private readonly IUserDatabase _userDatabase;

        public StatusPageVM()
        {
            int UserId = LoginPageVM.UserId;
            this._userDatabase = DependencyService.Get<IUserDatabase>();
            userName = _userDatabase.getUserName(UserId);
            setMonth();
            ExpenditureStatus(UserId);

        }




        public double totalBalance = 0.6;
        public double monthBalance = 0.7;
        public string totalBalanceText = "";
        public string monthBalanceText = "30000";
        public string userName = "user";
        public string month = "This Month";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public double TotalBalance
        {
            set { totalBalance = value; }
            get { return totalBalance; }
        }

        public double MonthBalance
        {
            set { monthBalance = value; OnPropertyChanged(nameof(MonthBalance)); }
            get { return monthBalance; }
        }

        public string MonthBalanceText
        {
            set { monthBalanceText = value; OnPropertyChanged(nameof(MonthBalanceText)); }
            get { return monthBalanceText; }
        }

        public string TotalBalanceText
        {
            set { totalBalanceText = value; OnPropertyChanged(nameof(TotalBalanceText)); }
            get { return totalBalanceText; }
        }

        public string UserName
        {
            set { userName = value; OnPropertyChanged(nameof(UserName)); }
            get { return userName; }
        }

        public string Month
        {
            set { month = value; OnPropertyChanged(nameof(Month)); }
            get { return month; }
        }

        public void setMonth()
        {
            
            DateTime dt = DateTime.Now;
            string thisMonth = dt.ToString("MMMM");
            month = thisMonth;
        }

        public void ExpenditureStatus(int UserId)
        {
            var amt = _userDatabase.getUserAmt(UserId);
            var expense = _userDatabase.TotalUserExpense(UserId);

            double overallExpense = amt[1] + expense;

            double monthExpence = amt[0] + expense;

            TotalBalanceText = overallExpense.ToString();

            MonthBalanceText = monthExpence.ToString();


        }




        //public void setUserStatus(int userId)
        //{
        //    var UserListData = new List<UserStatus>() {
        //    new UserStatus() { UserId=1, Monthbalance=20000, TotalBalance=323123},
        //    new UserStatus() { UserId=2, Monthbalance=783222, TotalBalance=2836811 }
        //};

        //    foreach (var user in UserListData)
        //    {
        //        if (userId == user.UserId)
        //        {
        //            OnPropertyChanged(nameof(MonthBalanceText));
        //            OnPropertyChanged(nameof(TotalBalanceText));
        //            totalBalanceText = user.TotalBalance.ToString();
        //            monthBalanceText = user.Monthbalance.ToString();
        //            break;
        //        }
        //        else
        //        {
        //            totalBalanceText = "0";
        //            monthBalanceText = "0";
        //        }

        //    }
        //}
    }
}
