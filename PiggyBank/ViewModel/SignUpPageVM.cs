using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PiggyBank.Model;

namespace PiggyBank.ViewModel
{
    public class SignUpPageVM:INotifyPropertyChanged 
    {
        private readonly Services.IMessageService _messageService;
        private readonly IUserDatabase _userDatabase;
        public INavigation Navigation { get; set; }

        public SignUpPageVM(INavigation navigation)
        {
            this.Navigation = navigation;
            this._messageService = DependencyService.Get<Services.IMessageService>();
            this._userDatabase = DependencyService.Get<IUserDatabase>();
            SignInCommand = new Command(async () => await AddUserCred());
        }

        public SignUpPageVM()
        {
        }

        public string userName = string.Empty;
        public string password = string.Empty;
        public double balance = 0;
        public double salary = 0;
        public int userId = 3;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }

        public string Password
        {
            set { password = value;}
            get { return password; }
        }

        public double Balance
        {
            set { balance = value; }
            get { return balance; }
        }

        public double Salary
        {
            set { salary = value; }
            get { return salary; }
        }

        public Command SignInCommand { get; }
       

        async Task AddUserCred()
        {
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(Salary));

            if (UserName.Length >= 4 && Password.Length == 0 )
            {
               await _messageService.ShowAsync("Please Set a Password");
            }
            else if (UserName.Length == 0 && Password.Length>=4)
            {
               await _messageService.ShowAsync("Please Set a username");
            }
            else if (UserName.Length <= 4 && Password.Length <= 4)
            {
               await _messageService.ShowAsync("Please enter your username and password");
            }
            else if(UserName.Length >= 4 && Password.Length >= 4)
            {
                LoginData NewloginData = new LoginData() { UserId = userId , username = UserName, password = Password, MonthSalary = Salary, TotalBalance = Balance, ProfilePic="werrr"};
                userId++;
                _userDatabase.addUserData(NewloginData);
                await _messageService.ShowAsync("Sign Up successful");
                

            }
        }

      

        //public Task<bool> AddUserCredentialsAsync(LoginData loginData)
        //{
        //    return true;
        //}

        //public Task<bool> FindUserCredentialsAsync(LoginData loginData)
        //{

        //}
    }
}
