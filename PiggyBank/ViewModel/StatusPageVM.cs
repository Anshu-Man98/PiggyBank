using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PiggyBank.Model;
using System.Collections.Generic;
using System.Linq;
using Microcharts;
using SkiaSharp;

namespace PiggyBank.ViewModel
{
    public class StatusPageVM
    {

        private readonly IUserDatabase _userDatabase;

        public StatusPageVM()
        {
            this._userDatabase = DependencyService.Get<IUserDatabase>();
            greatUser();
            setMonth();
            ExpenditureStatus();
            DisplayBalancePieChart();
            DisplayLineChart();
        }

        public string totalBalanceText = "";
        public string monthBalanceText = "";
        public string nikName = "user";
        public string currentMonth = "This Month";
        public DonutChart donutChart = null;
        public LineChart lineChart = null;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
            set { nikName = value; OnPropertyChanged(nameof(UserName)); }
            get { return nikName; }
        }

        public string Month
        {
            set { currentMonth = value; OnPropertyChanged(nameof(Month)); }
            get { return currentMonth; }
        }

        public LineChart LineChart
        {
            set { lineChart = value; OnPropertyChanged(nameof(lineChart)); }
            get { return lineChart; }
        }

        public DonutChart DonutChart
        {
            set { donutChart = value; OnPropertyChanged(nameof(donutChart)); }
            get { return donutChart; }
        }

        public void greatUser()
        {
            UserName = "Hi " + _userDatabase.getUserNikName();
        }

        public void setMonth()
        { 
            DateTime dt = DateTime.Now;
            string thisMonth = dt.ToString("MM");
            currentMonth = thisMonth;
        }

        public void ExpenditureStatus()
        {
            var amt = _userDatabase.getUserBalanceAndIncome();
            var expense = _userDatabase.TotalUserExpense();

            double overallExpense = amt[0] + expense;

            double monthExpence = amt[1] + expense;

            TotalBalanceText = overallExpense.ToString();

            MonthBalanceText = monthExpence.ToString();
        }

        private void DisplayLineChart()
        {
            var entries = new[]
            {
             new ChartEntry(10)
             {
                 Color = SKColor.Parse("#02FFC2")
             },
             new ChartEntry(0)
             {
                 Color = SKColor.Parse("#05D2FF")
             },
             new ChartEntry(0)
             {
                 Color = SKColor.Parse("#00A1C5")
             },
             new ChartEntry(0)
             {
                 Color = SKColor.Parse("#007EEC")
             },
             new ChartEntry(0)
             {
                 Color = SKColor.Parse("#03579c")
             }
        };

            var lineChartt = new LineChart()
            {
                Entries = entries,
                IsAnimated = true,
                BackgroundColor = SKColors.Transparent,
                PointSize = 35,
                LineSize = 8
            };

            LineChart = lineChartt;
        }

        private void DisplayBalancePieChart()
        {
            var entries = new[]
            {
                 new ChartEntry(148)
                 {
                     Color = SKColor.Parse("#065BFF")
                 },
                new ChartEntry(108)
                 {
                     Color = SKColor.Parse("#5791FF")
                 }

            };

            var chartt = new DonutChart()
            {
                Entries = entries,
                IsAnimated = true,
                BackgroundColor = SKColors.Transparent
            };
            DonutChart = chartt;
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
