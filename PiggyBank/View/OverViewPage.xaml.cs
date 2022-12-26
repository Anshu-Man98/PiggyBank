using System;
using System.Collections.Generic;
using Microcharts;
using PiggyBank.View.AddExpensePage;
using PiggyBank.ViewModel;
using SkiaSharp;
using Xamarin.Forms;

namespace PiggyBank.View
{
    public partial class PiGraphTest : ContentView
    {
        public PiGraphTest()
        {
            InitializeComponent();
            BindingContext = new AddExpenseVM();
            DisplayBalancePieChart();
            DisplayLineChart();
        }

private void DisplayLineChart()
{
   var entries = new[]
  {
     new ChartEntry(10)
     {
         Color = SKColor.Parse("#02FFC2")
     },
     new ChartEntry(0)
     {
         Color = SKColor.Parse("#05D2FF")
     },
     new ChartEntry(0)
     {
         Color = SKColor.Parse("#00A1C5")
     },
     new ChartEntry(0)
     {
         Color = SKColor.Parse("#007EEC")
     },
     new ChartEntry(0)
     {
         Color = SKColor.Parse("#03579c")
     }
    };

    var lineChartt = new LineChart()
    { Entries = entries, IsAnimated = true, BackgroundColor = SKColors.Transparent, PointSize = 35, LineSize = 8};

    this.linechartView.Chart = lineChartt;
        }

        private void DisplayBalancePieChart()
        {
            var entries = new[]
              {
                 new ChartEntry(148)
                 {
                     Color = SKColor.Parse("#065BFF")
                 },
                new ChartEntry(108)
                 {
                     Color = SKColor.Parse("#5791FF")
                 }

            };

            var chartt = new DonutChart() { Entries = entries, IsAnimated=true, BackgroundColor = SKColors.Transparent };
            this.chartView.Chart = chartt;
        }

        async void SettingsTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfileSettingsPage());
        }
    }
}

