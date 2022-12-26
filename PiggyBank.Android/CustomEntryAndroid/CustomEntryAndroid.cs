using Android.Graphics.Drawables;
using PiggyBank.CustomInterface;
using PiggyBank.Droid.CustomEntryAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomEntryField), typeof(CustomEntryAndroid))]
namespace PiggyBank.Droid.CustomEntryAndroid
{
    [System.Obsolete]
    public class CustomEntryAndroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
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

