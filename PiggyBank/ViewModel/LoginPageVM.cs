using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PiggyBank.Model;
using PiggyBank.View;
using PiggyBank.View.FlyoutView;
using Xamarin.Forms;

namespace PiggyBank.ViewModel
{
    public class LoginPageVM : INotifyPropertyChanged
    {
        private readonly Services.IMessageService _messageService;
        private readonly IUserDatabase _userDatabase;

        public INavigation Navigation { get; set; }

        public LoginPageVM(INavigation navigation)
        {
            this.Navigation = navigation;
            this._messageService = DependencyService.Get<Services.IMessageService>();
            this._userDatabase = DependencyService.Get<IUserDatabase>();
            LogInCommand = new Command(async () => await LogUser());
        }

        public string userName = string.Empty;
        public string password = string.Empty;
        

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static int UserId { get; set; }

        public string UserName
        {
            set { userName = value; OnPropertyChanged(nameof(UserName)); }
            get { return userName; }
        }

        public string Password
        {
            set { password = value; OnPropertyChanged(nameof(Password)); }
            get { return password; }
        }

        public Command LogInCommand { get; }

        List<LoginData> UserListDatas = null;


        public LoginData isUserRegistered(string userName, string password)
        {
            
            var UserListData = _userDatabase.UsrData();


            LoginData userData = null;
            foreach (var user in UserListData)
            {
                if(userName == user.username && password == user.password)
                {
                    userData = user;
                    break;
                }
                else
                {
                    userData = null;
                }
                
            }
            return userData;
        } 


        async Task LogUser()
        {
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(Password));

            if (UserName.Length >= 4 && Password.Length == 0)
            {
                await _messageService.ShowAsync("Please enter Password");
            }
            else if (UserName.Length == 0 && Password.Length >= 4)
            {
                await _messageService.ShowAsync("Please enter username");
            }
            else if (UserName.Length <= 4 && Password.Length <= 4)
            {
                await _messageService.ShowAsync("Please enter your username and password");
            }
            else if (UserName.Length >= 4 && Password.Length >= 4)
            {
                LoginData userData = isUserRegistered(UserName, Password);
                if (userData.UserId == 0)
                {
                    await _messageService.ShowAsync("This user does not exist! Please register");
                    
                }
                else
                {
                    //var send = new StatusPageVM();
                    //send.setUserStatus(userId);

                    UserId = userData.UserId;
                    await Navigation.PushAsync(new FlyoutPageSlider());
                }

            }
        }
    }
}
