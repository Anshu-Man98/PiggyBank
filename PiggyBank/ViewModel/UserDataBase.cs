using System;
using System.Collections.Generic;
using System.Linq;
using PiggyBank.Model;

namespace PiggyBank.ViewModel
{
    public class UserDataBase:IUserDatabase
    {

        List<LoginData> UserListDatas =new List<LoginData>()
            {
            new LoginData() { UserId = 1, username = "Anshu", password = "9898", ProfilePic = "qwer", MonthSalary = 4000, TotalBalance = 10200 },
            new LoginData() { UserId = 2, username = "Abhii", password = "8989", ProfilePic = "qweree" ,MonthSalary = 3000, TotalBalance = 10300 }
        };

        List<UserExpenditure> UserExpenditures = new List<UserExpenditure>()
            {
            new UserExpenditure() { Id =1, UserId = 1, Amount = -200, isExpense= false, comments = "food",color="DarkRed", date = DateTime.Now.Date.ToString("dd/MM/yyyy") },
            new UserExpenditure() { Id=2, UserId = 1, Amount = 300, isExpense = true, comments = "netflix" ,color="LightGreen", date = DateTime.Now.Date.ToString("dd/MM/yyyy") }
        };

        public UserDataBase()
        {
        }

        public List<LoginData> UsrData()

        {
            return UserListDatas;
        }

        public List<UserExpenditure> getUserExpense(int userId)
        {
            List<UserExpenditure> userExpense = new List<UserExpenditure>();
            var expense = UserExpense();
            foreach (var item in expense)
            {
                if (item.UserId == userId)
                {
                    userExpense.Add(item);
                }
            }
            return userExpense;

        }

        public double TotalUserExpense(int userId)
        {
            double totalExpence = 0;
            var expense = getUserExpense(userId);
            foreach (var item in expense)
            {
                    totalExpence += item.Amount;
                
            }
            return totalExpence;

        }


        public List<UserExpenditure> UserExpense()

        {
            return UserExpenditures;
        }

        public void addUserData(LoginData userData)
        {
            UserListDatas.Add(userData);
        }

        public void addUserExpense(UserExpenditure expense)
        {
            UserExpenditures.Add(expense);
        }

        public double[] getUserAmt(int userId)
        {
            var coll = UserListDatas;
            var found = coll.FirstOrDefault(c => c.UserId == userId);
            return new double[] { found.MonthSalary, found.TotalBalance };
        }

        public string  getUserName(int userId)
        {
            var coll = UserListDatas;
            var found = coll.FirstOrDefault(c => c.UserId == userId);
            return found.username;
        }


    }
}
