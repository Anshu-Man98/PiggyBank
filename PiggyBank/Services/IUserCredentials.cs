using System;
using System.Threading.Tasks;
using PiggyBank.Model;

namespace PiggyBank.Services
{
    public interface IUserCredentials
    {
        Task<bool> FindUserCredentialsAsync(LoginData loginData);
    }
}
