using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiggyBank.View.FlyoutView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageSliderFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPageSliderFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPageSliderFlyoutViewModel();
            ListView = MenuItemsListView;
            
        }

        class FlyoutPageSliderFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPageSliderFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPageSliderFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPageSliderFlyoutMenuItem>(new[]
                {
                    new FlyoutPageSliderFlyoutMenuItem { Id = 0, Title = "Home", TargetType=typeof(MainPageTab)},
                    new FlyoutPageSliderFlyoutMenuItem { Id = 1, Title = "Profile Settings", TargetType=typeof(ProfileSettingsPage)},
                    new FlyoutPageSliderFlyoutMenuItem { Id = 2, Title = "App Theme", TargetType=typeof(AppThemePage) },
                    new FlyoutPageSliderFlyoutMenuItem { Id = 3, Title = "About", TargetType=typeof(AboutPage) },

                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        
    }
}