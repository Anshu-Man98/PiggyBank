using System;
using System.Collections.Generic;
using PiggyBank.Model;
using PiggyBank.ViewModel;
using Xamarin.Forms;

namespace PiggyBank.View
{
    public partial class MainPageTab : TabbedPage
    {
        public MainPageTab()
        {
            Children.Add(new StatusPage() { Title = "Expenditure" });
            Children.Add(new AddExpenditure() { Title = "Transactions" });

            InitializeComponent();

        }

        //public MainPageTab(int userId)
        //{
            
        //    Children.Add(new StatusPage(userId) { Title = "Expenditure" });
        //    Children.Add(new AddExpenditure(userId) { Title = "Transactions"});

        //    InitializeComponent();

            
            
        //}
    }
}
