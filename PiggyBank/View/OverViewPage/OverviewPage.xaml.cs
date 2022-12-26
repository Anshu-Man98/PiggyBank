using System;
using System.Collections.Generic;
using PiggyBank.ViewModel;
using Xamarin.Forms;

namespace PiggyBank.View.OverViewPage
{
    public partial class OverviewPage : ContentView
    {
        public OverviewPage()
        {
            InitializeComponent();
            BindingContext = new StatusPageVM();
        }

        async void SettingsTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfileSettingsPage());
        }
    }
}

