using System;
using SQLite;

namespace PiggyBank.Model
{
    [Table("UserCredintials")]
    public class LoginData
    {
        
        public int UserId { get;set; }

        [MaxLength(255)]
        public string username
        {
            get;set;
        }


        [MaxLength(255)]
        public string password
        {
            get;set;
        }

        public string ProfilePic { get; set; }

        public double TotalBalance { get; set; }

        public double MonthSalary { get; set; }

    }
}
