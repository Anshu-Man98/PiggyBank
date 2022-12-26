using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PiggyBank.Model;
using PiggyBank.View;

namespace PiggyBank.ViewModel
{
    public class SignUpVM:INotifyPropertyChanged 
    {
        private readonly Services.IMessageService _messageService;
        private readonly IUserDatabase _userDatabase;
        public INavigation Navigation { get; set; }

        public SignUpVM(INavigation navigation)
        {
            this.Navigation = navigation;
            this._messageService = DependencyService.Get<Services.IMessageService>();
            this._userDatabase = DependencyService.Get<IUserDatabase>();
            LetsGOCommand = new Command(async () => await AddUserCred());
        }

        public SignUpVM()
        {
        }

        public string nikName = string.Empty;
        public string totalBalance = string.Empty;
        public string income = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string NikName
        {
            set { nikName = value; }
            get { return nikName; }
        }

        public string Balance
        {
            set { totalBalance = value; }
            get { return totalBalance; }
        }

        public string Salary
        {
            set { income = value; }
            get { return income; }
        }

        public Command LetsGOCommand { get; }
       

        async Task AddUserCred()
        {
            OnPropertyChanged(nameof(NikName));
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(Salary));

            //if (NikName.Length <= 2 || 6 <= NikName.Length)
            //{
            //    await _messageService.ShowAsync("Nik Name should have a minimum 3 characters and not more than 5 characters");
            //}
            //else 
            //{
                LoginData NewloginData = new LoginData() {nikName = NikName, Income = Convert.ToDouble(Salary), TotalBalance = Convert.ToDouble(Balance)};
                
                _userDatabase.addUserData(NewloginData);

                await Navigation.PushAsync(new CustomTab());
            //}
            
        }

    }
}
