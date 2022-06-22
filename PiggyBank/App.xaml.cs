using System;
using System.IO;
using PiggyBank.Services;
using PiggyBank.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiggyBank
{
    public partial class App : Application
    {
        static UserCredentials _userCredentials;

        public static UserCredentials UserCredentials
        {
            get
            {
                if (_userCredentials == null)
                {
                    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var path = Path.Combine(documentsPath, "UserCredDb.db3");
                    _userCredentials = new UserCredentials(path);
                }
                return _userCredentials;
            }
        }

        public App()
        {
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<IUserDatabase, UserDataBase>();
            DependencyService.Register<IExpenditureVM, ExpenditureVM>();
            InitializeComponent();

            MainPage =new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
