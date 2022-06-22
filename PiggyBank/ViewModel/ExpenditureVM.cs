using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PiggyBank.Model;
using Xamarin.Forms;

namespace PiggyBank.ViewModel
{
    public class ExpenditureVM : IExpenditureVM
    {
        private readonly IUserDatabase _userDatabase;
        public ExpenditureVM()
        {
            int UserId = LoginPageVM.UserId;
            this._userDatabase = DependencyService.Get<IUserDatabase>();
            setAmount(UserId);

            getUserExpense(UserId);

        }

        public string balance = "";
        public string salary = "";
        public List<UserExpenditure> userExpense = null;
        public int heightRequest = 150;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string TotalBalance
        {
            set { balance = value; OnPropertyChanged(nameof(TotalBalance)); }
            get { return balance; }
        }

        public string MonthBalance
        {
            set { salary = value; OnPropertyChanged(nameof(MonthBalance)); }
            get { return salary; }
        }

        public List<UserExpenditure> UserExpense
        {
            set { userExpense = value; OnPropertyChanged(nameof(UserExpense)); }
            get { return userExpense; }
        }

        public int HeightRequest
        {
            set { heightRequest = value; OnPropertyChanged(nameof(HeightRequest)); }
            get { return heightRequest; }
        }


        public void setAmount(int UserId)
        {
            var amt = _userDatabase.getUserAmt(UserId);
            balance = amt[1].ToString();
            salary = amt[0].ToString();

        }

        public void getUserExpense(int UserId)
        {
            userExpense = _userDatabase.getUserExpense(UserId);

            switch (userExpense.Count)
            {
                case 0:
                    heightRequest = 150;
                    break;
                default:
                    heightRequest = 150 * userExpense.Count;
                    break;
            }

        }

    }
}
