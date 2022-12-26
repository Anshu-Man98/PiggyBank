using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PiggyBank.View
{
    public partial class MainStatusPage : ContentView
    {
        public MainStatusPage()
        {
            InitializeComponent();
        }

        public string Title { get; internal set; }
    }
}

