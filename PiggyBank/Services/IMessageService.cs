using System;
using System.Threading.Tasks;

namespace PiggyBank.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
    }
}
