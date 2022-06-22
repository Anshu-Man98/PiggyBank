using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using PiggyBank.Model;
using PiggyBank.View;
using Xamarin.Forms;

namespace PiggyBank.ViewModel
{
    public class AddExpenseVM:INotifyPropertyChanged
    {
        private readonly IUserDatabase _userDatabase;
        private readonly IExpenditureVM _expenditureVM;
        public AddExpenseVM()
        {
            SubmitExpenceCommand = new Command(() => SubmitExpence());
            this._userDatabase = DependencyService.Get<IUserDatabase>();
            this._expenditureVM = DependencyService.Get<IExpenditureVM>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string amount = string.Empty;
        public string comment = string.Empty;
        public string color = "DarkRed";
        public bool isExpence = false;

        public Command SubmitExpenceCommand { get; }


        public bool IsExpence
        {
            set { isExpence = value;
                if(isExpence == true)
                {
                    Color = "DarkRed";
                    Amount = "-" + amount;
                }
                else
                {
                    Color = "LightGreen";
                    if (amount.Contains("-"))
                    {
                        var updatedAmount = amount.Remove(0,1);
                        Amount = updatedAmount;
                    }
                    else
                    {
                        Amount = amount;
                    }
                    
                
            }
                OnPropertyChanged(nameof(IsExpence)); OnPropertyChanged(nameof(Amount)); OnPropertyChanged(nameof(Color)); }
            get { return isExpence; }
        }

        public string Amount
        {
            set {

                amount = value;
            ; OnPropertyChanged(nameof(Amount)); }
            get { return amount; }
        }

        public string Comment
        {
            set { comment = value; OnPropertyChanged(nameof(Comment)); }
            get { return comment; }
        }

        public string Color
        {
            set {

                    color = value;
                   OnPropertyChanged(nameof(Color)); }
            get { return color; }
        }


        private void SubmitExpence()
        {
            UserExpenditure UserExpendituresList =
            new UserExpenditure() { Id = 6, UserId = LoginPageVM.UserId, Amount = Convert.ToDouble(this.Amount), isExpense = this.IsExpence, comments = this.Comment, color = this.Color, date = DateTime.Now.Date.ToString("dd/MM/yyyy") };
            _userDatabase.addUserExpense(UserExpendituresList);
            _expenditureVM.getUserExpense(LoginPageVM.UserId);
            

        }

    }
}
