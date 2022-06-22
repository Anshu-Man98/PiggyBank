using System;
using System.Collections.Generic;
using PiggyBank.ViewModel;
using Xamarin.Forms;

namespace PiggyBank.View
{
    public partial class StatusPage : ContentPage
    {


        public StatusPage()
        {
            InitializeComponent();
            BindingContext = new StatusPageVM();
            
        }

        void LogOut(System.Object sender, System.EventArgs e)
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
