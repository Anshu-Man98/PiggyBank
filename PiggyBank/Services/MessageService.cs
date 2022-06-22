using System;
using System.Threading.Tasks;

namespace PiggyBank.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Piggy Bank", message, "Ok");
        }
    }
}
