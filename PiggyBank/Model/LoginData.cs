using System;
using SQLite;

namespace PiggyBank.Model
{
    [Table("UserCredintials")]
    public class LoginData
    {
        [MaxLength(7)]
        public string nikName
        {
            get;set;
        }

        public double TotalBalance { get; set; }

        public double Income { get; set; }
    }
}
