using System;
using System.Collections.Generic;
using System.Linq;
using PiggyBank.Model;
using Xamarin.Forms;

namespace PiggyBank.ViewModel
{
    public class UserDataBase: IUserDatabase
    {

        LoginData UserLoginData = new LoginData();

        List<UserExpenditure> UserExpenditures = new List<UserExpenditure>()
            {
            new UserExpenditure() { Id =1, UserId = 1, Amount = -200, isExpense= false, comments = "food", color= "#FBA9A9", date = DateTime.Now.Date.ToString("dd/MM/yyyy") },
            new UserExpenditure() { Id=2, UserId = 1, Amount = 300, isExpense = true, comments = "netflix" ,color="#BCFFD3", date = DateTime.Now.Date.ToString("dd/MM/yyyy") }
        };


        List<ExpenceCategory> Categories = new List<ExpenceCategory>()
        {
            new ExpenceCategory() { CategoryID =1, CategoryType = "Food & Drinks" },
            new ExpenceCategory() { CategoryID =2, CategoryType = "Personal"},
            new ExpenceCategory() { CategoryID =3, CategoryType = "Bills"},
            new ExpenceCategory() { CategoryID =4, CategoryType = "Shopping"},
            new ExpenceCategory() { CategoryID =5, CategoryType = "Other"}
        };


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

        public double TotalUserExpense()
        {
            double totalExpence = 0;
            var expense = getUserExpense(1);
            foreach (var item in expense)
            {
            totalExpence += item.Amount; 
            }
            return totalExpence;
        }

        public List<ExpenceCategory> Expencecategories()
        {
            return Categories;
        }

        public List<UserExpenditure> UserExpense()
        {
            return UserExpenditures;
        }

        public void addUserData(LoginData userData)
        {
            UserLoginData.nikName = userData.nikName;
            UserLoginData.Income = userData.Income;
            UserLoginData.TotalBalance = userData.TotalBalance;
        }

        public void addUserExpense(UserExpenditure expense)
        {
            UserExpenditures.Add(expense);
        }

        //public double[] getUserAmt(int userId)
        //{
        //    var coll = UserListDatas;
        //    var found = coll.FirstOrDefault(c => c.UserId == userId);
        //    return new double[] { found.MonthSalary, found.TotalBalance };
        //}

        //public string  getUserBalanceAndIncome()
        //{
        //    var coll = UserListDatas;
        //    var found = coll.FirstOrDefault(c => c.UserId == userId);
        //    return found.username;
        //}

        public string getUserNikName()
        {
            return  UserLoginData.nikName;
        }

        public double[] getUserBalanceAndIncome()
        {
           return new double[] { UserLoginData.TotalBalance, UserLoginData.Income };
        }
    }
}
