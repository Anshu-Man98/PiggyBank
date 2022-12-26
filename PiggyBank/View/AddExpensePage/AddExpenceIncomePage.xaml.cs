using System;
using System.Collections.Generic;
using System.Diagnostics;
using PiggyBank.ViewModel;
using Xamarin.Forms;

namespace PiggyBank.View.AddExpensePage
{
    public partial class AddExpenceIncomePage : ContentPage
    {
        bool selection1Active = true;
        bool selection2Active = false;
        private double valueX, valueY;
        private bool IsTurnX, IsTurnY;
        public AddExpenceIncomePage()
        {
            InitializeComponent();
            BindingContext = new AddExpenceIncomeLogicVM();
            ExpencePage.IsVisible = true;
            ExpencePage.IsEnabled = true;
            IncomePage.IsVisible = false;
            IncomePage.IsEnabled = false;  
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
                text2.Stroke = Color.FromHex("#377BFD");
                text1.Stroke = Color.White;
                
                runningFrame.TranslateTo(runningFrame.X - 5, 0, 50);
                ExpencePage.IsVisible = true;
                ExpencePage.IsEnabled = true;
                IncomePage.IsVisible = false;
                IncomePage.IsEnabled = false;
            }
        }

        void OnText2Tapped(System.Object sender, System.EventArgs e)
        {
            if (selection1Active)
            {
                //make selection2 move to selection 1
                selection1Active = false;
                selection2Active = true;
                runningFrame.TranslateTo(runningFrame.X + 70, 0, 200);
                ExpencePage.IsVisible = false;
                ExpencePage.IsEnabled = false;
                IncomePage.IsVisible = true;
                IncomePage.IsEnabled = true;
                

            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
        }
    }
}

