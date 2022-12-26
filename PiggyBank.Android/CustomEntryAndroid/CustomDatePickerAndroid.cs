using System;
using Android.Graphics.Drawables;
using PiggyBank.CustomInterface;
using PiggyBank.Droid.CustomEntryAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDateField), typeof(CustomDatePickerAndroid))]
namespace PiggyBank.Droid.CustomEntryAndroid
{
    [Obsolete]
    public class CustomDatePickerAndroid : DatePickerRenderer
    {

            protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
            {
                base.OnElementChanged(e);

                if (e.OldElement == null)
                {
                    var gradientDrawble = new GradientDrawable();

                    gradientDrawble.SetCornerRadius(60f);
                    gradientDrawble.SetColor(Android.Graphics.Color.ParseColor("#8fb5ff"));

                    Control.SetBackground(gradientDrawble);
                    Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, PaddingBottom);

                }
            }
        
    }
}

