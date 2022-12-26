//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Threading.Tasks;
//using PiggyBank.Model;
//using PiggyBank.View;
//using Xamarin.Forms;

//namespace PiggyBank.ViewModel
//{
//    public class GetStartedPageVM : INotifyPropertyChanged
//    {
//        private readonly Services.IMessageService _messageService;
//        private readonly IUserDatabase _userDatabase;

//        public INavigation Navigation { get; set; }

//        public GetStartedPageVM(INavigation navigation)
//        {
//            this.Navigation = navigation;
//            this._messageService = DependencyService.Get<Services.IMessageService>();
//            this._userDatabase = DependencyService.Get<IUserDatabase>();
//            LogInCommand = new Command(async () => await LogUser());
//        }

//        public string userName = string.Empty;
//        public string password = string.Empty;


//        public event PropertyChangedEventHandler PropertyChanged;

//        void OnPropertyChanged(string name)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
//        }

//        public static int UserId { get; set; }

//        public string UserName
//        {
//            set { userName = value; OnPropertyChanged(nameof(UserName)); }
//            get { return userName; }
//        }

//        public string Password
//        {
//            set { password = value; OnPropertyChanged(nameof(Password)); }
//            get { return password; }
//        }

//        public Command LogInCommand { get; }

//        List<LoginData> UserListDatas = null;


//        public LoginData isUserRegistered(string userName, string password)
//        {

//            var UserListData = _userDatabase.UsrData();


//            LoginData userData = null;
//            foreach (var user in UserListData)
//            {
//                if (userName == user.username && password == user.password)
//                {
//                    userData = user;
//                    break;
//                }
//                else
//                {
//                    userData = null;
//                }

//            }
//            return userData;
//        }


//        async Task LogUser()
//        {

//            LoginData userData = isUserRegistered("Anshu", "9898");
//            UserId = userData.UserId;
//            await Navigation.PushAsync(new SignUpPage());

//        }
//    }
//}
