using System;
using System.Collections.Generic;
using PiggyBank.ViewModel;
using Xamarin.Forms;

namespace PiggyBank.View
{
    public partial class Expenditure : ContentPage
    {
        public Expenditure()
        {
            InitializeComponent();
            BindingContext = new AddExpenseVM();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();

        }

        protected override void OnAppearing()
        {
            //Write the code of your page here
            base.OnAppearing();
        }
    }
}
