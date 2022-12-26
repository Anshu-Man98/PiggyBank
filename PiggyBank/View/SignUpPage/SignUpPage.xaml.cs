using System;
using System.Collections.Generic;
using PiggyBank.ViewModel;
using Xamarin.Forms;

namespace PiggyBank
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new SignUpVM(Navigation);
        }
    }
}
