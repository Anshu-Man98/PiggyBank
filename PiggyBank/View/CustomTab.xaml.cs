using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiggyBank.View.AddExpensePage;
using Xamarin.Forms;

namespace PiggyBank.View
{
    public partial class CustomTab : ContentPage
    {
        public CustomTab()
        {
            InitializeComponent();
        }


        void TabViewItem_TabTapped(System.Object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
            
            Navigation.PushModalAsync(new AddExpenceIncomePage());
           
        }
    }
}

