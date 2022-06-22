using System;
using System.Collections.Generic;
using PiggyBank.ViewModel;
//using PiggyBank.Persistence;
using SQLite;
using Xamarin.Forms;

namespace PiggyBank
{
    
    public partial class LoginPage : ContentPage
    { 
      
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageVM(Navigation);
            // _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


        }

        //protected async override void OnAppearing()
        // {
        //await _connection.CreateTableAsync<LoginData>();
        //var results = await _connection.Table<LoginData>().ToListAsync();
        //_LoginPageViewModel = new LoginPageViewModel(results);
        //  base.OnAppearing();
        //  }

        //public void Submitname(object sender, EventArgs args)
        //{
        //        password.Focus();
        //}

        //public async void Submitpass(object sender, EventArgs args)
        //{
        //    if (name.Text.Length >= 4 && password.Text.Length >= 4)
        //    {
        //       await DisplayAlert("Alert", name.Text, "OK");

        //    }
        //    if (name.Text.Length <= 0 || password.Text.Length <= 0)
        //    {
        //        await DisplayAlert("Alert", "Credentials invalid! Try again", "OK");
        //    }
        //}

        //public async void LoginButton_Clicked(object sender, EventArgs e)
        //{
        //    bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        //}

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs args)
        {

            await Navigation.PushModalAsync(new SignUpPage());
        }
    }
}
