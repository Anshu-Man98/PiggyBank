using System;
using System.Collections.Generic;
using PiggyBank.ViewModel;
using Xamarin.Forms;

namespace PiggyBank.View
{
    public partial class ExpenceListViewPage : ContentPage
    {
        public ExpenceListViewPage()
        {
            InitializeComponent();
            BindingContext = new ExpenditureVM();
        }

        void AddExpense(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Expenditure());
        }

        protected override void OnAppearing()
        {
            //Write the code of your page here
            base.OnAppearing();
        }
    }
}
