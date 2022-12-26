using System;
using System.Collections.Generic;
using System.Diagnostics;
using PiggyBank.ViewModel;
using Xamarin.Forms;

namespace PiggyBank.View.ExpenceListPage
{
    public partial class ExpenceListPage : ContentView
    {
        bool selection1Active = true;
        bool selection2Active = false;
        private double valueX, valueY;
        private bool IsTurnX, IsTurnY;
        public ExpenceListPage()
        {
            InitializeComponent();
            BindingContext = new ExpenditureVM();
        }
        void AddExpense(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Expenditure());
        }

        void ExpenceRowTapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Expenditure());
        }

        public void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var x = e.TotalX; // TotalX Left/Right
            var y = e.TotalY; // TotalY Up/Down

            // StatusType
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    Debug.WriteLine("Started");
                    break;
                case GestureStatus.Running:
                    Debug.WriteLine("Running");

                    // Check that the movement is x or y
                    if ((x >= 5 || x <= -5) && !IsTurnX && !IsTurnY)
                    {
                        IsTurnX = true;
                    }

                    if ((y >= 5 || y <= -5) && !IsTurnY && !IsTurnX)
                    {
                        IsTurnY = true;
                    }

                    // X (Horizontal)
                    if (IsTurnX && !IsTurnY)
                    {
                        if (x <= valueX)
                        {
                            // Left
                            if (selection2Active)
                            {
                                //make selection1 move to selection 2

                                selection1Active = true;
                                selection2Active = false;
                                text2.TextColor = Color.FromHex("#377BFD");
                                text1.TextColor = Color.White;
                                runningFrame.TranslateTo(runningFrame.X, 0, 120);

                            }
                        }

                        if (x >= valueX)
                        {
                            // Right
                            if (selection1Active)
                            {
                                //make selection2 move to selection 1
                                selection1Active = false;
                                selection2Active = true;
                                text2.TextColor = Color.White;
                                text1.TextColor = Color.FromHex("#377BFD");
                                runningFrame.TranslateTo(runningFrame.X + 0, 0, 120);

                            }
                        }
                    }


                    break;
                case GestureStatus.Completed:
                    Debug.WriteLine("Completed");

                    valueX = x;
                    valueY = y;

                    IsTurnX = false;
                    IsTurnY = false;

                    break;
                case GestureStatus.Canceled:
                    Debug.WriteLine("Canceled");
                    break;


            }

        }

        void OnText1Tapped(System.Object sender, System.EventArgs e)
        {
            if (selection2Active)
            {
                //make selection1 move to selection 2

                selection1Active = true;
                selection2Active = false;
                text2.TextColor = Color.FromHex("#377BFD");
                text1.TextColor = Color.White;
                runningFrame.TranslateTo(runningFrame.X - 5, 0, 90);
            }
        }

        void OnText2Tapped(System.Object sender, System.EventArgs e)
        {
            if (selection1Active)
            {
                //make selection2 move to selection 1
                selection1Active = false;
                selection2Active = true;
                text2.TextColor = Color.White;
                text1.TextColor = Color.FromHex("#377BFD");
                runningFrame.TranslateTo(runningFrame.X + 70, 0, 400);

            }
        }
    }
}

